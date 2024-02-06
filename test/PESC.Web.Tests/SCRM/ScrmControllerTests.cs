using Docker.DotNet.Models;
using Microsoft.EntityFrameworkCore;
using NetCorePal.Extensions.AspNetCore;
using Newtonsoft.Json;
using PESC.Domain.Share;
using PESC.Infrastructure;
using PESC.Web.Application.Commands.SCRM;
using PESC.Web.Application.ViewModels;
using PESC.Web.Extensions;
using PESC.Web.QueryConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace PESC.Web.Tests.SCRM
{
    public class ScrmControllerTests : IClassFixture<MyWebApplicationFactory>
    {
        private readonly MyWebApplicationFactory _factory;
        private readonly ITestOutputHelper output;
        private readonly HttpClient _client;

        public ScrmControllerTests(MyWebApplicationFactory factory, ITestOutputHelper output)
        {
            using (var scope = factory.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
            _factory = factory;
            _client = factory.WithWebHostBuilder(builder => { builder.ConfigureServices(p => { }); }).CreateClient();
            this.output = output;
        }

        [Fact]
        [Trait("Category", "SCRM")]
        public async Task LoginByPwdTest()
        {
            var json = """
                       {
                         "TenantId": "admin",
                         "LoginId": "admin",
                         "Password": "admin",
                         "pageName": "2021-08-31T15:00:00"
                       }
                       """;
            var content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/Scrm/LoginByPwd", content);
            Assert.True(response.IsSuccessStatusCode);
            var responseData = await response.Content.ReadFromNewtonsoftJsonAsync<ResponseData>();
            Assert.NotNull(responseData);
            Assert.False(responseData.Success);

        }
        //准备测试用的新用户
        async Task<ResponseData<UserId>?> PrepareNewUserAsync(string UserName)
        {
            AddUserCmd addUserCmd = new AddUserCmd()
            {
                TenantId = "admin",
                OperatorId = 1,
                OperatorLoginId = "admin",
                Password = "admin",
                pageName = "2021-08-31T15:00:00",
                NewUser = new UserDto()
                {
                    TenantId = "SICC-A-GR",
                    LoginId = UserName,
                    Desc = UserName + "张三",
                    DepartmentId = "12",
                    Mail = "1",
                    Phone = "1",
                    Password = UserName,
                }
            };  
            string json = JsonConvert.SerializeObject(addUserCmd);
            var content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/Scrm/AddUser", content);
            var responseData = await response.Content.ReadFromNewtonsoftJsonAsync<ResponseData<UserId>>();
            return responseData;
        }
        [Fact]
        [Trait("Category", "SCRM")]
        public async Task UserLogin_Fail_Test()
        {
            var json = """
                       {
                         "TenantId": "SICC-A-GR",
                         "LoginId": "Y00538",
                         "Password": "Y00537",
                         "pageName": "2021-08-31T15:00:00"
                       }
                       """;
            var content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/Scrm/LoginByPwd", content);
            Assert.True(response.IsSuccessStatusCode);
            var responseData = await response.Content.ReadFromNewtonsoftJsonAsync<ResponseData>();
            Assert.NotNull(responseData);
            Assert.False(responseData.Success);

        }
        [Fact]
        [Trait("Category", "SCRM")]
        public async Task AddNewUserTest()
        {
            var responseData = await PrepareNewUserAsync("Y00537");
            Assert.NotNull(responseData);
            Assert.True(responseData.Success);

            var json = """
                       {
                            "TenantId": "SICC-A-GR",
                            "LoginId": "Y00537",
                            "Password": "Y00537",
                         "pageName": "2021-08-31T15:00:00"
                         }
                       """;
            var content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/Scrm/LoginByPwd", content);
            Assert.True(response.IsSuccessStatusCode);
            responseData = await response.Content.ReadFromNewtonsoftJsonAsync<ResponseData<UserId>>();
            Assert.NotNull(responseData);
            Assert.True(responseData.Success);
        }
        [Fact]
        [Trait("Category", "SCRM")]
        public async Task UpdateUserTest()
        {
            var responseData = await PrepareNewUserAsync("Y00540");
            Assert.NotNull(responseData);
            if (!responseData.Success)
            {
                output.WriteLine(responseData.Message);
            }
            Assert.True(responseData.Success);
            UserId userId = responseData.Data;
            UpdateUserCmd updateUserCmd = new UpdateUserCmd()
            {
                TenantId = "admin",
                OperatorId = 1,
                OperatorLoginId = "admin",
                Password = "admin",
                pageName = "2021-08-31T15:00:00",
                User = new UserDto()
                {
                    Id = userId,
                    TenantId = "SICC-A-GR",
                    LoginId = "Y00540",
                    Desc = "Y00540张三Update",
                    DepartmentId = "12",
                    Mail = "1",
                    Phone = "1",
                    Password = "Y00540",
                }
            };
            string cmdJson = JsonConvert.SerializeObject(updateUserCmd);    
            var content = new StringContent(cmdJson);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/Scrm/UpdateUser", content);
            Assert.True(response.IsSuccessStatusCode);
            var rspData = await response.Content.ReadFromNewtonsoftJsonAsync<ResponseData>();
            Assert.NotNull(rspData);
            Assert.True(rspData.Success);
            using (var scope = _factory.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = db.Users.Where(c => c.Id == userId).FirstOrDefault();
                Assert.NotNull(user);
                Assert.Equal("Y00540张三Update", user.Desc);
            }
        }
        [Fact]
        public async Task PageQueryUser_CheckPageCount()
        {
            var responseData = await PrepareNewUserAsync("Y00541");
            Assert.NotNull(responseData);
            Assert.True(responseData.Success);
            int initCnt = 0;    
            using (var scope = _factory.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                initCnt = db.Users.Count();
            }
            UserQueryCondition userQueryCondition = new UserQueryCondition();
            userQueryCondition.PageIndex = 1;
            userQueryCondition.PageSize = initCnt+1;
            userQueryCondition.TenantId = "SICC-A-GR";
            string cmdJson = JsonConvert.SerializeObject(userQueryCondition);
            var content = new StringContent(cmdJson);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/Scrm/FindUsers", content);
            Assert.True(response.IsSuccessStatusCode);
            var rspData = await response.Content.ReadFromNewtonsoftJsonAsync<ResponseData<PageResponseData<UserDto>>>();
            Assert.NotNull(rspData);
            Assert.True(rspData.Success);
            if (rspData.Data.PageCount == 0)
            {
                Assert.Empty(rspData.Data.Data);
            }
            else if (rspData.Data.PageCount == 1)
            {
                Assert.True(rspData.Data.Data.Count()<=rspData.Data.PageSize);
            }else
            {
                Assert.Equal(rspData.Data.Data.Count(),rspData.Data.PageSize);

            }

        }

    }
}

﻿using Microsoft.EntityFrameworkCore;
using NetCorePal.Extensions.AspNetCore;
using PESC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Web.Tests.SCRM
{
    public class ScrmControllerTests : IClassFixture<MyWebApplicationFactory>
    {
        private readonly MyWebApplicationFactory _factory;

        private readonly HttpClient _client;

        public ScrmControllerTests(MyWebApplicationFactory factory)
        {
            using (var scope = factory.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
            _factory = factory;
            _client = factory.WithWebHostBuilder(builder => { builder.ConfigureServices(p => { }); }).CreateClient();
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
        async Task<ResponseData?> PrepareNewUserAsync()
        {
            var json = """
                       {
                         "TenantId": "admin",
                         "Operator": "admin",
                         "OperatorLoginId": "admin",
                         "Password": "admin",
                         "pageName": "2021-08-31T15:00:00",
                         "NewUser":{
                            "TenantId": "SICC-A-GR",
                            "LoginId": "Y00537",
                            "Desc": "Y00537于晨",
                            "Roles": [
                                "1"
                            ],
                            "DepartmentId": "1",
                            "Mail": "1",
                            "Phone": "1",
                            "LastLoginTime": "2021-08-31T15:00:00",
                            "CreationTime": "2021-08-31T1",
                            "Password": "Y00537",
                         }
                         }
                       }
                       """;
            var content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/Scrm/AddUser", content);
            var responseData = await response.Content.ReadFromNewtonsoftJsonAsync<ResponseData>();
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

            var responseData = await PrepareNewUserAsync();
            Assert.NotNull(responseData);
            Assert.True(responseData.Success);

            string json = """
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
            responseData = await response.Content.ReadFromNewtonsoftJsonAsync<ResponseData>();
            Assert.NotNull(responseData);
            Assert.True(responseData.Success);
        }
    }
}
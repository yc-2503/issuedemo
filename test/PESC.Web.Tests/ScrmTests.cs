using Microsoft.EntityFrameworkCore;
using PESC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Web.Tests
{
    public class ScrmTests : IClassFixture<MyWebApplicationFactory>
    {
        private readonly MyWebApplicationFactory _factory;

        private readonly HttpClient _client;

        public ScrmTests(MyWebApplicationFactory factory)
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
        public async Task LoginByPwdTest()
        {
            var json = """
                       {
                         "Factory": "admin",
                         "LoginId": "admin",
                         "Password": "admin",
                         "pageName": "2021-08-31T15:00:00"
                       }
                       """;
            var content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/Scrm/LoginByPwd", content);
            Assert.True(response.IsSuccessStatusCode);
            var responseData = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseData);

        }
    }
}

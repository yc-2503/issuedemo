using Microsoft.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Infrastructure;
using PESC.Web.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Web.Tests.SCRM;

public class RoleQueryTest : IClassFixture<MyWebApplicationFactory>
{
    private readonly MyWebApplicationFactory _factory;

    private readonly HttpClient _client;

    public RoleQueryTest(MyWebApplicationFactory factory)
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
    public async Task RoleFind_TestAsync()
    {

        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.Migrate();
            RoleQuery roleQuery = new RoleQuery(db);
            var role = await roleQuery.FindRoleAsync("SICC-A-GR", "adminr");
            Assert.Null(role);
            UserRole userRole = new UserRole("SICC-A-GR", "adminr");
            db.Roles.Add(userRole);
            db.SaveChanges();
            role = await roleQuery.FindRoleAsync("SICC-A-GR", "adminr");
            Assert.NotNull(role);
            Assert.Equal("adminr", role.UserRoleId);
            Assert.Equal("SICC-A-GR", role.TenantId);
        }
    }
}
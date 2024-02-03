﻿using Docker.DotNet.Models;
using Microsoft.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Infrastructure;
using PESC.Web.Application.Queries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Web.Tests.SCRM
{
    public class UserQueryTest : IClassFixture<MyWebApplicationFactory>
    {
        private readonly MyWebApplicationFactory _factory;

        private readonly HttpClient _client;

        public UserQueryTest(MyWebApplicationFactory factory)
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
        public async void FindUser_Test()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
                UserQuery userQuery = new UserQuery(db);
                var user = await userQuery.FindUserAsync("SICC-A-GR", "admin");
                Assert.Null(user);
                UserRole userRole = new UserRole("SICC-A-GR", "admin");
                db.Roles.Add(userRole);
                User user1 = new User("SICC-A-GR", "admin", "admin");
                user1.Roles = [userRole];
                db.Users.Add(user1);
                db.SaveChanges();
                user = await userQuery.FindUserAsync("SICC-A-GR", "admin");
                Assert.NotNull(user);
                Assert.Equal("admin", user.LoginId);
                Assert.Equal("SICC-A-GR", user.TenantId);
                //  Assert.NotNull(user.Roles);
                //  Assert.NotEmpty(user.Roles);
                user = await userQuery.FindUserAsync(user.Id);
                Assert.NotNull(user);
                Assert.Equal("admin", user.LoginId);
                Assert.Equal("SICC-A-GR", user.TenantId);
                Assert.NotNull(user.Roles);
                Assert.NotEmpty(user.Roles);
            }
        }
        [Fact]
        public async void FindUsersCountTest()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
                UserQuery userQuery = new UserQuery(db);
                int initCnt = await userQuery.FindUsersCountAsync(new Application.Commands.UserQueryCondition() { PageIndex = 1, PageSize = 10, TenantId = "SICC-A-GR" });
                db.Users.Add(new User("SICC-A-GR", "Y00538", "AAA"));
                await db.SaveEntitiesAsync();
                int addOne = await userQuery.FindUsersCountAsync(new Application.Commands.UserQueryCondition() { PageIndex = 1, PageSize = 10, TenantId = "SICC-A-GR" });
                Assert.Equal(addOne, initCnt + 1);
                int addOnePage2 = await userQuery.FindUsersCountAsync(new Application.Commands.UserQueryCondition() { PageIndex = 2, PageSize = initCnt + 1, TenantId = "SICC-A-GR" });
                Assert.Equal(0, addOnePage2);
                int addOneOtherFactory = await userQuery.FindUsersCountAsync(new Application.Commands.UserQueryCondition() { PageIndex = 2, PageSize = 10, TenantId = "SICC-D-GR" });
                Assert.Equal(0, addOneOtherFactory);

            }
        }
        [Fact]
        public async void FindUsersTest()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
                UserQuery userQuery = new UserQuery(db);
                var initUsers = await userQuery.FindUsersAsync(new Application.Commands.UserQueryCondition() { PageIndex = 1, PageSize = 10, TenantId = "SICC-A-GR" });
                db.Users.Add(new User("SICC-A-GR", "Y00537", "AAA"));
                await db.SaveEntitiesAsync();
                var addOne = await userQuery.FindUsersAsync(new Application.Commands.UserQueryCondition() { PageIndex = 1, PageSize = 10, TenantId = "SICC-A-GR" });
                Assert.True(addOne.Any(c => c.LoginId == "Y00537" && c.TenantId == "SICC-A-GR"));

                var addOnePage2 = await userQuery.FindUsersAsync(new Application.Commands.UserQueryCondition() { PageIndex = 2, PageSize = initUsers.Count() + 1, TenantId = "SICC-A-GR" });
                Assert.Empty(addOnePage2);
                var addOneOtherFactory = await userQuery.FindUsersAsync(new Application.Commands.UserQueryCondition() { PageIndex = 2, PageSize = 10, TenantId = "SICC-D-GR" });
                Assert.Empty(addOneOtherFactory);

            }
        }
    }

}
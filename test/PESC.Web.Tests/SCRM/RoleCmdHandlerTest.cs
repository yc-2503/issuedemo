using Moq;
using NetCorePal.Extensions.Repository;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.Share;
using PESC.Infrastructure.Repositories;
using PESC.Web.Application.Commands.SCRM;
using PESC.Web.Application.Queries;
using PESC.Web.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Web.Tests.SCRM
{
    public class RoleCmdHandlerTest
    {
        [Fact]
        public async Task AssignRoleCmdHandler_Normal_Test()
        {
            Mock<IRoleRepository> mockRoleRp = new Mock<IRoleRepository>();
            Mock<IUserRepository> mockUserQ = new Mock<IUserRepository>();
            UserId userId = new UserId(1);
            RoleId roleId = new RoleId(1);
            User qUser = new Domain.AggregatesModel.SCRM.UserAggregate.User("SICC-A-GR", "ADMIN", "A");
            mockUserQ.Setup(p => p.GetAsync(userId,default)).Returns(Task.FromResult(qUser)!);
            UserRole userRole = new UserRole("SICC-A-GR","ADMIN");
            mockRoleRp.Setup(P => P.GetAsync(roleId, default)).Returns(Task.FromResult(userRole)!);
            AssignRoleCmdHandler assignRoleCmdHandler = new AssignRoleCmdHandler(mockRoleRp.Object,mockUserQ.Object);
            AssignRoleCmd assignRoleCmd = new AssignRoleCmd() { OperatorLoginId="ADMIN",TenantId= "SICC-A-GR", UserId = userId, Roles = [roleId]  };
            var rsp = await assignRoleCmdHandler.Handle(assignRoleCmd,default);
            Assert.NotNull(rsp);
            Assert.True(rsp.Success);
            Assert.NotNull(qUser.Roles);
            Assert.NotEmpty(qUser.Roles);

        }
        [Fact]
        public async Task AssignRoleCmdHandler_UserDeleted_Test()
        {
            Mock<IRoleRepository> mockRoleRp = new Mock<IRoleRepository>();
            Mock<IUserRepository> mockUserQ = new Mock<IUserRepository>();
            UserId userId = new UserId(1);
            RoleId roleId = new RoleId(1);
            User qUser = new Domain.AggregatesModel.SCRM.UserAggregate.User("SICC-A-GR", "ADMIN", "A");
            qUser.IsDeleted = true;
            mockUserQ.Setup(p => p.GetAsync(userId, default)).Returns(Task.FromResult(qUser)!);
            UserRole userRole = new UserRole("SICC-A-GR", "ADMIN");
            mockRoleRp.Setup(P => P.GetAsync(roleId, default)).Returns(Task.FromResult(userRole)!);
            AssignRoleCmdHandler assignRoleCmdHandler = new AssignRoleCmdHandler(mockRoleRp.Object, mockUserQ.Object);
            AssignRoleCmd assignRoleCmd = new AssignRoleCmd() { OperatorLoginId = "ADMIN", TenantId = "SICC-A-GR", UserId = userId, Roles = [roleId] };
            var rsp = await assignRoleCmdHandler.Handle(assignRoleCmd, default);
            Assert.NotNull(rsp);
            Assert.False(rsp.Success);
            Assert.Equal(RspErrCode.UserDoNotExist, rsp.Code);

        }
    }
}

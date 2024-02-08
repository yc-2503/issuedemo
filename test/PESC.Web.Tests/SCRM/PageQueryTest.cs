using Moq;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Web.Application.Queries;
using PESC.Web.Extensions;
using PESC.Web.QueryConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Web.Tests.SCRM;

public class PageQueryTest
{
    [Fact]
    public async Task PageFindMany_SinglePage_ReturnSInglePage()
    {
        Mock<IUserQuery> mockPageQuery = new Mock<IUserQuery>();
        List<User> stubUsers = new List<User>() 
        {
            new User("A", "Y0001", null)
        };
        mockPageQuery.Setup(p => p.FindManyAsync(It.IsAny<UserQueryCondition>())).Returns(Task.FromResult((IEnumerable<User>)(stubUsers)));
        mockPageQuery.Setup(p => p.FindCountAsync(It.IsAny<UserQueryCondition>())).Returns(Task.FromResult(1));

        UserQueryCondition userQueryCondition = new UserQueryCondition();
        userQueryCondition.PageIndex = 1;
        userQueryCondition.PageSize = 10;
        var rsp = await mockPageQuery.Object.PageFindMany(userQueryCondition);
        Assert.NotNull(rsp);
        Assert.Equal(1, rsp.PageIndex);
        Assert.Equal(1, rsp.PageCount);
        Assert.Equal(10, rsp.PageSize);
        Assert.NotNull(rsp.Data);
        Assert.Contains(stubUsers[0], rsp.Data);
    }
    [Fact]
    public async Task PageFindMany_TwoPage_ReturnTwoPage()
    {
        Mock<IUserQuery> mockPageQuery = new Mock<IUserQuery>();
        List<User> stubUsers = new List<User>()
        {
            new User("A", "Y0001", null),
            new User("A", "Y0002", null),
          //  new User("A", "Y0003", null)
        };
        mockPageQuery.Setup(p => p.FindManyAsync(It.IsAny<UserQueryCondition>())).Returns(Task.FromResult((IEnumerable<User>)(stubUsers)));
        mockPageQuery.Setup(p => p.FindCountAsync(It.IsAny<UserQueryCondition>())).Returns(Task.FromResult(3));

        UserQueryCondition userQueryCondition = new UserQueryCondition();
        userQueryCondition.PageIndex = 1;
        userQueryCondition.PageSize = 2;
        var rsp = await mockPageQuery.Object.PageFindMany(userQueryCondition);
        Assert.NotNull(rsp);
        Assert.Equal(1, rsp.PageIndex);
        Assert.Equal(2, rsp.PageCount);
        Assert.Equal(2, rsp.PageSize);
        Assert.NotNull(rsp.Data);
        Assert.Contains(stubUsers[0], rsp.Data);
    }
}

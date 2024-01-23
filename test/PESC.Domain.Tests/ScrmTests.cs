using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Domain.Tests;

public class ScrmTests
{
    [Fact]
    public void User_LoginByPwd_Tests()
    {
        User user = new User("ADMIN","Y0001","PWODD");
        Assert.False(user.LoginByPwd("P"));
        Assert.Equal(1, user.FailCnt);
        Assert.True(user.LoginByPwd("PWODD"));
        Assert.Equal(0, user.FailCnt);
    }
    [Fact]
    public void User_ResetPassword_Tests() 
    {
        User user = new User("ADMIN", "Y0001", "PWODD");
        Assert.False(user.LoginByPwd("P"));
        Assert.Equal(1, user.FailCnt);
        user.ResetPwd("P");
        Assert.Equal(0, user.FailCnt);
        Assert.True(user.LoginByPwd("P"));
    }
}
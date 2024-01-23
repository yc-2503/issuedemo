using NetCorePal.Extensions.Domain;
using PESC.Domain.Share;
using PESC.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;

namespace PESC.Domain.AggregatesModel.SCRM.UserAggregate;

public class User : Entity<UserId>, IAggregateRoot
{
    protected User() { }
    public User(string factory, string loginId, string password)
    {
        this.Factory = factory;
        this.LoginId = loginId;
        //TODO:加解密
        this.Password = password;
    }
    public string Factory { get; } = string.Empty;
    public string LoginId { get; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public string? Desc { get; set; }
    public Collection<Role>? Roles { get; set; }
    /// <summary>
    /// 登录失败次数，登录成功后会清零
    /// </summary>
    public int FailCnt { get; set; }
    public string? DepartmentId { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime LastLoginTime { get; set; }
    public DateTime CreationTime { get; set; }
    public UserId? CreatorId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public UserId? LastModifierId { get; set; }

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="pwd">登录密码</param>
    /// <returns></returns>
    public bool LoginByPwd(string pwd)
    {
        if (Password == pwd)
        {
            FailCnt = 0;
            LastLoginTime = DateTime.Now;
            return true;
        }
        else
        {
            FailCnt++;
            return false;
        }
    }
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="pwd"></param>
    public void ResetPwd(string pwd)
    {
        FailCnt = 0;
        Password = pwd;
    }
}

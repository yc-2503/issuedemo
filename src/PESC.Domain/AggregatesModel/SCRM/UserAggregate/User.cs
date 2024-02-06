using PESC.Domain.Share;
using System.Text;
using System.Collections.ObjectModel;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using MediatR;
using PESC.Domain.DomainEvents;
using System.Security.Cryptography;
using PESC.Domain.Extensions;

namespace PESC.Domain.AggregatesModel.SCRM.UserAggregate;

public class User : AggregateRoot<UserId>, IMultiTenant
{
    protected User() { }

    //automapper 也会用这个构造函数生成实例
    public User(string tenantId, string loginId, string? password)
    {
        this.TenantId = tenantId;
        this.LoginId = loginId;
        if (password != null)
        {
            this.Password = ToMD5(password);

        }
    }
    /// <summary>
    /// MD5加密字符串（32位大写）
    /// </summary>
    /// <param name="source">源字符串</param>
    /// <returns>加密后的字符串</returns>
    string ToMD5(string source)
    {
        using (var md5 = MD5.Create())
        {
            var result = md5.ComputeHash(Encoding.UTF8.GetBytes(source));
            var strResult = BitConverter.ToString(result);
            return  strResult.Replace("-", "");
        }
    }
    public string TenantId { get; set; } = string.Empty;
    public string LoginId { get; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public string? Name { get; set; }
    public string? Desc { get; set; }
    public Collection<UserRole>? Roles { get; set; }
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
    public string? LastModifierId { get; set; }

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="pwd">登录密码</param>
    /// <returns></returns>
    public bool LoginByPwd(string pwd)
    {
        string inputPwd = ToMD5(pwd);
        if (Password == inputPwd)
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
        Password = ToMD5(pwd);
    }
    public void InitNewUser(UserId creator)
    {
        CreatorId = creator;
        LastModificationTime = DateTime.Now;
        CreationTime = DateTime.Now;
        LastLoginTime = DateTime.Now;
        AddDomainEvent(new UserCreatedDomainEvent(this));
    }
    public void UpdateUser(User user)
    {
        Name = user.Name;
        Desc = user.Desc;
        DepartmentId = user.DepartmentId;
        Mail = user.Mail;
        Phone = user.Phone;
        LastModificationTime = DateTime.Now;
    }
}

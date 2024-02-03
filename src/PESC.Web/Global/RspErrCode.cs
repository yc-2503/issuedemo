using Newtonsoft.Json.Serialization;

namespace PESC.Web.Global;

public static class RspErrCode
{
    const int SCRMZone = 10000;
    /// <summary>
    /// 用户名或密码错误
    /// </summary>
    public const int LoginFail = SCRMZone+0;
    /// <summary>
    /// 失败次数过多，禁止登录
    /// </summary>
    public const int LoginTooMany = SCRMZone+1;
    /// <summary>
    /// 用户已存在
    /// </summary>
    public const int UserAlreadyExist = SCRMZone+2;
    /// <summary>
    /// 用户不存在
    /// </summary>
    public const int UserDoNotExist = SCRMZone+3;
    /// <summary>
    /// 用户已存在
    /// </summary>
    public const int RoleAlreadyExist = SCRMZone + 4;
    /// <summary>
    /// 用户不存在
    /// </summary>
    public const int RoleDoNotExist = SCRMZone + 5;
}

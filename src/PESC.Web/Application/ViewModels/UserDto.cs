using PESC.Domain.Share;
using System.Collections.ObjectModel;

namespace PESC.Web.Application.ViewModels;

public class UserDto
{
    public UserId? Id { get; set; }
    public string TenantId { get; set; } = string.Empty;
    public string LoginId { get; set; } = string.Empty;
    public string? Desc { get; set; }
    public string? Password { get; set; }
  //  public Collection<Role>? Roles { get; set; }
    /// <summary>
    /// 登录失败次数，登录成功后会清零
    /// </summary>
    public string? DepartmentId { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public string? Name { get; set; }
}

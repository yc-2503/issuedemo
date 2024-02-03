using NetCorePal.Extensions.Primitives;
using NetCorePal.Extensions.AspNetCore;
using PESC.Domain.Share;
namespace PESC.Web.Application.Commands;

public abstract class BaseActionCommand: ICommand<ResponseData>
{
    public  UserId? OperatorId { get; set; }
    public required string TenantId { get; set; }
    public required string OperatorLoginId { get; set; }
    public string? Password { get; set; }
    public string? pageName { get; set; }
}

public abstract class BaseActionCommand<T>:ICommand<ResponseData<T>>
{
    public UserId? OperatorId { get; set; }
    public required string TenantId { get; set; }
    public required string OperatorLoginId { get; set; }
    public string? Password { get; set; }
    public string? pageName { get; set; }
}

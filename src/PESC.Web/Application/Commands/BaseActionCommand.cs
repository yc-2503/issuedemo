using NetCorePal.Extensions.Primitives;
using NetCorePal.Extensions.AspNetCore;
namespace PESC.Web.Application.Commands;

public abstract class BaseActionCommand: ICommand<ResponseData>
{
    public required string Factory { get; set; }
    public required string LoginId { get; set; }
    public string? Password { get; set; }
    public string? pageName { get; set; }
}

public abstract class BaseActionCommand<T>:ICommand<ResponseData<T>>
{
    public required string Factory { get; set; }
    public required string LoginId { get; set; }
    public string? Password { get; set; }
    public string? pageName { get; set; }
}

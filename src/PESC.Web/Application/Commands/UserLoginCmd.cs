using NetCorePal.Extensions.Primitives;
using PESC.Web.Application.ViewModels;

namespace PESC.Web.Application.Commands;

public class UserLoginCmd : BaseActionCommand
{
}
public class AddUserCmd : BaseActionCommand
{
    public required UserDto NewUser { get; set; }
}
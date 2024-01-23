using FluentValidation;
using PESC.Web.Application.ViewModels;

namespace PESC.Web.Application.Commands;

public class AddUserCmd : BaseActionCommand
{
    public required UserDto NewUser { get; set; }
}
public class AddUserCmdValidator : AbstractValidator<AddUserCmd>
{
    public AddUserCmdValidator()
    {
        RuleFor(x => x.NewUser.LoginId).NotEmpty().MaximumLength(32).WithErrorCode("LoginId error code");
        RuleFor(x => x.NewUser.Factory).NotEmpty().MaximumLength(32).WithErrorCode("Factory error code");
        RuleFor(x => x.NewUser.Password).NotEmpty().MaximumLength(256).WithErrorCode("Password error code");

    }
}

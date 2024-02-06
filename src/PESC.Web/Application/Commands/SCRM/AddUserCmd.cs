using FluentValidation;
using PESC.Domain.Share;
using PESC.Web.Application.ViewModels;

namespace PESC.Web.Application.Commands.SCRM;

public class AddUserCmd : BaseActionCommand<UserId>
{
    public required UserDto NewUser { get; set; }
}
public class AddUserCmdValidator : AbstractValidator<AddUserCmd>
{
    public AddUserCmdValidator()
    {
        RuleFor(x => x.NewUser.LoginId).NotEmpty().MaximumLength(32).WithErrorCode("LoginId error code");
        RuleFor(x => x.NewUser.TenantId).NotEmpty().MaximumLength(32).WithErrorCode("TenantId error code");
        RuleFor(x => x.NewUser.Password).NotEmpty().MaximumLength(256).WithErrorCode("Password error code");

    }
}
public class UpdateUserCmd : BaseActionCommand
{
    public required UserDto User { get; set; }
}
public class UpdateUserCmdValidator : AbstractValidator<UpdateUserCmd>
{
    public UpdateUserCmdValidator()
    {
        RuleFor(x => x.User.Id).NotNull().WithErrorCode("LoginId error code");
        RuleFor(x => x.User.LoginId).NotEmpty().MaximumLength(32).WithErrorCode("LoginId error code");
        RuleFor(x => x.User.TenantId).NotEmpty().MaximumLength(32).WithErrorCode("TenantId error code");

    }
}

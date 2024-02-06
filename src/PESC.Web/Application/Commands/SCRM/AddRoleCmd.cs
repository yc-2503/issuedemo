using FluentValidation;
using PESC.Web.Application.ViewModels;

namespace PESC.Web.Application.Commands.SCRM;

public class AddRoleCmd : BaseActionCommand
{
    public required UserRoleDto NewRole { get; set; }
}
public class AddRoleCmdValidator : AbstractValidator<AddRoleCmd>
{
    public AddRoleCmdValidator()
    {
        RuleFor(x => x.NewRole.UserRoleId).NotEmpty().MaximumLength(32).WithErrorCode("LoginId error code");
        RuleFor(x => x.NewRole.TenantId).NotEmpty().MaximumLength(32).WithErrorCode("TenantId error code");

    }
}
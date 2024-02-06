using FluentValidation;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Domain.Share;

namespace PESC.Web.Application.Commands.SCRM;

public class AssignRoleCmd : BaseActionCommand
{
    public required UserId UserId { get; set; }
    public required IEnumerable<RoleId> Roles { get; set; }

}
public class AssignRoleCmdValidator : AbstractValidator<AssignRoleCmd>
{
    public AssignRoleCmdValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithErrorCode("UserId error code");
        RuleFor(x => x.Roles).NotEmpty().WithErrorCode("Roles error code");

    }
}

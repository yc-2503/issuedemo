using FluentValidation;
using NetCorePal.Extensions.Domain;
using NetCorePal.Extensions.Primitives;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Web.Application.ViewModels;

namespace PESC.Web.Application.Commands.SCRM;

public class UserLoginCmd : ICommand<ResponseData>
{
    public required string TenantId { get; set; }
    public required string LoginId { get; set; }
    public string? Password { get; set; }
}

public class UserLoginCmdValidator : AbstractValidator<UserLoginCmd>
{
    public UserLoginCmdValidator()
    {
        RuleFor(x => x.TenantId).NotEmpty().WithMessage("工厂不能为空").WithErrorCode("code1");
        RuleFor(x => x.Password).NotEmpty().WithMessage("密码不能为空").WithErrorCode("code1");
    }
}
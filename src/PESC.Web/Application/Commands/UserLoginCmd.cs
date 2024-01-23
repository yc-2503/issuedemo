using FluentValidation;
using NetCorePal.Extensions.Domain;
using NetCorePal.Extensions.Primitives;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Web.Application.ViewModels;

namespace PESC.Web.Application.Commands;

public class UserLoginCmd : BaseActionCommand
{
}

public class UserLoginCmdValidator : AbstractValidator<UserLoginCmd>
{
    public UserLoginCmdValidator()
    {
        RuleFor(x => x.Factory).NotEmpty().WithMessage("工厂不能为空").WithErrorCode("code1");
        RuleFor(x => x.Password).NotEmpty().WithMessage("密码不能为空").WithErrorCode("code1");
    }
}
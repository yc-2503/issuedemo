using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PESC.Web.Application.Commands;

namespace PESC.Web.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class ScrmController(IMediator mediator): ControllerBase
{
    [HttpPost]
    public async Task<ResponseData> LoginByPwd(UserLoginCmd cmd)
    {
       return await mediator.Send(cmd);
    }
    [HttpPost]
    public async Task<ResponseData> AddUser(AddUserCmd cmd)
    {
        return await mediator.Send(cmd);
    }

}
public class UserLoginCmdValidator : AbstractValidator<UserLoginCmd>
{
    public UserLoginCmdValidator()
    {
        RuleFor(x => x.Factory).NotEmpty().WithMessage("工厂不能为空").WithErrorCode("code1");
        RuleFor(x => x.Password).NotEmpty().WithMessage("密码不能为空").WithErrorCode("code1");
    }
}
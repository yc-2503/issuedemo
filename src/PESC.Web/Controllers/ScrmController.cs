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

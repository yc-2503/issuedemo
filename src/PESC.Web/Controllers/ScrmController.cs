using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.Share;
using PESC.Web.Application.Commands.SCRM;
using PESC.Web.Application.Queries;
using PESC.Web.Application.ViewModels;
using PESC.Web.Extensions;
using PESC.Web.QueryConditions;

namespace PESC.Web.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class ScrmController(IMediator mediator, IMapper mapper, IUserQuery userQuery) : ControllerBase
{

    /// <summary>
    /// 使用用户名密码登录
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ResponseData> LoginByPwd(UserLoginCmd cmd)
    {
        //var protector = provider.CreateProtector("Contoso.MyClass.v1");
        //string encrypt = protector.Protect(cmd.Password!);
        //await Console.Out.WriteLineAsync(encrypt);
        //string unencrypt = protector.Unprotect(encrypt);
        //await Console.Out.WriteLineAsync(   unencrypt);
        return await mediator.Send(cmd);
    }
    /// <summary>
    /// 新增用户
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ResponseData<UserId>> AddUser(AddUserCmd cmd)
    {
        return await mediator.Send(cmd);
    }
    /// <summary>
    /// 获取用户详细信息
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ResponseData<UserDto>> GetUser(UserId userId)
    {
        var user = await userQuery.GetUserInfoAsync(userId);
        UserDto userDto = mapper.Map<UserDto>(user);
        return new ResponseData<UserDto>(userDto);
    }
    //删除用户 软删除
    [HttpPost]
    public async Task<ResponseData> DeleteUser(DeleteUserCmd cmd)
    {
        return await mediator.Send(cmd);
    }

    [HttpPost]
    public async Task<ResponseData> UpdateUser(UpdateUserCmd cmd)
    {
        return await mediator.Send(cmd);
    }
    /// <summary>
    /// 根据条件查询用户
    /// </summary>
    /// <param name="queryCondition"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ResponseData<PageResponseData<UserDto>>> FindUsers(UserQueryCondition queryCondition)
    {
        var rsp = await userQuery.PageFindMany(queryCondition);
        PageResponseData<UserDto> prsp =new PageResponseData<UserDto>() {
            Data=mapper.Map<IEnumerable<UserDto>>(rsp.Data),
            PageCount= rsp.PageCount ,
            PageIndex= queryCondition.PageIndex,
            PageSize= queryCondition.PageSize
        };

        return new ResponseData<PageResponseData<UserDto>>(prsp);
    }
    /// <summary>
    /// 新增角色
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ResponseData> AddRole(AddRoleCmd cmd)
    {
        return await mediator.Send(cmd);
    }
    /// <summary>
    /// 给用户分配角色
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ResponseData> AssignRoleToUser(AssignRoleCmd cmd)
    {
        return await mediator.Send(cmd);
    }

}

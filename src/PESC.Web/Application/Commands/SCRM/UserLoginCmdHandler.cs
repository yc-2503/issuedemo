using AutoMapper;
using MediatR;
using NetCorePal.Extensions.Domain;
using NetCorePal.Extensions.Mappers;
using NetCorePal.Extensions.Primitives;
using PESC.Domain.AggregatesModel.OrderAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.Share;
using PESC.Infrastructure.Repositories;
using PESC.Web.Application.Queries;
using PESC.Web.Global;

namespace PESC.Web.Application.Commands.SCRM;

public class UserLoginCmdHandler(IUserQuery userQuery) : ICommandHandler<UserLoginCmd, ResponseData>
{
    public async Task<ResponseData> Handle(UserLoginCmd request, CancellationToken cancellationToken)
    {
        var user = await userQuery.FindSingleAsync(request.TenantId, request.LoginId, true, cancellationToken);
        if (user == null)
        {
            return new ResponseData(false, "用户名或密码错误", RspErrCode.LoginFail);
        }
        if (user.FailCnt > 5)
        {
            return new ResponseData(false, "失败次数过多，禁止登录", RspErrCode.LoginTooMany);
        }
        if (user.LoginByPwd(request.Password!))
        {
            return new ResponseData();
        }
        else
        {
            return new ResponseData(false, "用户名或密码错误", RspErrCode.LoginFail);
        }
    }
}

public class AddUserCmdHandler(IUserQuery userQuery, IUserRepository userRepository, IMapper mapper) : ICommandHandler<AddUserCmd, ResponseData<UserId>>
{
    public async Task<ResponseData<UserId>> Handle(AddUserCmd request, CancellationToken cancellationToken)
    {
        var user = await userQuery.FindSingleAsync(request.TenantId, request.OperatorLoginId, false, cancellationToken);
        if (user == null)
        {
            User newUser = mapper.Map<User>(request.NewUser);
            newUser.InitNewUser(request.OperatorId!);
            newUser = await userRepository.AddAsync(newUser);

            return new ResponseData<UserId>(newUser.Id);
        }
        else
        {
            return new ResponseData<UserId>(1,false, "用户已存在", RspErrCode.UserAlreadyExist);
        }
    }
}

public class UpdateUserCmdHandler(IUserRepository userRepository, IMapper mapper) : ICommandHandler<UpdateUserCmd, ResponseData>
{
    public async Task<ResponseData> Handle(UpdateUserCmd request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(request.User.Id!);
        if (user != null)
        {
            user.UpdateUser(request.OperatorId!, mapper.Map<User>(request.User));
            return new ResponseData();
        }
        else
        {
            return new ResponseData(false, "用户不存在", RspErrCode.UserDoNotExist);
        }
    }
}

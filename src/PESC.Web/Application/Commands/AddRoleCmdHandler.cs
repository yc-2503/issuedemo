using AutoMapper;
using MediatR;
using NetCorePal.Extensions.Primitives;
using NetCorePal.Extensions.Repository;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Infrastructure.Repositories;
using PESC.Web.Application.Queries;
using PESC.Web.Global;
using System.Collections.ObjectModel;

namespace PESC.Web.Application.Commands;

public class AddRoleCmdHandler(RoleQuery roleQuery, IRoleRepository roleRepository, IMapper mapper) : ICommandHandler<AddRoleCmd, ResponseData>
{
    async Task<ResponseData> IRequestHandler<AddRoleCmd, ResponseData>.Handle(AddRoleCmd request, CancellationToken cancellationToken)
    {
        //检查角色是否存在
        var role = await roleQuery.FindRoleAsync(request.TenantId, request.NewRole.UserRoleId, false, cancellationToken);
        if(role ==  null)
        {
            //新增角色
            UserRole newRole = mapper.Map<UserRole>(request.NewRole);
            roleRepository.Add(newRole);
            return new ResponseData();
        }else
        {
            return new ResponseData(false, "角色已存在", 10002);
        }

    }
}
//为用户分配角色处理程序
public class AssignRoleCmdHandler(IRoleRepository roleRepository, IUserQuery userQuery) : ICommandHandler<AssignRoleCmd, ResponseData>
{

    public async Task<ResponseData> Handle(AssignRoleCmd request, CancellationToken cancellationToken)
    {
        
        var user = await userQuery.FindUserAsync(request.UserId);
        if (user == null || user.IsDeleted)
        {
            return new ResponseData(false, "用户不存在", RspErrCode.UserDoNotExist);
        }
        if (user.Roles == null)
        {
            user.Roles = new Collection<UserRole>();
        }
        foreach (var role in request.Roles)
        {
            var userRole = await roleRepository.GetAsync(role);
            if (userRole != null && !userRole.IsDeleted && !user.Roles.Contains(userRole))
            {
                user.Roles.Add(userRole);
            }

        }

        return new ResponseData();
    }
}


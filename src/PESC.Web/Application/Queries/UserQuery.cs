using Microsoft.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.OrderAggregate;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.Share;
using PESC.Infrastructure.Repositories;
using PESC.Web.QueryConditions;

namespace PESC.Web.Application.Queries;

public class UserQuery(ApplicationDbContext applicationDbContext):PageQuery<User,UserQueryCondition>, IUserQuery
{
    /// <summary>
    /// 查询用户
    /// </summary>
    /// <param name="tenantId">租户</param>
    /// <param name="loginId"></param>
    /// <param name="onlyAvaliable"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<User?> FindSingleAsync(string tenantId, string loginId, bool onlyAvaliable = true, CancellationToken cancellationToken = default)
    {
        if(onlyAvaliable)
        {
            return await applicationDbContext.Users.AsNoTracking().
    FirstOrDefaultAsync(p => p.LoginId == loginId && p.TenantId == tenantId && !p.IsDeleted, cancellationToken);
        }
        else
        {
            return await applicationDbContext.Users.AsNoTracking().
    FirstOrDefaultAsync(p => p.LoginId == loginId && p.TenantId == tenantId, cancellationToken);
        }

    }
    public async Task<User?> GetUserInfoAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        return await applicationDbContext.Users.AsNoTracking().Include(c=>c.Roles).FirstOrDefaultAsync(p => p.Id == userId, cancellationToken);
    }
    public override async Task<int> FindManyCountAsync(UserQueryCondition queryCondition)
    {
        var querys = applicationDbContext.Users.AsNoTracking();
        if (queryCondition.TenantId != null)
        {
            querys = querys.Where(x => x.TenantId == queryCondition.TenantId);
        }
        if(queryCondition.LoginId != null)
        {
            querys = querys.Where(x => x.LoginId== queryCondition.LoginId);
        }
        
        if (queryCondition.Department != null)
        {
            querys = querys.Where(x => x.DepartmentId == queryCondition.Department);
        }
        return await querys.CountAsync();
    }
    public override async Task<IEnumerable<User>> FindManyAsync(UserQueryCondition queryCondition)
    {
        var querys = applicationDbContext.Users.AsNoTracking();
        if(queryCondition.TenantId != null)
        {
            querys = querys.Where(x => x.TenantId == queryCondition.TenantId);
        }
        if(queryCondition.LoginId != null)
        {
            querys = querys.Where(x => x.LoginId == queryCondition.LoginId);
        }
        if (queryCondition.Department != null)
        {
            querys = querys.Where(x => x.DepartmentId == queryCondition.Department);
        }
        return await querys.Skip(queryCondition.PageSize * (queryCondition.PageIndex - 1)).ToListAsync();
    }
}

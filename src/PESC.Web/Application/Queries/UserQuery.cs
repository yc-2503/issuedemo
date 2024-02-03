using Microsoft.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.OrderAggregate;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.Share;
using PESC.Infrastructure.Repositories;
using PESC.Web.Application.Commands;

namespace PESC.Web.Application.Queries;

public class UserQuery(ApplicationDbContext applicationDbContext): IUserQuery
{
    /// <summary>
    /// 查询用户
    /// </summary>
    /// <param name="tenantId">租户</param>
    /// <param name="loginId"></param>
    /// <param name="onlyAvaliable"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<User?> FindUserAsync(string tenantId, string loginId, bool onlyAvaliable = true, CancellationToken cancellationToken = default)
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
    public async Task<User?> FindUserAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        return await applicationDbContext.Users.AsNoTracking().Include(c=>c.Roles).FirstOrDefaultAsync(p => p.Id == userId, cancellationToken);
    }
    public async Task<int> FindUsersCountAsync(UserQueryCondition queryCondition)
    {
        var querys = applicationDbContext.Users.AsNoTracking().Skip(queryCondition.PageSize * (queryCondition.PageIndex - 1));
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
    public async Task<IEnumerable<User>> FindUsersAsync(UserQueryCondition queryCondition)
    {
        var querys = applicationDbContext.Users.AsNoTracking().Skip(queryCondition.PageSize*(queryCondition.PageIndex-1));
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
        return await querys.ToListAsync();
    }
}

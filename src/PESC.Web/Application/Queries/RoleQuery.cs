using Microsoft.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Web.QueryConditions;

namespace PESC.Web.Application.Queries;
public class RoleQuery(ApplicationDbContext applicationDbContext): IRoleQuery
{
    /// <summary>
    /// 查询角色
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="userRole">角色名称</param>
    /// <param name="onlyAvaliable"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UserRole?> FindRoleAsync(string tenantId, string userRole, bool onlyAvaliable = true, CancellationToken cancellationToken = default)
    {
        if (onlyAvaliable)
        {
            return await applicationDbContext.Roles.AsNoTracking().
    FirstOrDefaultAsync(p => p.UserRoleId == userRole && p.TenantId == tenantId && !p.IsDeleted, cancellationToken);
        }
        else
        {
            return await applicationDbContext.Roles.AsNoTracking().
    FirstOrDefaultAsync(p => p.UserRoleId == userRole && p.TenantId == tenantId, cancellationToken);
        }

    }
    public async Task<int> FindCountAsync(RoleQueryCondition queryCondition)
    {
        var querys = applicationDbContext.Roles.AsNoTracking();
        if (queryCondition.TenantId != null)
        {
            querys = querys.Where(x => x.TenantId == queryCondition.TenantId);
        }
        if (queryCondition.UserRoleId != null)
        {
            querys = querys.Where(x => x.UserRoleId == queryCondition.UserRoleId);
        }
        return await querys.CountAsync();
    }
    public async Task<IEnumerable<UserRole>> FindManyAsync(RoleQueryCondition queryCondition)
    {
            var querys = applicationDbContext.Roles.AsNoTracking();
        if (queryCondition.TenantId != null)
        {
                querys = querys.Where(x => x.TenantId == queryCondition.TenantId);
            }
        if (queryCondition.UserRoleId != null)
        {
                querys = querys.Where(x => x.UserRoleId == queryCondition.UserRoleId);
            }
        return await querys.OrderBy(x => x.UserRoleId).Skip(queryCondition.PageSize*(queryCondition.PageIndex-1)).Take(queryCondition.PageSize).ToListAsync();
    }
}
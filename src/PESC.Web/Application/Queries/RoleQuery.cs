using Microsoft.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;

namespace PESC.Web.Application.Queries;
public class RoleQuery(ApplicationDbContext applicationDbContext)
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
}
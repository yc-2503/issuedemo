using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Web.QueryConditions;

namespace PESC.Web.Application.Queries;

public interface IRoleQuery: IPageQueryable<UserRole, RoleQueryCondition>
{
    Task<UserRole?> FindRoleAsync(string tenantId, string userRole, bool onlyAvaliable = true, CancellationToken cancellationToken = default);
}

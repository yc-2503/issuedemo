using Microsoft.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.OrderAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;

namespace PESC.Web.Application.Queries;

public class UserQuery(ApplicationDbContext applicationDbContext)
{
    /// <summary>
    /// 查询用户
    /// </summary>
    /// <param name="factory"></param>
    /// <param name="loginId"></param>
    /// <param name="onlyAvaliable"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<User?> QueryUser(string factory, string loginId, bool onlyAvaliable = true, CancellationToken cancellationToken = default)
    {
        if(onlyAvaliable)
        {
            return await applicationDbContext.Users.AsNoTracking().
    FirstOrDefaultAsync(p => p.LoginId == loginId && p.Factory == factory && !p.IsDeleted, cancellationToken);
        }
        else
        {
            return await applicationDbContext.Users.AsNoTracking().
    FirstOrDefaultAsync(p => p.LoginId == loginId && p.Factory == factory, cancellationToken);
        }

    }
}

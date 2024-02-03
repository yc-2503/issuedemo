using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.Share;
using PESC.Web.Application.Commands;

namespace PESC.Web.Application.Queries
{
    public interface IUserQuery
    {
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="tenantId">租户</param>
        /// <param name="loginId"></param>
        /// <param name="onlyAvaliable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<User?> FindUserAsync(string tenantId, string loginId, bool onlyAvaliable = true, CancellationToken cancellationToken = default);
        Task<User?> FindUserAsync(UserId userId, CancellationToken cancellationToken = default);
        Task<int> FindUsersCountAsync(UserQueryCondition queryCondition);
        Task<IEnumerable<User>> FindUsersAsync(UserQueryCondition queryCondition);
    }
}

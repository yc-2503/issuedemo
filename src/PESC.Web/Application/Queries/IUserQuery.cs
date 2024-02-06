using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.Share;
using PESC.Web.QueryConditions;

namespace PESC.Web.Application.Queries;
/// <summary>
/// 用户查询接口，这个接口仅仅是用来做单元测试的，实际上是不需要的
/// </summary>
public interface IUserQuery : IPageQuerator<User, UserQueryCondition>, IPageQueryable<User, UserQueryCondition> 
{
    /// <summary>
    /// 查询用户
    /// </summary>
    /// <param name="tenantId">租户</param>
    /// <param name="loginId"></param>
    /// <param name="onlyAvaliable"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User?> FindSingleAsync(string tenantId, string loginId, bool onlyAvaliable = true, CancellationToken cancellationToken = default);
    Task<User?> GetUserInfoAsync(UserId userId, CancellationToken cancellationToken = default);

}

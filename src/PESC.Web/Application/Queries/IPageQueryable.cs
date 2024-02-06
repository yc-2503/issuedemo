using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Web.Extensions;
using PESC.Web.QueryConditions;

namespace PESC.Web.Application.Queries
{
    public interface IPageQueryable<TEntity,TQCondition> where TQCondition : PageQueryBaseCondition
    {
        Task<int> FindManyCountAsync(TQCondition queryCondition);
        Task<IEnumerable<TEntity>> FindManyAsync(TQCondition queryCondition);
    }
}

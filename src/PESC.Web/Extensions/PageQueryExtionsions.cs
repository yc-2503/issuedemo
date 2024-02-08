using PESC.Web.Application.Queries;
namespace PESC.Web.Extensions;

public static class PageQueryExtionsions
{
    public static async Task<PageResponseData<T>> PageFindMany<T, TQ>(this IPageQueryable<T, TQ> query, TQ queryCondition) where TQ : PageQueryBaseCondition
    {
        int cnt = await query.FindCountAsync(queryCondition);
        var users = await query.FindManyAsync(queryCondition);

        PageResponseData<T> prsp = new PageResponseData<T>();
        prsp.PageSize = queryCondition.PageSize;
        int pageRemind = cnt % queryCondition.PageSize;
        prsp.PageCount = pageRemind > 0 ? cnt / queryCondition.PageSize + 1 : cnt / queryCondition.PageSize;
        prsp.PageIndex = queryCondition.PageIndex;
        prsp.Data = users;
        return prsp;
    }
}

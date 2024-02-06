using PESC.Web.Extensions;

namespace PESC.Web.Application.Queries;

public interface IPageQuerator<T, TQ> where TQ : PageQueryBaseCondition
{
    Task<PageResponseData<T>> PageFindMany(TQ queryCondition);
}

namespace PESC.Web.Extensions;

public class PageResponseData<T> 
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }

    public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();

}

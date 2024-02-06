using System.ComponentModel.DataAnnotations;

namespace PESC.Web.Extensions;

public abstract class PageQueryBaseCondition
{
   // public string? Factory { get; set; }
    public string? OperatorLoginId { get; set; }
    
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
}

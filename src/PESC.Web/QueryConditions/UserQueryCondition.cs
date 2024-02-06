using PESC.Web.Extensions;

namespace PESC.Web.QueryConditions
{
    public class UserQueryCondition : PageQueryBaseCondition
    {
        public string? TenantId { get; set; }
        public string? Department { get; set; }
        public string? LoginId { get; set; }
    }
}

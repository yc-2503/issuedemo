using PESC.Web.Extensions;

namespace PESC.Web.QueryConditions
{
    public class UserQueryCondition : PageQueryBaseCondition
    {
        public string? TenantId { get; set; }
        public string? DepartmentId { get; set; }
        public string? LoginId { get; set; }
    }
}

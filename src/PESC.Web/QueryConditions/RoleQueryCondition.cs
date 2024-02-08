using PESC.Web.Extensions;

namespace PESC.Web.QueryConditions
{
    public class RoleQueryCondition : PageQueryBaseCondition
    {
        public string? TenantId { get; set; }
        public string? UserRoleId { get; set; }
    }
}

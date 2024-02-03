using PESC.Web.Extensions;

namespace PESC.Web.Application.Commands
{
    public class UserQueryCondition : PageQueryBase
    {
        public string? TenantId { get; set; }    
        public string? Department { get; set; }
        public string? LoginId { get; set; }
    }
}

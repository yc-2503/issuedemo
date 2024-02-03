using NetCorePal.Extensions.Domain;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.Extensions;
using PESC.Domain.Share;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
public partial record RoleId : IInt64StronglyTypedId;
public class UserRole : AggregateRoot<RoleId>,IMultiTenant
{
    protected UserRole() { }
    public UserRole(string tenantId, string userRoleId)
    {
        this.TenantId = tenantId;
        this.UserRoleId = userRoleId;
    }
    public string TenantId { get; set; } = string.Empty;
    public string UserRoleId { get; private set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public Collection<User>? Users { get; set; }
    public DateTime CreationTime { get; set; }
    public string CreatorId { get; set; } = string.Empty;
    public DateTime? LastModificationTime { get; set; }
    public string? LastModifierId { get; set; }
}


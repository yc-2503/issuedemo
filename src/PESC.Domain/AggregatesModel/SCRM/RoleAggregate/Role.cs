using NetCorePal.Extensions.Domain;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.Share;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
public partial record RoleId : IInt64StronglyTypedId;
public class Role : Entity<RoleId>, IAggregateRoot
{
    protected Role() { }
    public Role(string factory,string roleName)
    {
        this.Factory = factory;
        this.RoleName = roleName;
    }
    public string Factory { get; private set; } = string.Empty;
    public string RoleName { get; private set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public Collection<User>? Users { get; set; }
    public DateTime CreationTime { get; set; }
    public UserId? CreatorId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public UserId? LastModifierId { get; set; }
}


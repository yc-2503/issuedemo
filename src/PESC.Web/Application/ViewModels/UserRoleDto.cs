namespace PESC.Web.Application.ViewModels;
public class UserRoleDto
{
    public string TenantId { get; private set; } = string.Empty;
    public string UserRoleId { get; private set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public DateTime CreationTime { get; set; }
    public string CreatorId { get; set; } = string.Empty;
    public DateTime? LastModificationTime { get; set; }
    public string? LastModifierId { get; set; }
}
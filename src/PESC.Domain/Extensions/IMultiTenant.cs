namespace PESC.Domain.Extensions;


public interface IMultiTenant
{
    public string TenantId { get; set; }//租户Id
}


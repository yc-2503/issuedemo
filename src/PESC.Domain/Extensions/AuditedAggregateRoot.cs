using NetCorePal.Extensions.Domain;
using PESC.Domain.Share;


namespace PESC.Domain.Extensions;
public abstract class AuditedAggregateRoot<TKey> : AggregateRoot<TKey> where TKey : notnull
{
    public DateTime CreationTime { get; set; }
    public UserId? CreatorId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public UserId? LastModifierId { get; set; }
}


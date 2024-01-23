using NetCorePal.Extensions.Domain;
using PESC.Domain.AggregatesModel.OrderAggregate;

namespace PESC.Domain.DomainEvents
{
    public record OrderCreatedDomainEvent(Order Order) : IDomainEvent;
}

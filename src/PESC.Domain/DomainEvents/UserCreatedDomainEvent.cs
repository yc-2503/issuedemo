using NetCorePal.Extensions.Domain;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;

namespace PESC.Domain.DomainEvents;

public record UserCreatedDomainEvent(User User) : IDomainEvent;

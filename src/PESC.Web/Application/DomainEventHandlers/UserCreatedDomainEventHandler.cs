using MediatR;
using NetCorePal.Extensions.Domain;
using PESC.Domain.DomainEvents;
using PESC.Web.Application.Commands;

namespace PESC.Web.Application.DomainEventHandlers;

internal class UserCreatedDomainEventHandler(IMediator mediator) : IDomainEventHandler<UserCreatedDomainEvent>
{
    public Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        //throw new NotImplementedException();
       // return mediator.Send(new DeliverGoodsCommand(notification.Order.Id), cancellationToken);
       return Task.CompletedTask;   
    }
}

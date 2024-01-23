using PESC.Domain.AggregatesModel.OrderAggregate;

namespace PESC.Web.Application.IntegrationEventHandlers
{
    public record OrderPaidIntegrationEvent(OrderId OrderId);
}

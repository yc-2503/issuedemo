using PESC.Domain.AggregatesModel.DeliverAggregate;
using PESC.Domain.AggregatesModel.OrderAggregate;
using NetCorePal.Extensions.Primitives;

namespace PESC.Web.Application.Commands
{
    public record DeliverGoodsCommand(OrderId OrderId) : ICommand<DeliverRecordId>;
}

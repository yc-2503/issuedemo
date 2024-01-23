using PESC.Domain.AggregatesModel.OrderAggregate;
using NetCorePal.Extensions.Primitives;

namespace PESC.Web.Application.Commands
{
    public record CreateOrderCommand(string Name, int Price, int Count) : ICommand<OrderId>;
}

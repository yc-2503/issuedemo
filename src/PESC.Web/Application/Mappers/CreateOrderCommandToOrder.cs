using PESC.Domain.AggregatesModel.OrderAggregate;
using PESC.Web.Application.Commands;
using NetCorePal.Extensions.Mappers;

namespace PESC.Web.Application.Mappers
{
    public class CreateOrderCommandToOrder : IMapper<CreateOrderCommand, Order>
    {
        public Order To(CreateOrderCommand from)
        {
            return new Order(from.Name, from.Count);
        }
    }
}

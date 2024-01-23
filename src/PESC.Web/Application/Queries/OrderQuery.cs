using PESC.Domain;
using PESC.Domain.AggregatesModel.OrderAggregate;
using PESC.Infrastructure;
using System.Threading;

namespace PESC.Web.Application.Queries
{
    public class OrderQuery(ApplicationDbContext applicationDbContext)
    {
        public async Task<Order?> QueryOrder(OrderId orderId, CancellationToken cancellationToken)
        {
            return await applicationDbContext.Orders.FindAsync(new object[] { orderId }, cancellationToken);
        }
    }
}

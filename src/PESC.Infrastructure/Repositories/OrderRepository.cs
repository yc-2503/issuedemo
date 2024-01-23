using NetCorePal.Extensions.Repository.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.OrderAggregate;
using NetCorePal.Extensions.Repository;

namespace PESC.Infrastructure.Repositories;


public interface IOrderRepository : IRepository<Order, OrderId>
{

}


public class OrderRepository(ApplicationDbContext context) :
    RepositoryBase<Order, OrderId, ApplicationDbContext>(context), IOrderRepository
{
}

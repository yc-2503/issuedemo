using NetCorePal.Extensions.Repository.EntityFrameworkCore;
using NetCorePal.Extensions.Repository;
using PESC.Domain.AggregatesModel.DeliverAggregate;

namespace PESC.Infrastructure.Repositories
{
    public interface IDeliverRecordRepository : IRepository<DeliverRecord, DeliverRecordId>
    {

    }

    public class DeliverRecordRepository(ApplicationDbContext context) : 
        RepositoryBase<DeliverRecord, DeliverRecordId, ApplicationDbContext>(context), IDeliverRecordRepository
    {
    }
}

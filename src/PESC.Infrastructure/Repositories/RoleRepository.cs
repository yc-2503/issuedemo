using NetCorePal.Extensions.Repository;
using NetCorePal.Extensions.Repository.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.OrderAggregate;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;

namespace PESC.Infrastructure.Repositories;
public interface IRoleRepository : IRepository<UserRole, RoleId>
{

}

public class RoleRepository(ApplicationDbContext context) :
    RepositoryBase<UserRole, RoleId, ApplicationDbContext>(context),IRoleRepository
{

}


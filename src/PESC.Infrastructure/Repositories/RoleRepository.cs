using NetCorePal.Extensions.Repository.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;

namespace PESC.Infrastructure.Repositories;

public class RoleRepository(ApplicationDbContext context) :
    RepositoryBase<Role, RoleId, ApplicationDbContext>(context)
{

}


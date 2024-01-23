using NetCorePal.Extensions.Repository.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.Share;

namespace PESC.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) :
    RepositoryBase<User, UserId, ApplicationDbContext>(context)
{
}


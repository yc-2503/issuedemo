using NetCorePal.Extensions.Repository;
using NetCorePal.Extensions.Repository.EntityFrameworkCore;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Domain.Share;

namespace PESC.Infrastructure.Repositories;
public interface IUserRepository : IRepository<User, UserId>
{

}
public class UserRepository(ApplicationDbContext context) :
    RepositoryBase<User, UserId, ApplicationDbContext>(context), IUserRepository
{
}


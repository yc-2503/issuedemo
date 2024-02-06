using AutoMapper;
using PESC.Web.Application.ViewModels;
using PESC.Web.Extensions;
using PESC.Web.QueryConditions;

namespace PESC.Web.Application.Queries
{
    public class PageQuery<T,TQ>:IPageQuerator<T,TQ>, IPageQueryable<T, TQ> where TQ : PageQueryBaseCondition
    {
        public virtual Task<IEnumerable<T>> FindManyAsync(TQ queryCondition)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> FindManyCountAsync(TQ queryCondition)
        {
            throw new NotImplementedException();
        }

        public async Task<PageResponseData<T>> PageFindMany(TQ queryCondition)
        {
            int cnt = await FindManyCountAsync(queryCondition);
            var users = await FindManyAsync(queryCondition);

          //  IEnumerable<UserDto> usersDto = mapper.Map<IEnumerable<UserDto>>(users);

            PageResponseData<T> prsp = new PageResponseData<T>();
            prsp.PageSize = queryCondition.PageSize;
            int pageRemind = cnt%queryCondition.PageSize;
            prsp.PageCount = pageRemind>0? (cnt / queryCondition.PageSize+1): cnt / queryCondition.PageSize;
            prsp.PageIndex = queryCondition.PageIndex;
            prsp.Data = users;
            return prsp;
        }
    }
}

using AutoMapper;
using NetCorePal.Extensions.Primitives;
using PESC.Domain.Share;
using PESC.Infrastructure.Repositories;
using PESC.Web.Global;

namespace PESC.Web.Application.Commands.SCRM;

public class DeleteUserCmd : BaseActionCommand<UserId>
{
    public required UserId UserId { get; set; }

}

public class DeleteUserCmdHandler(IUserRepository userRepository, IMapper mapper) : ICommandHandler<DeleteUserCmd, ResponseData>
{
    public async Task<ResponseData> Handle(DeleteUserCmd request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(request.UserId!);
        if (user != null)
        {
            user.DeleteUser(request.OperatorId!);
            return new ResponseData();
        }
        else
        {
            return new ResponseData(false, "用户不存在", RspErrCode.UserDoNotExist);
        }
    }
}
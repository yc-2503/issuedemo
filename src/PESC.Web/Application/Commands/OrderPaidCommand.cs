using NetCorePal.Extensions.Primitives;

namespace PESC.Web.Application.Commands
{
    public record class OrderPaidCommand(long OrderId) : ICommand;
}

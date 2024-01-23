using PESC.Domain.AggregatesModel.OrderAggregate;
using PESC.Web.Application.Commands;
using PESC.Web.Application.IntegrationEventHandlers;
using PESC.Web.Application.Queries;
using DotNetCore.CAP;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCorePal.Extensions.DistributedTransactions.Sagas;
using NetCorePal.Extensions.Domain;

namespace PESC.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IMediator mediator, OrderQuery orderQuery, ICapPublisher capPublisher) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

        [HttpPost]
        public async Task<OrderId> Post([FromBody] CreateOrderCommand command)
        {
            var id = await mediator.Send(command);
            return id;
        }


        [HttpGet]
        [Route("/get/{id}")]
        public async Task<ResponseData<Order?>> GetById([FromRoute] OrderId id)
        {
            var order = await orderQuery.QueryOrder(id, HttpContext.RequestAborted).AsResponseData();
            return order;
        }


        [HttpGet]
        [Route("/sendEvent")]
        public async Task SendEvent(OrderId id)
        {
            await capPublisher.PublishAsync("OrderPaidIntegrationEvent", new OrderPaidIntegrationEvent(id));
        }
    }
    
}
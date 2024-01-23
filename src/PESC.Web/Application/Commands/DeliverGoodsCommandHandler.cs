﻿using PESC.Domain.AggregatesModel.DeliverAggregate;
using PESC.Infrastructure.Repositories;
using NetCorePal.Extensions.Primitives;

namespace PESC.Web.Application.Commands
{
    public class DeliverGoodsCommandHandler(IDeliverRecordRepository deliverRecordRepository) : ICommandHandler<DeliverGoodsCommand, DeliverRecordId>
    {
        public Task<DeliverRecordId> Handle(DeliverGoodsCommand request, CancellationToken cancellationToken)
        {
            var record = new DeliverRecord(request.OrderId);
            deliverRecordRepository.Add(record);
            return Task.FromResult(record.Id);
        }
    }
}

using DemandManagement.MessageContracts;
using MassTransit;
using System;

namespace DemandManagement.Thirdparty.Service
{
    public class DemandRegisteredEventConsumer : IConsumer<IRegisteredDemandEvent>
    {
        public async Task Consume(ConsumeContext<IRegisteredDemandEvent> context)
        {
            var demandId = context.Message.DemandId;
            await Console.Out.WriteLineAsync($"Thirdparty integratin done. Demand Id: {demandId}");
        }
    }
}
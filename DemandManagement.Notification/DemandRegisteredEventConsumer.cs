using DemandManagement.MessageContracts;
using MassTransit;
using System;

namespace DemandManagement.Notification
{
    public class DemandRegisteredEventConsumer : IConsumer<IRegisteredDemandEvent>
    {
        public async Task Consume(ConsumeContext<IRegisteredDemandEvent> context)
        {
            var demandId = context.Message.DemandId;
            await Console.Out.WriteLineAsync($"Notification sent: Demand Id: {demandId}");
        }
    }
}
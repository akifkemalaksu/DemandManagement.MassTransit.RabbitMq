using DemandManagement.MessageContracts;
using MassTransit;
using System;

namespace DemandManagement.Registration
{
    internal class RegisterDemandCommandConsumer : IConsumer<IRegisterDemandCommand>
    {
        public Task Consume(ConsumeContext<IRegisterDemandCommand> context)
        {
            var message = context.Message;
            var guid = Guid.NewGuid();
            Console.WriteLine($"Demand registered. Subject: {message.Subject}, Description: {message.Description}, Id: {guid}");
            context.Publish<IRegisteredDemandEvent>(new
            {
                DemandId = guid
            });
            return Task.CompletedTask;
        }
    }
}
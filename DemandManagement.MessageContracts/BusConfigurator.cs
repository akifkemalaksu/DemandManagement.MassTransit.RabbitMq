using MassTransit;
using System;

namespace DemandManagement.MessageContracts
{
    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host(new Uri(RabbitMqConstants.Uri), host =>
                {
                    host.Username(RabbitMqConstants.Username);
                    host.Password(RabbitMqConstants.Password);
                });

                registrationAction?.Invoke(config);
            });
        }
    }
}
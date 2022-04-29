using DemandManagement.MessageContracts;
using DemandManagement.Thirdparty.Service;
using MassTransit;

Console.Title = "ThirdParty";

var bus = BusConfigurator.ConfigureBus(config =>
{
    config.ReceiveEndpoint(RabbitMqConstants.ThirdPartyServiceQueueName, endPoint =>
    {
        endPoint.Consumer<DemandRegisteredEventConsumer>();
        endPoint.UseRateLimit(1000, TimeSpan.FromMinutes(1));
    });
});

bus.StartAsync();

Console.WriteLine(@"
    Listening for demand registered events...
    Press enter to exit.
");
Console.ReadLine();

bus.StopAsync();
using DemandManagement.MessageContracts;
using DemandManagement.Notification;
using MassTransit;

Console.Title = "Notification";

var bus = BusConfigurator.ConfigureBus(config =>
{
    config.ReceiveEndpoint(RabbitMqConstants.NotificationServiceQueueName, endPoint =>
    {
        endPoint.Consumer<DemandRegisteredEventConsumer>();
        endPoint.UseMessageRetry(retry => retry.Immediate(5));
    });
});

bus.StartAsync();

Console.WriteLine(@"
    Listening for demand registered events...
    Press enter to exit.
");
Console.ReadLine();

bus.StopAsync();
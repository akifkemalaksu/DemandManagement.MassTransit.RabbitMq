using DemandManagement.MessageContracts;
using DemandManagement.Registration;
using MassTransit;

Console.Title = "Registration";

var bus = BusConfigurator.ConfigureBus(config =>
{
    config.ReceiveEndpoint(RabbitMqConstants.RegisterDemandServiceQueueName, endPoint =>
        {
            endPoint.Consumer<RegisterDemandCommandConsumer>();
            endPoint.UseCircuitBreaker(circuitBreaker =>
            {
                circuitBreaker.TrackingPeriod = TimeSpan.FromMinutes(1);
                circuitBreaker.TripThreshold = 15;
                circuitBreaker.ActiveThreshold = 10;
                circuitBreaker.ResetInterval = TimeSpan.FromMinutes(5);
            });
        });
});

bus.StartAsync();

Console.WriteLine(@"
    Listening for register demand commands...
    Press enter to exit.
");
Console.ReadLine();

bus.StopAsync();
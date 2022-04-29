namespace DemandManagement.MessageContracts
{
    public static class RabbitMqConstants
    {
        /*
         *  docker run -d --hostname my-rabbit --name myrabbit -e RABBITMQ_DEFAULT_USER=guest -e RABBITMQ_DEFAULT_PASS=123456 -p 5672:5672 -p 15672:15672 rabbitmq:3-management
         *  
         *  virtualHost'a demand eklemeyi unutma!!!
         */

        public const string Uri = "rabbitmq://localhost/demand/";
        public const string Username = "guest";
        public const string Password = "123456";

        public const string RegisterDemandServiceQueueName = "registerdemand.service";
        public const string NotificationServiceQueueName = "notification.service";
        public const string ThirdPartyServiceQueueName = "thirdparty.service";
    }
}
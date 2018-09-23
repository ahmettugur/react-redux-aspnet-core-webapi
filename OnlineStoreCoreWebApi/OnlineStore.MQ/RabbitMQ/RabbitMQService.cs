using System;
using OnlineStore.Utilities;
using RabbitMQ.Client;

namespace OnlineStore.MQ.RabbitMQ
{
    public class RabbitMQService
    {
        private readonly string messageQueueHostName="";
        public RabbitMQService()
        {
            messageQueueHostName = AppSettingsHelper.GetAppSettings("MessageQueueHostName");
        }
 
        public IConnection CreateConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = messageQueueHostName
            };
 
            return connectionFactory.CreateConnection();
        }
    }
}

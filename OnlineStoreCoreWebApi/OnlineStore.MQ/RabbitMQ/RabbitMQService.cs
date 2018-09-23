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
                // RabbitMQ'nun bağlantı kuracağı host'u tanımlıyoruz. Herhangi bir güvenlik önlemi koymak istersek, Management ekranından password adımlarını tanımlayıp factory içerisindeki "UserName" ve "Password" property'lerini set etmemiz yeterlidir.
                HostName = messageQueueHostName
            };
 
            return connectionFactory.CreateConnection();
        }
    }
}

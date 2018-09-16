using System;
using System.Text;
using Newtonsoft.Json;
using OnlineStore.Core.Contracts.Entities;
using OnlineStore.Utilities;
using RabbitMQ.Client;
using System.IO;


namespace OnlineStore.MQ.RabbitMQ
{
    public class RabbitMQEntityPost<TEntity> where TEntity:class,IEntity,new()
    {
        private string _queueName;
        public RabbitMQEntityPost(string queueName)
        {
           _queueName = queueName;
        }
        public string Post(TEntity data)
        {
            string returnValue = "";
            try
            {
                var MessageQueueHostName = AppSettingsHelper.GetAppSettings("MessageQueueHostName");
                var queueName = AppSettingsHelper.GetAppSettings(_queueName);
                var factory = new ConnectionFactory() { HostName = MessageQueueHostName };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: queueName,
                                            durable: false,
                                            exclusive: false,
                                            autoDelete: false,
                                            arguments: null);
            
                        var queueDate = JsonConvert.SerializeObject(data);
                        var body = Encoding.UTF8.GetBytes(queueDate);
            
                        channel.BasicPublish(exchange: "",
                                            routingKey: queueName,
                                            basicProperties: null,
                                            body: body);

                        returnValue = $"Registration was sent to the {queueName} queue.";
                        Console.WriteLine(returnValue);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return $"[x] Sent {returnValue}";

        }
    }
}

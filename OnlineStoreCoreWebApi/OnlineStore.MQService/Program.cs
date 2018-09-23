using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using OnlineStore.Utilities;
using OnlineStore.Entity.Concrete;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using OnlineStore.MQ.RabbitMQ;

namespace OnlineStore.MQService
{
    class Program
    {
        static HubConnection connectionSignalR;
        static void Main(string[] args)
        {
            Connect().Wait();
            
            var rabbitMQService = new RabbitMQService();

            var queueName = AppSettingsHelper.GetAppSettings("ProductQueue");

            using (var connection = rabbitMQService.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //Connect().Wait();
                    channel.QueueDeclare(queue: queueName,
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);
    
                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var data = Encoding.UTF8.GetString(body);
                        Product product = JsonConvert.DeserializeObject<Product>(data);
                        
                        connectionSignalR.InvokeAsync("PushNotify", product);
                        Console.WriteLine(" Received message: "+ product.Name + " : " + product.Price);
                    };

                    channel.BasicConsume(queue: queueName,
                    autoAck: true,
                    consumer: consumer);

                    Console.ReadLine();
                }
            }
        }
        public static async Task Connect()
        {
            string HubConnectionUrl = AppSettingsHelper.GetAppSettings("HubConnection");
             connectionSignalR = new HubConnectionBuilder()
                .WithUrl(HubConnectionUrl)
                .Build();   
            await connectionSignalR.StartAsync();           
        }        
    }
}

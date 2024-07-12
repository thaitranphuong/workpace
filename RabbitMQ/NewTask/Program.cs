using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace NewTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "armadillo-01.rmq.cloudamqp.com",
                UserName = "ktsxxpei",
                Password = "NICIxab_JSihP4QQnfkJWZjqnCFFD8s9",
                VirtualHost = "ktsxxpei",
                Port = 5672
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "topic_logs", type: ExchangeType.Topic);

            channel.ConfirmSelect();

            channel.BasicAcks += (sender, ea) =>
            {
                Console.WriteLine("Đã nhận được xác nhận từ RabbitMQ cho delivery tag {0}", ea.DeliveryTag);
            };

            channel.BasicNacks += (sender, ea) =>
            {
                Console.WriteLine("Đã nhận được xác nhận từ RabbitMQ cho delivery tag {0}, nhưng không thành công", ea.DeliveryTag);
            };

            var messages = new string[] {
                "First......",
                "Second.....",
                "Third......",
                "Fourth.....",
                "Fifth......"
            };

            Thread.Sleep(2000);
            foreach (var m in messages)
            {
                var message = GetMessage(new string[] { m });

                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "topic_logs",
                                     routingKey: "ok.ok.ok",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($" [x] Sent {message}");

                //if (channel.WaitForConfirms(TimeSpan.FromSeconds(5)))
                //{
                //    Console.WriteLine("Tin nhắn đã được gửi thành công và nhận được xác nhận từ RabbitMQ.");
                //}
                //else
                //{
                //    Console.WriteLine("Có lỗi xảy ra khi gửi tin nhắn hoặc không nhận được xác nhận từ RabbitMQ.");
                //}
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}

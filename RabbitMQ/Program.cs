using RabbitMQ.Client;
using System;
using System.Threading.Tasks;

namespace RabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var cf = new ConnectionFactory()
            {
                HostName = "52.67.172.53",
                Port = AmqpTcpEndpoint.UseDefaultPort,
                Protocol = Protocols.DefaultProtocol,
                RequestedConnectionTimeout = 2000, // fail the test early
                VirtualHost = "tf-vhost",
                UserName = "tradeforce",
                Password = "tf2017"
            };

            using (var con = cf.CreateConnection())
                Console.WriteLine("Connected Sync");

            Task.Run(() =>
            {
                using (var con = cf.CreateConnection())
                    Console.WriteLine("Connected async");
            });

            Console.ReadLine();
        }
    }
}

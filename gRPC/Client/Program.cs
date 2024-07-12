using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Don't use IIS to run server
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "World" });

            Console.WriteLine("Greeting: " + reply.Message);
            Console.ReadKey();
        }

    }
}

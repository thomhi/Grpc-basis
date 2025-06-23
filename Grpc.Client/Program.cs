using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Shared;

var channel = GrpcChannel.ForAddress("https://localhost:7016");

var greeterClient = new Greeter.GreeterClient(channel);

var reply = await greeterClient.SayHelloAsync(new HelloRequest { Name = "YourName" });

Console.WriteLine(reply.Message);

// ---------- Streaming ----------

var mathClient = new Grpc.Shared.Math.MathClient(channel);

using var fibRes = mathClient.GetFibonacci(new FromTo { From = 1, To = 5000 });

await foreach (var fib in fibRes.ResponseStream.ReadAllAsync())
{
    Console.WriteLine(fib.ToString());
}
using Grpc.Net.Client;
using Grpc.Shared;

var channel = GrpcChannel.ForAddress("https://localhost:7016");

var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(new HelloRequest { Name = "YourName" });

Console.WriteLine(reply.Message);
using Grpc.Service;
using Grpc.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MathAlgorithms>();

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<GreeterService>();
app.MapGrpcService<MathService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

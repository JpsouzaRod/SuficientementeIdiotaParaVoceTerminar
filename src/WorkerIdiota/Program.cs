
using WorkerIdiota.Service;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddHostedService<ConsumerKafka>();

var host = builder.Build();

host.Run();
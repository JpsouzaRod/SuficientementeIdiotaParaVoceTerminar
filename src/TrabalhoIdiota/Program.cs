using TrabalhoIdiota.Adapter.MongoDB.Configuration;
using TrabalhoIdiota.Adapter.Redis.Configuration;
using TrabalhoIdiota.Adapter.SQL.Configuration;
using TrabalhoIdiota.Endpoint;
using TrabalhoIdiota.Infra;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "my-redis";
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDomainServices();
builder.Services.AddDatabases();
builder.Services.AddMongo();
builder.Services.AddRedisCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.UseReDoc(c =>
    {
        c.DocumentTitle = "REDOC API Documentation";
        c.SpecUrl = "/swagger/v1/swagger.json";
    });
}

app.AddEndpoints();

app.Run();

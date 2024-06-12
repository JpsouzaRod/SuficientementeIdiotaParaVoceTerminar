using TrabalhoIdiota.Adapter.Kafka.Service;
using TrabalhoIdiota.Domain.Application.Interface;
using TrabalhoIdiota.Domain.Application.Service;
using TrabalhoIdiota.Domain.Application.Usecase;

namespace TrabalhoIdiota.Infra
{
    public static class DomainExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services) 
        {
            //services.AddScoped<IKafkaProducer, KafkaProducer>();
            services.AddScoped<IService, Service>();
            services.AddScoped<IUsecase, Usecase>();

            return services;
        }
    }
}

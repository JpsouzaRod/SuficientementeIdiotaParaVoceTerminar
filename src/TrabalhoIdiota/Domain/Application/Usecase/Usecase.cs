using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Text.Json;
using TrabalhoIdiota.Domain.Application.Interface;
using TrabalhoIdiota.Domain.Application.Interface.Database;
using TrabalhoIdiota.Domain.Core;

namespace TrabalhoIdiota.Domain.Application.Usecase
{
    public class Usecase : IUsecase
    {
        public Usecase(IServiceProvider service)
        {
            _service = service.GetService<IService>();
            _repository = service.GetService<ISQLRepository>();
            _mongo = service.GetService<IMongoRepository>();
            _redis = service.GetService<IRepositoryCache>();
            //_producerKafka =  service.GetService<IKafkaProducer>();

        }

        private IService _service;
        private ISQLRepository _repository;
        private IMongoRepository _mongo;
        private IRepositoryCache _redis;
        private IKafkaProducer _producerKafka;

        public string GetHelloWorld()
        {
            return _service.GetHelloWorld();
        }

        public string GetName(string name)
        {
            try
            {
                var NameInCache = _redis.GetAsync(name);

                if (!NameInCache.Result.IsNullOrEmpty())

                    return JsonSerializer.Deserialize<Pessoa>(NameInCache.Result).Nome;

                var result = _mongo.GetName(name);
                _redis.SetAsync(name, JsonSerializer.Serialize(result));

                return result.Nome;
            }
            catch(Exception ex)
            {
                return "nao foi possivel finalizar essa operacao";
            }
        }

        public List<Pessoa> ListName()
        {
            var listNamesInCache = _redis.GetAsync("lista");

            if (!listNamesInCache.Result.IsNullOrEmpty())

                return JsonSerializer.Deserialize<List<Pessoa>>(listNamesInCache.Result);
            
            var listName =  _mongo.ListName();
            _redis.SetAsync("lista", JsonSerializer.Serialize(listName));

            return listName;
        }

        public void PostName(Pessoa pessoa)
        {
            _mongo.PostName(pessoa);
            //_producerKafka.ProduceMessage(pessoa);
        }

        public void DeleteName(string name)
        {
            _mongo.DeleteName(name);
        }



    }
}

using TrabalhoIdiota.Domain.Core;

namespace TrabalhoIdiota.Domain.Application.Interface
{
    public interface IKafkaProducer
    {
        public void ProduceMessage(Pessoa pessoa);
    }
}

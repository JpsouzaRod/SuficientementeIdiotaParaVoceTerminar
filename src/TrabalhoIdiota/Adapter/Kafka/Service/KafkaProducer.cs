using Confluent.Kafka;
using System.Text.Json;
using TrabalhoIdiota.Domain.Application.Interface;
using TrabalhoIdiota.Domain.Core;

namespace TrabalhoIdiota.Adapter.Kafka.Service
{
    public class KafkaProducer : IKafkaProducer
    {
        public void ProduceMessage(Pessoa pessoa)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = "pkc-12pd3.brazilsouth.azure.confluent.cloud:9092",
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslUsername = "H26MUKKC2MMSOIGY",
                SaslPassword = "TxbccIzDVHc/Y/h+AXkUpa9y/MA05taNqW3qxTFE9JIvvy71GSZhtp3bdBJJ2Orn"
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            string topic = "my-topic"; // Replace with your topic name
            string message = $"Hello, {pessoa.Nome}";
            var deliveryReport = producer.ProduceAsync(topic, new Message<Null, string> { Value = message }).Result;
            Console.WriteLine($"Produced message to {deliveryReport.Topic} partition {deliveryReport.Partition} @ offset {deliveryReport.Offset}");
            producer.Flush();
        }
    }
}

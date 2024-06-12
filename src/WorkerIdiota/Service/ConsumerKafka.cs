
using Confluent.Kafka;

namespace WorkerIdiota.Service
{
    public class ConsumerKafka : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig()
            {
                BootstrapServers = "pkc-12pd3.brazilsouth.azure.confluent.cloud:9092",
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslUsername = "H26MUKKC2MMSOIGY",
                SaslPassword = "TxbccIzDVHc/Y/h+AXkUpa9y/MA05taNqW3qxTFE9JIvvy71GSZhtp3bdBJJ2Orn",
                GroupId = "my-topic"
            };

            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe("my-topic");

                while(!stoppingToken.IsCancellationRequested)
                {
                    var result = consumer.Consume(stoppingToken).Value;
                    Console.WriteLine(result);
                }
                
                consumer.Close();
            }
        }
    }
}

using Confluent.Kafka;
using OrderApi.Models;
using System.Diagnostics;
using System.Text.Json;

namespace CustomerApi
{
    public class ApacheKafkaConsumerService:IHostedService {
        private readonly string topic = "sports";
        private readonly string groupId = "test-consumer-group";
        private readonly string bootstrapServers = "localhost:9092";

        public Task StartAsync(CancellationToken cancellationToken) {
            var config = new ConsumerConfig {
            GroupId = groupId,
            BootstrapServers = bootstrapServers,
            AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try {
                using(var consumerBuilder = new ConsumerBuilder 
                <Ignore, string> (config).Build()) {
                    consumerBuilder.Subscribe(topic);
                    var cancelToken = new CancellationTokenSource();

                try {
                    while (true) {
                        var consumer = consumerBuilder.Consume 
                           (cancelToken.Token);
                        var orderRequest = JsonSerializer.Deserialize 
                            <Order> 
                                (consumer.Message.Value);
                        Debug.WriteLine($"Processing Order Id:  {orderRequest.CustomerId} {orderRequest.CustomerId}");
                    }
                } catch (OperationCanceledException) {
                    consumerBuilder.Close();
                }
            }
        } catch (Exception ex) {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }

        return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken) {
            return Task.CompletedTask;
        }
    }
}

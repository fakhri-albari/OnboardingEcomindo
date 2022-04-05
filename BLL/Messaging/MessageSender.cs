using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace OnboardingEcomindo.BLL.Messaging
{
    public class MessageSender : IMessageSender
    {
        private EventHubProducerClient producer;
        private EventDataBatch eventBatch;

        public MessageSender(IConfiguration config, string eventHubName)
        {
            //string connectionString = config["EventHub"];
            //Console.WriteLine(connectionString);
            producer = new EventHubProducerClient(config.GetValue<string>("EventHub:ConnectionString"), eventHubName);
        }

        public bool AddMessage(object data)
        {
            string message = JsonConvert.SerializeObject(data);
            return eventBatch.TryAdd(new EventData(new BinaryData(message)));
        }

        public async Task CreateEventBatchAsync()
        {
            eventBatch = await producer.CreateBatchAsync();
        }

        public async Task SendMessage()
        {
            await producer.SendAsync(eventBatch);
        }
    }
}

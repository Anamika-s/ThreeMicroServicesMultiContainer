﻿using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderApi.Models;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        //private ProducerConfig _config;
        //public ProducerController(ProducerConfig config)
        //{

        //    _config = config;
        //}
        //[HttpPost("send")]
        //public async Task<ActionResult> Get(string topic, Order order)
        //{
        //    string serializedObj = JsonConvert.SerializeObject(order);

        //    using (var producer = new ProducerBuilder<Null, string>(_config).Build())
        //    {
        //        await producer.ProduceAsync(topic, new Message<Null, string> { Value = serializedObj });
        //        producer.Flush(TimeSpan.FromSeconds(10));
        //        return Ok(true);
        //    }

        //}

        private readonly string
        bootstrapServers = "localhost:9092";
        private readonly string topic = "sports";

        [HttpPost]
        public async Task<IActionResult>
        Post([FromBody] Order orderRequest)
        {
            string message =  JsonConvert.SerializeObject(orderRequest);
            return Ok(await SendOrderRequest(topic, message));
        }
        private async Task<bool> SendOrderRequest
        (string topic, string message)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ClientId = Dns.GetHostName()
            };

            try
            {
                using (var producer = new ProducerBuilder
                <Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync
                    (topic, new Message<Null, string>
                    {
                        Value = message
                    });

                    Debug.WriteLine($"Delivery Timestamp:{ result.Timestamp.UtcDateTime}            ");
                return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            return await Task.FromResult(false);
        }
    }
}


//using Confluent.Kafka;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using KafkaNET;

//namespace CustomerApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ConsumerController : ControllerBase
//    {
//        private ConsumerConfig _config;
//        public ConsumerController(ConsumerConfig config)
//        {

//            _config = config;
//        }
//        [HttpGet("getorder")]
//        public async Task<ActionResult> Get(string topic)
//        {
//            //string serializedObj = JsonConvert.SerializeObject(order);

//            _config.GroupId = "test-consumer-group";
//            //Uri uri = new Uri(@"http://localhost:9092");
//           ) 
            
//            using (var consumer = new ConsumerBuilder<Null, string>(_config).Build())
//            {

//                consumer.Subscribe(topic);
//                while (true)
//                {
//                    var msg = consumer.Consume();

//                    return Ok(msg);
//                }

//            }
//        }
//    }
//}
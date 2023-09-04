using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderApi.Models;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> orders;
        public OrderController() {
            var dbHost = "localhost";
            var dbName = "orderDb";
            //var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            //var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            var databaseName = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            orders = databaseName.GetCollection<Order>("order");

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await orders.Find(Builders<Order>.Filter.Empty).ToListAsync();
        }
        [HttpPost]

        public async Task<ActionResult> Create(Order order)
        {
            await orders.InsertOneAsync(order);
            return Ok();

        }


        [HttpPut("{orderId}")]
     public async Task<ActionResult> Update(Order order)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrderId,order.OrderId);
            await orders.ReplaceOneAsync(filter, order);
            return Ok();

        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> Delete(string orderId)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrderId, orderId);
            await orders.DeleteOneAsync(filter);
            return Ok();

        }
    }

}

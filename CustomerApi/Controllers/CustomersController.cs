using CustomerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 using CustomerApi.Service;
using CustomerApi;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _service;
        //private readonly ApacheKafkaConsumerService _s;
        public CustomersController(CustomerService service)

        {
            _service = service;
            
             
        }

        [HttpGet]
        public IActionResult Get()
        {
            //_s.StartAsync();
            return Ok(_service.GetCustomers());
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(_service.GetProductById(id));
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer product)
        {

            return Ok(_service.UpdateCustomer(id, product));
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)
        {
            return Ok(_service.DeleteCustomer(id));
        }
        [HttpPost]

        public IActionResult Post(Customer product)
        {
            var temp =  _service.AddProduct(product);
            return Created("ok" , temp);
        }



    }
}

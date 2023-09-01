using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Service;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductsController(ProductService service)

        {
            _service = service;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetProducts());
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(_service.GetProductById(id));
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {

            return Ok(_service.UpdateProduct(id, product));
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)
        {
            return Ok(_service.DeleteProduct(id));
        }
        [HttpPost]

        public IActionResult Post(Product product)
        {
            var temp =  _service.AddProduct(product);
            return Created("ok" , temp);
        }



    }
}

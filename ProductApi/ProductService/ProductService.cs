using ProductApi.DAL;
using ProductApi.Models;

namespace ProductApi.Service
{
    public class ProductService
    {
        private readonly IProductRepo _repo;
        public ProductService(IProductRepo repo) {
            _repo = repo;
        }

        public List<Product> GetProducts()
        {
            return _repo.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _repo.GetProductById(id);    
        }
        public Product AddProduct(Product product)
        {
            return _repo.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {

            return _repo.DeleteProduct(id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            return _repo.UpdateProduct(id, product);
        }

    }
}

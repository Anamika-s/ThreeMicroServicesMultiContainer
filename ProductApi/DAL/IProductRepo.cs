using ProductApi.Models;

namespace ProductApi.DAL
{
    public interface IProductRepo
    {
        public Product AddProduct(Product product);
        public Product UpdateProduct(int id, Product product);
        public Product GetProductById(int id);
        public bool DeleteProduct(int id);
        List<Product> GetAll();
    }

}

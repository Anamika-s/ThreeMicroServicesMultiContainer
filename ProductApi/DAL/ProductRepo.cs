using ProductApi.Context;
using ProductApi.Models;

namespace ProductApi.DAL
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductDbContext _context;
        public ProductRepo(ProductDbContext context)
        {
            _context = context;
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            var obj = _context.Products.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                foreach (Product temp in _context.Products)
                {
                    if (temp.Id == id)
                    {
                        temp.Price = product.Price;
                        temp.Qty = product.Price;

                    }
                    _context.SaveChanges();
                }
            }
            return obj;
        }
    }
}

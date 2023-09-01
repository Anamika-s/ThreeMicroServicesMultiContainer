using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> context) : base(context)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

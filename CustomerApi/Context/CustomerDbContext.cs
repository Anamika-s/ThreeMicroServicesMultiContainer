using Microsoft.EntityFrameworkCore;
using CustomerApi.Models;
using System.Collections.Generic;

namespace CustomertApi.Context
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> context) : base(context)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}

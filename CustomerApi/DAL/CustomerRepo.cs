
using CustomerApi.Models;
using CustomertApi.Context;

namespace CustomerApi.DAL
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CustomerDbContext _context;
        public CustomerRepo(CustomerDbContext context)
        {
            _context = context;
        }

        public Customer AddCustomer(Customer product)
        {
            _context.Customers.Add(product);
            _context.SaveChanges();
            return product;
        }

        public bool DeleteCustomer(int id)
        {
            var product = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Customers.Remove(product);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == id);
        }

        public Customer UpdateCustomer(int id, Customer product)
        {
            var obj = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                foreach (Customer temp in _context.Customers)
                {
                    if (temp.Id == id)
                    {
                        temp.Address = product.Address;
                        temp.Mobile = product.Mobile;

                    }
                    _context.SaveChanges();
                }
            }
            return obj;
        }
    }
}

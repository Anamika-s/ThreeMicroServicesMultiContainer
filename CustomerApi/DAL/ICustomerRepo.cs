using CustomerApi.Models;

namespace CustomerApi.DAL
{
    public interface ICustomerRepo
    {
        public Customer AddCustomer(Customer product);
        public Customer UpdateCustomer(int id, Customer product);
        public Customer GetCustomerById(int id);
        public bool DeleteCustomer(int id);
        List<Customer> GetAll();
    }

}

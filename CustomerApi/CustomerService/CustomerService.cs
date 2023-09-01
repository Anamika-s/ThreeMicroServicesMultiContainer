using CustomerApi.DAL;
using CustomerApi.Models;


namespace CustomerApi.Service
{
    public class CustomerService
    {
        private readonly ICustomerRepo _repo;
        public CustomerService(ICustomerRepo repo) {
            _repo = repo;
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetAll();
        }

        public Customer GetProductById(int id)
        {
            return _repo.GetCustomerById(id);    
        }
        public Customer AddProduct(Customer product)
        {
            return _repo.AddCustomer(product);
        }

        public bool DeleteCustomer(int id)
        {

            return _repo.DeleteCustomer(id);
        }

        public Customer UpdateCustomer(int id, Customer product)
        {
            return _repo.UpdateCustomer(id, product);
        }

    }
}

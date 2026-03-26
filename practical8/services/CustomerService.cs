using practical8.models;
using practical8.repositories;
using practical8.utils;


namespace practical8.services
{
    class CustomerService : IDisposable
    {
        private static CustomerService? _instance;
        private static CustomerRepository? _customerRepo;

        private CustomerService() { }

        public static CustomerService GetInstance(CustomerRepository customerRepo)
        {
            if (_instance == null)
            {
                _instance = new CustomerService();
                _customerRepo = customerRepo;
            }
            return _instance;
        }

        public Customer? CreateCustomer(string name, int mobile, string email)
        {
            Customer? newCustomer = new Customer(Utility.GenerateCustomerId(), name, mobile, email);
            newCustomer = _customerRepo?.AddCustomer(newCustomer);
            return newCustomer;
        }

        public Customer? GetCustomer(string custId)
        {
            return _customerRepo?.GetCustomer(custId);
        }

        public IReadOnlyList<Customer>? GetAllCustomers()
        {
            return _customerRepo?.GetAllCustomers();
        }

        public void Dispose()
        {
            _instance = null;
            _customerRepo = null;
        }
    }
}

using sim_cs_practicals.practical8.model;

namespace sim_cs_practicals.practical8.repository
{
    class CustomerRepository
    {
        private List<Customer> _customer = new List<Customer>();

        public void AddCustomer(Customer newAcc)
        {
            _customer.Add(newAcc);
        }

        public Customer? GetCustomer(long custId)
        {
            return _customer.Find((obj) => obj.CustomerId == custId);
        }

        public List<Customer> GetCustomers(string name)
        {
            return _customer.FindAll((obj) => obj.Name.Equals(name));
        }
    }
}

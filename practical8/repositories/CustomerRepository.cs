using practical8.models;

namespace practical8.repositories;

class CustomerRepository
{
    private List<Customer> _customers = new List<Customer>();

    private static CustomerRepository? _instance;
    private CustomerRepository() { }

    public static CustomerRepository GetInstance()
    {
        if (_instance == null)
        {
            _instance = new CustomerRepository();

        }
        return _instance;
    }
    public Customer? AddCustomer(Customer newCust)
    {
        _customers.Add(newCust);
        return GetCustomer(newCust.CustomerId);
    }

    public Customer? GetCustomer(string custId)
    {
        return _customers.Find((obj) => obj.CustomerId.Equals(custId));
    }

    public IReadOnlyList<Customer> GetAllCustomers()
    {
        return _customers.AsReadOnly();
    }
}

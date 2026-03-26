namespace practical8.repositories;

internal class CustomerRepository
{
    #region Fileds

    private List<Customer> _customers = new List<Customer>();

    private static CustomerRepository? _instance;

    #endregion

    #region Constructors

    /// <summary>
    /// This is the private constructor for the class so that no objects can be crated outside of the class and object can be created using GetInstance method which will create only single instance of the class.
    /// </summary>
    private CustomerRepository() { }

    #endregion


    #region Static Methods

    /// <summary>
    /// This method will return the instance of CustomerRepository class following the singleton pattern.
    /// </summary>
    /// <returns>Instance object of CustomerRepository class</returns>
    public static CustomerRepository GetInstance()
    {
        if (_instance == null)
        {
            _instance = new CustomerRepository();

        }
        return _instance;
    }

    #endregion

    #region Methods

    /// <summary>
    /// This method will add new customer to the list of all customers
    /// </summary>
    /// <param name="newCust">New customer that is created</param>
    public Customer? AddCustomer(Customer newCust)
    {
        _customers.Add(newCust);
        return GetCustomer(newCust.CustomerId);
    }

    /// <summary>
    /// This method finds and returns the customer specified by given customer id.
    /// </summary>
    /// <param name="custId">string of customer id to be find</param>
    /// <returns>Customer object if found with given customer id or returns null if not found</returns>
    public Customer? GetCustomer(string custId)
    {
        return _customers.Find((obj) => obj.CustomerId.Equals(custId));
    }


    #endregion
}

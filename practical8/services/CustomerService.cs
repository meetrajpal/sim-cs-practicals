namespace practical8.services;

internal class CustomerService : IDisposable
{
    #region Fields

    private static CustomerService? _instance;
    private static CustomerRepository? _customerRepo;

    #endregion

    #region Constructors

    /// <summary>
    /// This is the private constructor for the class so that no objects can be crated outside of the class and object can be created using GetInstance method which will create only single instance of the class.
    /// </summary>
    private CustomerService() { }

    #endregion

    #region Static Methods

    /// <summary>
    /// This method will return the instance of CustomerService class following the singleton pattern.
    /// </summary>
    /// <param name="customerRepo">Customer repository object for dependency injection</param>
    /// <returns>Instance object of CustomerService class</returns>
    public static CustomerService GetInstance(CustomerRepository customerRepo)
    {
        if (_instance == null)
        {
            _instance = new CustomerService();
            _customerRepo = customerRepo;
        }
        return _instance;
    }

    #endregion

    #region Methods
    /// <summary>
    /// This method will create a new customer.
    /// </summary>
    /// <param name="name">string name of customer</param>
    /// <param name="mobile">integer mobile number of customer</param>
    /// <param name="email">email id of the customer</param>
    /// <returns></returns>
    public Customer? CreateCustomer(string name, int mobile, string email)
    {
        Customer? newCustomer = new Customer(Utility.GenerateCustomerId(), name, mobile, email);
        newCustomer = _customerRepo?.AddCustomer(newCustomer);
        return newCustomer;
    }

    /// <summary>
    /// This method finds and returns the customer specified by given customer id.
    /// </summary>
    /// <param name="custId">string of customer id to be find</param>
    /// <returns>Customer object if found with given customer id or returns null if not found</returns>
    public Customer? GetCustomer(string custId)
    {
        return _customerRepo?.GetCustomer(custId);
    }

    #endregion

    /// <summary>
    /// This method will be called when the object of Account Service is in no longer use and it is being destroyed
    /// </summary>
    public void Dispose()
    {
        _instance = null;
        _customerRepo = null;
    }
}

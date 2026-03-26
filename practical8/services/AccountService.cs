namespace practical8.services;

internal class AccountService : IDisposable
{
    #region Fields

    private static AccountService? _instance;
    private static AccountRepository? _accountRepo;
    private static CustomerRepository? _customerRepo;

    #endregion

    #region Constructors
    /// <summary>
    /// This is the private constructor for the class so that no objects can be crated outside of the class and object can be created using GetInstance method which will create only single instance of the class.
    /// </summary>
    private AccountService() { }

    #endregion

    #region Static Methods

    /// <summary>
    /// This method will return the instance of AccountService class following the singleton pattern.
    /// </summary>
    /// <param name="accountRepo">Account repository object for dependency injection</param>
    /// <param name="customerRepo">Customer repository object for dependency injection</param>
    /// <returns>Instance object of AccountService class</returns>
    public static AccountService GetInstance(AccountRepository accountRepo, CustomerRepository customerRepo)
    {
        if (_instance == null)
        {
            _instance = new AccountService();
            _accountRepo = accountRepo;
            _customerRepo = customerRepo;
        }
        return _instance;
    }

    #endregion

    #region Methods

    /// <summary>
    /// This method will create a new customer
    /// </summary>
    /// <param name="custId">ID of customer for which account is created</param>
    /// <param name="balance">Initital opening balance for account</param>
    /// <param name="accountType">Type of account to be created</param>
    /// <param name="pin">PIN for account access</param>
    /// <returns>New Account created</returns>
    public Account? CreateAccount(string custId, decimal balance, AccountType accountType, int pin)
    {
        Account? newAccount;

        Customer? customer = _customerRepo?.GetCustomer(custId);

        if (customer == null)
        {
            Console.WriteLine($"Can not find customer data with given Customer ID: {custId}");
            return null;
        }
        else
        {
            switch (accountType)
            {
                case AccountType.Savings:
                    newAccount = new SavingsAccount(Utility.GenerateAccountNo(), customer, balance, pin);
                    _accountRepo?.AddAccount(newAccount);
                    break;

                case AccountType.Current:
                    newAccount = new CurrentAccount(Utility.GenerateAccountNo(), customer, balance, pin);
                    _accountRepo?.AddAccount(newAccount);
                    break;

                case AccountType.FixedDeposit:
                    newAccount = new FixedDepositAccount(Utility.GenerateAccountNo(), customer, balance, pin);
                    _accountRepo?.AddAccount(newAccount);
                    break;

                case AccountType.Loan:
                    newAccount = new LoanAccount(Utility.GenerateAccountNo(), customer, balance, pin);
                    _accountRepo?.AddAccount(newAccount);
                    break;

                default:
                    return null;
            }
        }

        customer.AddAccount(newAccount);

        return newAccount;
    }

    /// <summary>
    /// This method finds and returns the account specified by given account number.
    /// </summary>
    /// <param name="accNo">string of account number to be find</param>
    /// <returns>Account object if found with given account number or returns null if not found</returns>
    public Account? GetAccount(string accNo)
    {
        return _accountRepo?.GetAccount(accNo);
    }

    #endregion


    #region Disposing Method

    /// <summary>
    /// This method will be called when the object of Account Service is in no longer use and it is being destroyed
    /// </summary>
    public void Dispose()
    {
        _instance = null;
        _accountRepo = null;
        _customerRepo = null;
    }

    #endregion

}

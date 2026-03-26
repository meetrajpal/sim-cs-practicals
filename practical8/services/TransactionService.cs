namespace practical8.services;

internal class TransactionService : IDisposable
{
    #region Fields

    private static AccountRepository? _accountRepository;
    private static TransactionService? _instance = null;

    #endregion

    #region Constructors
    /// <summary>
    /// This is the private constructor for the class so that no objects can be crated outside of the class and object can be created using GetInstance method which will create only single instance of the class.
    /// </summary>
    private TransactionService() { }


    #endregion

    #region Static Methods

    /// <summary>
    /// This method will return the instance of TransactionService class following the singleton pattern.
    /// </summary>
    /// <param name="accountRepository">Account repository object for dependency injection</param>
    /// <returns>Instance object of TransactionService class</returns>
    public static TransactionService GetInstance(AccountRepository accountRepository)
    {
        if (_instance == null)
        {
            _accountRepository = accountRepository;
            _instance = new TransactionService();
        }

        return _instance;
    }

    #endregion

    #region Methods

    /// <summary>
    /// This method will deposit given amount in the account
    /// </summary>
    /// <param name="accountNo">string of account number</param>
    /// <param name="amount">decimal amount to be deposited</param>
    /// <param name="pin">int pin of account for access</param>
    public void Deposit(string accountNo, decimal amount, int pin)
    {
        Account? account = _accountRepository?.GetAccount(accountNo);
        if (account == null)
        {
            Console.WriteLine($"No account found with given account number: {accountNo}");
        }
        else
        {
            if (account is not IDepositable depositableAccount)
            {
                Console.WriteLine("You can not deposit in Loan account.");
            }
            else
            {
                if (account.Pin.Equals(pin))
                {
                    depositableAccount.Deposit(amount);
                }
                else
                {
                    Console.WriteLine("You have enetered wrong PIN try again later.");
                }
            }
        }
    }

    /// <summary>
    /// This method will withdraw given amount in the account
    /// </summary>
    /// <param name="accountNo">string of account number</param>
    /// <param name="amount">decimal amount to be withdrawn</param>
    /// <param name="pin">int pin of account for access</param>
    public void Withdraw(string accountNo, decimal amount, int pin)
    {
        Account? account = _accountRepository?.GetAccount(accountNo);
        if (account == null)
        {
            Console.WriteLine($"No account found with given account number: {accountNo}");
        }
        else
        {
            if (account is not IWithdrawable withdrawableAccount)
            {
                Console.WriteLine("You can not withdraw in Fixed Deposit account.");
            }
            else
            {
                if (account.Pin.Equals(pin))
                {
                    withdrawableAccount.Withdraw(amount);
                }
                else
                {
                    Console.WriteLine("You have enetered wrong PIN try again later.");
                }
            }
        }
    }

    /// <summary>
    /// This method will calculate monthly interest of available balance
    /// </summary>
    /// <param name="accountNo">string of account number</param>
    /// <param name="pin">int pin of account for access</param>
    public void CalculateMonthIntereset(string accountNo, int pin)
    {
        Account? account = _accountRepository?.GetAccount(accountNo);
        if (account == null)
        {
            Console.WriteLine($"No account found with given account number: {accountNo}");
        }
        else
        {
            if (account.Pin.Equals(pin))
            {
                if (account is not IInterestBearable interestBearableAccount)
                {

                    Console.WriteLine("Current account and Loan account are not eligible for interest.");
                }
                else
                {
                    Console.WriteLine($"Your current month interest amount is Rs. {interestBearableAccount.CalculateInterest()} according to your available balance Rs. {account.Balance}");
                }
            }
            else
            {
                Console.WriteLine("You have enetered wrong PIN try again later.");
            }
        }

    }

    /// <summary>
    /// This method will show the available balance of account
    /// </summary>
    /// <param name="accountNo">string of account number</param>
    /// <param name="pin">int pin of account for access</param>
    public void GetAccountBalance(string accountNo, int pin)
    {
        Account? account = _accountRepository?.GetAccount(accountNo);
        if (account == null)
        {
            Console.WriteLine($"No account found with given account number: {accountNo}");
        }
        else
        {
            if (account.Pin.Equals(pin))
            {
                Console.WriteLine($"Your available balance is amount Rs. {account.Balance}");
            }
            else
            {
                Console.WriteLine("You have enetered wrong PIN try again later.");
            }
        }
    }

    #endregion

    #region Dispose Method
    public void Dispose()
    {
        _instance = null;
        _accountRepository = null;
    }

    #endregion
}

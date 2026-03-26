namespace practical8.repositories;

internal class AccountRepository
{
    #region Fileds

    private List<Account> _accounts = new List<Account>();

    private static AccountRepository? _instance = null;

    #endregion


    #region Constructors

    /// <summary>
    /// This is the private constructor for the class so that no objects can be crated outside of the class and object can be created using GetInstance method which will create only single instance of the class.
    /// </summary>
    private AccountRepository() { }

    #endregion


    #region Static Methods

    /// <summary>
    /// This method will return the instance of AccountRepository class following the singleton pattern.
    /// </summary>
    /// <returns>Instance object of AccountRepository class</returns>
    public static AccountRepository GetInstance()
    {
        if (_instance == null)
        {
            _instance = new AccountRepository();
        }
        return _instance;
    }

    #endregion

    #region Methods
    /// <summary>
    /// This method will add new account to the list of all accounts
    /// </summary>
    /// <param name="newAcc">New Account that is created</param>
    public void AddAccount(Account newAcc)
    {
        _accounts.Add(newAcc);
    }

    /// <summary>
    /// This method finds and returns the account specified by given account number.
    /// </summary>
    /// <param name="accNo">string of account number to be find</param>
    /// <returns>Account object if found with given account number or returns null if not found</returns>
    public Account? GetAccount(string accNo)
    {
        return _accounts.Find((obj) => obj.AccountNumber.Equals(accNo));
    }

    #endregion
}

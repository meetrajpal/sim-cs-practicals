namespace practical8.models;

internal class Customer
{
    #region Fields

    private List<Account> _accounts = new List<Account>();

    #endregion

    #region Properties
    public string CustomerId { get; set; }
    public string Name { get; set; }
    public int Mobile { get; set; }

    public string Email { get; set; }

    #endregion

    #region Constructors
    public Customer(string custId, string name, int mobile, string email)
    {
        CustomerId = custId;
        Name = name;
        Mobile = mobile;
        Email = email;
    }
    #endregion

    #region Methods

    /// <summary>
    /// This method will add new account to the list of account that customer holds.
    /// </summary>
    /// <param name="account">New account object</param>
    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }

    #endregion
}

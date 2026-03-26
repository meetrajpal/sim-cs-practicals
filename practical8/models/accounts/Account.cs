namespace practical8.models.accounts;

/// <summary>
/// This is the base class for all types of account and this class is abstract.
/// </summary>
internal abstract class Account
{
    #region Properties

    public int Pin { get; set; }
    public string AccountNumber { get; set; }
    public Customer Owner { get; set; }

    public decimal Balance { get; set; }

    #endregion

    #region Events

    private static EventHandler<TransactionCompletedEventArgs>? OnTransactionComplete;

    #endregion

    #region Constructors
    public Account(string accNo, Customer customer, decimal balance, int pin)
    {
        AccountNumber = accNo;
        Owner = customer;
        Balance = balance;
        Pin = pin;
    }

    #endregion

    #region Methods

    /// <summary>
    /// This method shows type of account
    /// </summary>
    /// <returns>string of account type</returns>
    abstract public string GetAccountType();

    /// <summary>
    /// This method can invoke the OnTransactionComplete event.
    /// </summary>
    /// <param name="args">Event arguments</param>
    protected virtual void RaiseOnTransactionComplete(TransactionCompletedEventArgs args)
    {
        OnTransactionComplete?.Invoke(this, args);
    }

    /// <summary>
    /// This method will register any event handler of specified type to the event and will register it once only.
    /// </summary>
    /// <param name="eventHandler">Event handler method</param>
    public static void Subscribe(EventHandler<TransactionCompletedEventArgs> eventHandler)
    {
        if (OnTransactionComplete == null || !OnTransactionComplete.GetInvocationList().Contains(eventHandler))
        {
            OnTransactionComplete += eventHandler;
        }
    }

    #endregion
}

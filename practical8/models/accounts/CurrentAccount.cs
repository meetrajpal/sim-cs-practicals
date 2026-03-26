namespace practical8.models.accounts;

/// <summary>
/// This class is for current type of account.
/// </summary>
internal class CurrentAccount : Account, IDepositable, IWithdrawable
{
    #region Constructors
    public CurrentAccount(string accNo, Customer customer, decimal balance, int pin) : base(accNo, customer, balance, pin) { }

    #endregion

    #region Methods

    // <summary>
    /// This method shows type of account
    /// </summary>
    /// <returns>string of account type</returns>
    public override string GetAccountType()
    {
        return "Current";
    }

    /// <summary>
    /// This method deposits given amount to the account.
    /// </summary>
    /// <param name="amount">Amount to be deposited</param>
    public void Deposit(decimal amount)
    {
        if (amount < 1000)
        {
            Console.WriteLine("You can not deposit an amount less than Rs. 1000 in current account");
        }
        else
        {
            Balance += amount;
            Console.WriteLine($"Amount {amount} deposited successfully.");
            RaiseOnTransactionComplete(new events.TransactionCompletedEventArgs() { AccountNumber = this.AccountNumber, Customer = this.Owner, Message = $"Amount {amount} deposited successfully." });
        }
    }

    /// <summary>
    /// This method withdraws amount from account
    /// </summary>
    /// <param name="amount">decimal amount that is going to be withdrawn</param>
    /// <returns>decimal available balance after withdrawing amount</returns>
    public void Withdraw(decimal amount)
    {
        if (amount < 1)
        {
            Console.WriteLine("You can not withdraw an amount less than Rs. 1");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"Amount {amount} withdrawed successfully.");
            RaiseOnTransactionComplete(new events.TransactionCompletedEventArgs() { AccountNumber = this.AccountNumber, Customer = this.Owner, Message = $"Amount {amount} withdrawed successfully." });
        }
    }

    #endregion
}

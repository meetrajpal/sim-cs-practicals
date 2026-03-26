namespace practical8.models.accounts;

internal class SavingsAccount : Account, IDepositable, IWithdrawable, IInterestBearable
{
    #region Constructors
    public SavingsAccount(string accNo, Customer customer, decimal balance, int pin) : base(accNo, customer, balance, pin) { }

    #endregion

    #region Methods

    // <summary>
    /// This method shows type of account
    /// </summary>
    /// <returns>string of account type</returns>
    public override string GetAccountType()
    {
        return "Savings";
    }

    /// <summary>
    /// This method deposits given amount to the account.
    /// </summary>
    /// <param name="amount">Amount to be deposited</params>
    public void Deposit(decimal amount)
    {
        if (amount < 1)
        {
            Console.WriteLine("You can not deposit an amount less than Rs. 1 in current account");
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

    /// <summary>
    /// This method calculates interest for available balance in account.
    /// </summary>
    /// <returns>decimal interest amount</returns>
    public decimal CalculateInterest()
    {
        return (Balance * 4.0m * (1.0m / 12.0m)) / 100;
    }

    #endregion
}

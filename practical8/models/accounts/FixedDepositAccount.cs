namespace practical8.models.accounts;

/// <summary>
/// This class is for fixed deposit account type
/// </summary>
internal class FixedDepositAccount : Account, IDepositable, IInterestBearable
{
    #region Constructors
    public FixedDepositAccount(string accNo, Customer customer, decimal balance, int pin) : base(accNo, customer, balance, pin) { }

    #endregion

    #region Methods

    // <summary>
    /// This method shows type of account
    /// </summary>
    /// <returns>string of account type</returns>
    public override string GetAccountType()
    {
        return "Fixed Deposit";
    }

    /// <summary>
    /// This method deposits given amount to the account.
    /// </summary>
    /// <param name="amount">Amount to be deposited</param>
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
    /// This method calculates interest for available balance in account. In Fixed Deposit account interest rate is 8%
    /// </summary>
    /// <returns>decimal interest amount</returns>
    public decimal CalculateInterest()
    {
        return (Balance * 8.0m * (1.0m / 12.0m)) / 100;
    }
    #endregion
}

namespace practical8.models.accounts;

internal class LoanAccount : Account, IWithdrawable
{
    #region Constructors
    public LoanAccount(string accNo, Customer customer, decimal balance, int pin) : base(accNo, customer, balance, pin) { }

    #endregion

    #region Methods

    // <summary>
    /// This method shows type of account
    /// </summary>
    /// <returns>string of account type</returns>
    public override string GetAccountType()
    {
        return "Loan";
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

    #endregion
}

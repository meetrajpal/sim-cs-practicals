namespace practical8.interfaces;

/// <summary>
/// This interface is provides method of depositing amount to an account.
/// </summary>
internal interface IDepositable
{
    #region Methods

    /// <summary>
    /// This method deposits given amount to the account.
    /// </summary>
    /// <param name="amount">Amount to be deposited</param>
    public void Deposit(decimal amount);

    #endregion
}

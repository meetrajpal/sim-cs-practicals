namespace practical8.interfaces;

/// <summary>
/// This interface provides a method to withdraw amount from an account.
/// </summary>
internal interface IWithdrawable
{
    #region Methods

    /// <summary>
    /// This method withdraws amount from account
    /// </summary>
    /// <param name="amount">decimal amount that is going to be withdrawn</param>
    public void Withdraw(decimal amount);

    #endregion
}

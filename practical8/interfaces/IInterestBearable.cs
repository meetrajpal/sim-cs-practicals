namespace practical8.interfaces;

/// <summary>
/// This interface provides method to calculate the interest for an account.
/// </summary>
internal interface IInterestBearable
{
    #region Methods

    /// <summary>
    /// This method calculates interest for available balance in account.
    /// </summary>
    /// <returns>decimal interest amount</returns>
    public decimal CalculateInterest();

    #endregion
}

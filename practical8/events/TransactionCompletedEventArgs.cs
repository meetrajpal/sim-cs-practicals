namespace practical8.events;

/// <summary>
/// This class is used as custom event arguements when any transacation is completed and it has data like message account number and customer details.
/// </summary>
internal class TransactionCompletedEventArgs : EventArgs
{
    #region Properties
    required public string Message { get; set; }
    required public string AccountNumber { get; set; }

    required public Customer Customer { get; set; }

    #endregion
}

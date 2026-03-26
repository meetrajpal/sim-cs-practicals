namespace practical8.interfaces;

/// <summary>
/// This interface provides event handler for OnTransactionComplete event which will notify the customer about any transaction that happens.
/// </summary>
internal interface INotification
{
    #region Methods

    /// <summary>
    /// This is event handler method for OnTransactionComplete event which will notify customer.
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="args">Event data</param>
    public void NotifyCustomer(object? sender, TransactionCompletedEventArgs args);

    #endregion
}

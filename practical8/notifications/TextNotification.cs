namespace practical8.notifications;

/// <summary>
/// This class provides event handler for OnTransactionComplete event which will notify the customer about any transaction that happens using the mobile number.
/// </summary>
internal class TextNotification : INotification
{
    #region Methods

    /// <summary>
    /// This is event handler method for OnTransactionCompleted which will notify the customer using mobile number about the transactions happend
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="args">Event data arguements</param>
    public void NotifyCustomer(object? sender, TransactionCompletedEventArgs args)
    {
        Console.WriteLine($"Text Notification on {args.Customer.Mobile}: {args.Message} for account {args.AccountNumber}");
    }

    #endregion
}

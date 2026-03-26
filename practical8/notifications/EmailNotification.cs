namespace practical8.notifications;

internal class EmailNotification : INotification
{
    #region Methods

    /// <summary>
    /// This is event handler method for OnTransactionCompleted which will notify the customer using email id about the transactions happend
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="args">Event data arguements</param>
    public void NotifyCustomer(object? sender, TransactionCompletedEventArgs args)
    {
        Console.WriteLine($"Email Notification on {args.Customer.Email}: {args.Message} for account {args.AccountNumber}");
    }

    #endregion
}

using practical8.events;
using practical8.interfaces;

namespace practical8.notifications
{
    class EmailNotification : INotification
    {
        public void NotifyCustomer(object? sender, TransactionCompletedEventArgs args)
        {
            Console.WriteLine($"Email Notification on {args.Customer.Email}: {args.Message} for account {args.AccountNumber}");
        }
    }
}

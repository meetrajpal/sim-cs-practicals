using practical8.events;
using practical8.interfaces;

namespace practical8.notifications
{
    class TextNotification : INotification
    {
        public void NotifyCustomer(object? sender, TransactionCompletedEventArgs args)
        {
            Console.WriteLine($"Text Notification on {args.Customer.Mobile}: {args.Message} for account {args.AccountNumber}");
        }
    }
}

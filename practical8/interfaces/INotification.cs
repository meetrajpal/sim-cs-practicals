using practical8.events;

namespace practical8.interfaces
{
    interface INotification
    {
        public void NotifyCustomer(object? sender, TransactionCompletedEventArgs args);
    }
}

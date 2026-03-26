using practical8.models;

namespace practical8.events
{
    class TransactionCompletedEventArgs : EventArgs
    {
        required public string Message { get; set; }
        required public string AccountNumber { get; set; }

        required public Customer Customer { get; set; }
    }
}

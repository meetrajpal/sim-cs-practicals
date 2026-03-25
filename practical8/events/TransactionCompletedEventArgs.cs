namespace practical8.events
{
    class TransactionCompletedEventArgs : EventArgs
    {
        required public string Msg { get; set; }
    }
}

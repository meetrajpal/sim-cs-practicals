using practical8.events;

namespace practical8.models.accounts
{
    abstract class Account
    {
        public int Pin { get; set; }
        public string AccountNumber { get; set; }
        public Customer Owner { get; set; }

        public decimal Balance { get; set; }

        private static EventHandler<TransactionCompletedEventArgs>? OnTransactionComplete;

        public Account(string accNo, Customer customer, decimal balance, int pin)
        {
            AccountNumber = accNo;
            Owner = customer;
            Balance = balance;
            Pin = pin;
        }

        abstract public string GetAccountType();

        protected virtual void RaiseOnTransactionComplete(TransactionCompletedEventArgs args)
        {
            OnTransactionComplete?.Invoke(this, args);
        }

        public static void Subscribe(EventHandler<TransactionCompletedEventArgs> eventHandler)
        {
            if (OnTransactionComplete == null || !OnTransactionComplete.GetInvocationList().Contains(eventHandler))
            {
                OnTransactionComplete += eventHandler;
            }
        }
    }
}

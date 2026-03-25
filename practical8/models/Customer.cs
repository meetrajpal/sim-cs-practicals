using sim_cs_practicals.practical8.events;
using sim_cs_practicals.practical8.model.accounts;

namespace sim_cs_practicals.practical8.model
{
    sealed class Customer
    {
        public long CustomerId { get; private set; }
        public string Name { get; private set; }

        private List<Account> _accounts = new List<Account>();

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public IReadOnlyList<Account> GetAccounts()
        {
            return _accounts.AsReadOnly();

        }

        public void TransactionCompleted(object? sender, TransactionCompletedEventArgs args)
        {
            Console.WriteLine($"{args.Msg}");
        }
    }
}

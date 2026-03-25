using practical8.events;
using practical8.models.accounts;

namespace practical8.models
{
    class Customer
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }

        private List<Account> _accounts = new List<Account>();

        public Customer(string custId, string name)
        {
            CustomerId = custId;
            Name = name;
        }

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

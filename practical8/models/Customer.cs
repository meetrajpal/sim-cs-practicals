using practical8.events;
using practical8.models.accounts;

namespace practical8.models
{
    class Customer
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public int Mobile { get; set; }

        public string Email { get; set; }

        private List<Account> _accounts = new List<Account>();

        public Customer(string custId, string name, int mobile, string email)
        {
            CustomerId = custId;
            Name = name;
            Mobile = mobile;
            Email = email;
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
            Console.WriteLine($"{args.Message}");
        }
    }
}

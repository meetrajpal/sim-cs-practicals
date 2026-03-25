namespace sim_cs_practicals.practical8.model
{
    class Customer
    {
        public string CustomerId { get; }
        public string Name { get; }

        private List<Account> _accounts = new List<Account>();

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public IReadOnlyList<Account> GetAccounts()
        {
            return _accounts.AsReadOnly();
        }
    }
}

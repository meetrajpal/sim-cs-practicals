namespace sim_cs_practicals.practical8.model.accounts
{
    abstract class Account
    {
        public long AccountNumber { get; set; }
        public Customer Owner { get; set; }

        public decimal Balance { get; set; }

        public Account(long accNo, Customer customer, decimal balance)
        {
            AccountNumber = accNo;
            Owner = customer;
            Balance = balance;
        }

        abstract public string GetAccountType();
    }
}

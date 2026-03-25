namespace practical8.models.accounts
{
    abstract class Account
    {
        public int Pin { get; set; }
        public string AccountNumber { get; set; }
        public Customer Owner { get; set; }

        public decimal Balance { get; set; }

        public Account(string accNo, Customer customer, decimal balance, int pin)
        {
            AccountNumber = accNo;
            Owner = customer;
            Balance = balance;
            Pin = pin;
        }

        abstract public string GetAccountType();
    }
}

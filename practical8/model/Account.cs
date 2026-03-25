namespace sim_cs_practicals.practical8.model
{
    abstract class Account
    {
        public string AccountNumber { get; private set; }
        public Customer Owner { get; private set; }

        public decimal Balance { get; private set; }

        abstract public decimal CalculateInterest();

        abstract public string GetAccountType();
    }
}

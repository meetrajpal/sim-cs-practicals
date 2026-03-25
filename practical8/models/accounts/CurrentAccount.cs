using sim_cs_practicals.practical8.interfaces;

namespace sim_cs_practicals.practical8.model.accounts
{
    class CurrentAccount : Account, IDepositable, IWithdrawable
    {

        public CurrentAccount(long accNo, Customer customer, decimal balance) : base(accNo, customer, balance) { }
        public override string GetAccountType()
        {
            return "CURRENT";
        }

        public void Deposit(decimal amount)
        {
            if (amount < 1000)
            {
                Console.WriteLine("You can not deposit an amount less than Rs. 1000 in current account");
            }
            else
            {
                Balance += amount;
                Console.WriteLine($"Amount {amount} deposited successfully.");
            }
        }

        public decimal Withdraw(decimal amount)
        {
            if (amount < 1)
            {
                Console.WriteLine("You can not withdraw an amount less than Rs. 1");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Amount {amount} withdrawed successfully.");
            }
            return Balance;
        }

    }
}

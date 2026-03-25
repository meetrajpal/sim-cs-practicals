using sim_cs_practicals.practical8.interfaces;

namespace sim_cs_practicals.practical8.model.accounts
{
    class SavingsAccount : Account, IDepositable, IWithdrawable, IInterestBearable
    {
        public SavingsAccount(long accNo, Customer customer, decimal balance) : base(accNo, customer, balance) { }

        public override string GetAccountType()
        {
            return "SAVINGS";
        }

        public void Deposit(decimal amount)
        {
            if (amount < 1)
            {
                Console.WriteLine("You can not deposit an amount less than Rs. 1 in current account");
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

        public decimal CalculateInterest()
        {
            return (Balance * 4.0m * (1.0m / 12.0m)) / 100;
        }
    }
}

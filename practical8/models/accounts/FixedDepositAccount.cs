using practical8.interfaces;

namespace practical8.models.accounts
{
    class FixedDepositAccount : Account, IDepositable, IInterestBearable
    {
        public FixedDepositAccount(string accNo, Customer customer, decimal balance, int pin) : base(accNo, customer, balance, pin) { }

        public override string GetAccountType()
        {
            return "Fixed Deposit";
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

        public decimal CalculateInterest()
        {
            return (Balance * 8.0m * (1.0m / 12.0m)) / 100;
        }
    }
}

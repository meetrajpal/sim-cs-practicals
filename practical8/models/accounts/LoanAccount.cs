using sim_cs_practicals.practical8.interfaces;

namespace sim_cs_practicals.practical8.model.accounts
{
    class LoanAccount : Account, IWithdrawable
    {
        public LoanAccount(long accNo, Customer customer, decimal balance) : base(accNo, customer, balance) { }

        public override string GetAccountType()
        {
            return "LOAN";
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

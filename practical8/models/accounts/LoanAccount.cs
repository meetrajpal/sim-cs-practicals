using practical8.interfaces;

namespace practical8.models.accounts
{
    class LoanAccount : Account, IWithdrawable
    {
        public LoanAccount(string accNo, Customer customer, decimal balance, int pin) : base(accNo, customer, balance, pin) { }

        public override string GetAccountType()
        {
            return "Loan";
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

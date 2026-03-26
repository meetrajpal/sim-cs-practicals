using practical8.interfaces;

namespace practical8.models.accounts
{
    class CurrentAccount : Account, IDepositable, IWithdrawable
    {

        public CurrentAccount(string accNo, Customer customer, decimal balance, int pin) : base(accNo, customer, balance, pin) { }
        public override string GetAccountType()
        {
            return "Current";
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
                RaiseOnTransactionComplete(new events.TransactionCompletedEventArgs() { AccountNumber = this.AccountNumber, Customer = this.Owner, Message = $"Amount {amount} deposited successfully." });
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
                RaiseOnTransactionComplete(new events.TransactionCompletedEventArgs() { AccountNumber = this.AccountNumber, Customer = this.Owner, Message = $"Amount {amount} withdrawed successfully." });
            }
            return Balance;
        }

    }
}

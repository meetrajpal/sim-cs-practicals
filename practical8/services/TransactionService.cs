using practical8.models.accounts;
using practical8.repositories;

namespace practical8.services
{
    class TransactionService : IDisposable
    {
        private static AccountRepository? _accountRepository;
        private static TransactionService? _instance = null;

        private TransactionService() { }

        public static TransactionService GetInstance(AccountRepository accountRepository)
        {
            if (_instance == null)
            {
                _accountRepository = accountRepository;
                _instance = new TransactionService();
            }

            return _instance;
        }

        public bool Deposit(string accountNo, decimal amount, int pin)
        {
            Account? account = _accountRepository?.GetAccount(accountNo);
            if (account == null)
            {
                Console.WriteLine($"No account found with given account number: {accountNo}");
                return false;
            }
            else
            {
                if (!account.GetAccountType().Equals("Loan"))
                {
                    if (account.Pin.Equals(pin))
                    {
                        if (amount >= 1)
                        {
                            account.Balance += amount;

                            Console.WriteLine($"Amount {amount} deposited to account {account.AccountNumber}. Your available balance is {account.Balance}");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"You can not deposit less than Rs. 1 in account.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have enetered wrong PIN try again later.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("You can not deposit in Loan account.");
                    return false;
                }
            }
        }

        public bool Withdraw(string accountNo, decimal amount, int pin)
        {
            Account? account = _accountRepository?.GetAccount(accountNo);
            if (account == null)
            {
                Console.WriteLine($"No account found with given account number: {accountNo}");
                return false;
            }
            else
            {
                if (!account.GetAccountType().Equals("Fixed Deposit"))
                {
                    if (account.Pin.Equals(pin))
                    {
                        if (amount <= account.Balance && amount >= 1)
                        {
                            account.Balance -= amount;
                        }
                        else
                        {
                            Console.WriteLine($"Withdraw amount can not be less than Rs. {amount} OR You do not have enough balance. Your available balance is Rs. {account.Balance} and you are trying to withdraw Rs. {amount}");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have enetered wrong PIN try again later.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("You can not withdraw in Fixed Deposit account.");
                    return false;
                }
            }
            return true;
        }

        public bool CalculateMonthIntereset(string accountNo, int pin)
        {
            Account? account = _accountRepository?.GetAccount(accountNo);
            if (account == null)
            {
                Console.WriteLine($"No account found with given account number: {accountNo}");
                return false;
            }
            else
            {
                if (account.Pin.Equals(pin))
                {
                    if (account.GetAccountType().Equals("Fixed Deposit"))
                    {
                        Console.WriteLine($"Your current month interest amount is Rs. {((FixedDepositAccount)account).CalculateInterest()} according to your available balance Rs. {account.Balance}");
                    }
                    else if (account.GetAccountType().Equals("Savings"))
                    {
                        Console.WriteLine($"Your current month interest amount is Rs. {((SavingsAccount)account).CalculateInterest()} according to your available balance Rs. {account.Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Current account and Loan account are not eligible for interest.");
                        return false;
                    }

                }
                else
                {
                    Console.WriteLine("You have enetered wrong PIN try again later.");
                    return false;
                }
            }
            return true;

        }

        public void Dispose()
        {
            _instance = null;
            _accountRepository = null;
        }
    }
}

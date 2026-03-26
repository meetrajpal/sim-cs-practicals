using practical8.interfaces;
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

        public void Deposit(string accountNo, decimal amount, int pin)
        {
            Account? account = _accountRepository?.GetAccount(accountNo);
            if (account == null)
            {
                Console.WriteLine($"No account found with given account number: {accountNo}");
            }
            else
            {
                if (account is not IDepositable depositableAccount)
                {
                    Console.WriteLine("You can not deposit in Loan account.");
                }
                else
                {
                    if (account.Pin.Equals(pin))
                    {
                        depositableAccount.Deposit(amount);
                    }
                    else
                    {
                        Console.WriteLine("You have enetered wrong PIN try again later.");
                    }
                }
            }
        }

        public void Withdraw(string accountNo, decimal amount, int pin)
        {
            Account? account = _accountRepository?.GetAccount(accountNo);
            if (account == null)
            {
                Console.WriteLine($"No account found with given account number: {accountNo}");
            }
            else
            {
                if (account is not IWithdrawable withdrawableAccount)
                {
                    Console.WriteLine("You can not withdraw in Fixed Deposit account.");
                }
                else
                {
                    if (account.Pin.Equals(pin))
                    {
                        withdrawableAccount.Withdraw(amount);
                    }
                    else
                    {
                        Console.WriteLine("You have enetered wrong PIN try again later.");
                    }
                }
            }
        }

        public void CalculateMonthIntereset(string accountNo, int pin)
        {
            Account? account = _accountRepository?.GetAccount(accountNo);
            if (account == null)
            {
                Console.WriteLine($"No account found with given account number: {accountNo}");
            }
            else
            {
                if (account.Pin.Equals(pin))
                {
                    if (account is not IInterestBearable interestBearableAccount)
                    {

                        Console.WriteLine("Current account and Loan account are not eligible for interest.");
                    }
                    else
                    {
                        Console.WriteLine($"Your current month interest amount is Rs. {interestBearableAccount.CalculateInterest()} according to your available balance Rs. {account.Balance}");
                    }
                }
                else
                {
                    Console.WriteLine("You have enetered wrong PIN try again later.");
                }
            }

        }

        public void GetAccountBalance(string accountNo, int pin)
        {
            Account? account = _accountRepository?.GetAccount(accountNo);
            if (account == null)
            {
                Console.WriteLine($"No account found with given account number: {accountNo}");
            }
            else
            {
                if (account.Pin.Equals(pin))
                {
                    Console.WriteLine($"Your available balance is amount Rs. {account.Balance}");
                }
                else
                {
                    Console.WriteLine("You have enetered wrong PIN try again later.");
                }
            }
        }

        public void Dispose()
        {
            _instance = null;
            _accountRepository = null;
        }
    }
}

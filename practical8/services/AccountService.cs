using practical8.models;
using practical8.models.accounts;
using practical8.repositories;
using practical8.utils;


namespace practical8.services
{
    class AccountService : IDisposable
    {
        private static AccountService? _instance;
        private static AccountRepository? _accountRepo;
        private static CustomerRepository? _customerRepo;

        private AccountService() { }

        public static AccountService GetInstance(AccountRepository accountRepo, CustomerRepository customerRepo)
        {
            if (_instance == null)
            {
                _instance = new AccountService();
                _accountRepo = accountRepo;
                _customerRepo = customerRepo;
            }
            return _instance;
        }

        public Account? CreateAccount(string custId, decimal balance, AccountType accountType, int pin)
        {
            Account? newAccount;

            Customer? customer = _customerRepo?.GetCustomer(custId);

            if (customer == null)
            {
                Console.WriteLine($"Can not find customer data with given Customer ID: {custId}");
                return null;
            }
            else
            {
                switch (accountType)
                {
                    case AccountType.Savings:
                        newAccount = new SavingsAccount(Utility.GenerateAccountNo(), customer, balance, pin);
                        _accountRepo?.AddAccount(newAccount);
                        break;

                    case AccountType.Current:
                        newAccount = new CurrentAccount(Utility.GenerateAccountNo(), customer, balance, pin);
                        _accountRepo?.AddAccount(newAccount);
                        break;

                    case AccountType.FixedDeposit:
                        newAccount = new FixedDepositAccount(Utility.GenerateAccountNo(), customer, balance, pin);
                        _accountRepo?.AddAccount(newAccount);
                        break;

                    case AccountType.Loan:
                        newAccount = new LoanAccount(Utility.GenerateAccountNo(), customer, balance, pin);
                        _accountRepo?.AddAccount(newAccount);
                        break;

                    default:
                        return null;
                }
            }
            return newAccount;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Account? GetAccount(string accNo)
        {
            return _accountRepo?.GetAccount(accNo);
        }
    }
}

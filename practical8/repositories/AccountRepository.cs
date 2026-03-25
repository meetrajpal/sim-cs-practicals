using practical8.models.accounts;

namespace practical8.repositories
{
    class AccountRepository
    {
        private List<Account> _accounts = new List<Account>();

        private static AccountRepository? _instance = null;

        private AccountRepository() { }

        public static AccountRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AccountRepository();
            }
            return _instance;
        }

        public void AddAccount(Account newAcc)
        {
            _accounts.Add(newAcc);
        }

        public Account? GetAccount(string accNo)
        {
            return _accounts.Find((obj) => obj.AccountNumber.Equals(accNo));
        }
    }
}

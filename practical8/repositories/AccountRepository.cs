using sim_cs_practicals.practical8.model.accounts;

namespace sim_cs_practicals.practical8.repository
{
    class AccountRepository
    {
        private List<Account> _accounts = new List<Account>();

        public void AddAccount(Account newAcc)
        {
            _accounts.Add(newAcc);
        }

        public Account? GetAccount(long accNo)
        {
            return _accounts.Find((obj) => obj.AccountNumber == accNo);
        }

        public Account? GetAccount(string owner)
        {
            return _accounts.Find((obj) => obj.Owner.Equals(owner));
        }
    }
}

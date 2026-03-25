using sim_cs_practicals.practical8.repository;

namespace sim_cs_practicals.practical8.services
{
    class AccountService
    {
        private AccountRepository accountRepo;
        private CustomerRepository customerRepo;

        public AccountService(AccountRepository accountRepo, CustomerRepository customerRepo)
        {
            this.accountRepo = accountRepo;
            this.customerRepo = customerRepo;
        }

        public void CreateAccount(long custId)
        {

        }
    }
}

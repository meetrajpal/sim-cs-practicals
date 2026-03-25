namespace sim_cs_practicals.practical8.model
{
    class SavingsAccount : Account
    {
        public override decimal CalculateInterest()
        {
            return (Balance * 4.0m * (1.0m / 12.0m)) / 100;
        }

        public override string GetAccountType()
        {
            return "SAVINGS";
        }
    }
}

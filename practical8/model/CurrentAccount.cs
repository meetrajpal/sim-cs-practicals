namespace sim_cs_practicals.practical8.model
{
    class CurrentAccount : Account
    {
        public override decimal CalculateInterest()
        {
            return 0;
        }

        public override string GetAccountType()
        {
            return "CURRENT";
        }
    }
}

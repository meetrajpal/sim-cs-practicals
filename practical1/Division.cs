namespace sim_cs_practicals.practical1
{
    /// <summary>
    /// This is class for division operation
    /// </summary>
    class Division : ArithmeticOperation
    {
        /// <summary>
        /// This is public constructor to initialize number 1 and number 2
        /// </summary>
        public Division(int n1, int n2) : base(n1, n2) { }

        /// <summary>
        /// This is method will perform division on both numbers and will return result of operation in decimal.
        /// </summary>
        public override decimal Compute()
        {
            return (decimal)Number1 / (decimal)Number2;
        }
    }
}
namespace sim_cs_practicals.practical1
{
    /// <summary>
    /// This is base abstract class for all arithmetic operations
    /// </summary>
    abstract class ArithmeticOperation
    {
        /// <summary>
        /// This property will store and retrive number 1
        /// </summary>
        public int Number1 { get; set; }

        /// <summary>
        /// This property will store and retrive number 2
        /// </summary>
        public int Number2 { get; set; }

        /// <summary>
        /// This is public constructor to initialize number 1 and number 2
        /// </summary>
        public ArithmeticOperation(int num1, int num2)
        {
            Number1 = num1;
            Number2 = num2;
        }

        /// <summary>
        /// This is method will perform arithmetic operations on both numbers and will return result of operation in decimal.
        /// </summary>
        public abstract decimal Compute();
    }
}
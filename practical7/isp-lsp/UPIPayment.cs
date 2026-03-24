using sim_cs_practicals.practical7.ocp_lsp;

namespace sim_cs_practicals.practical7.isp_lsp
{
    /// <summary>
    /// This class is used for payment purpose and this class is also able to get a refund
    /// </summary>
    class UPIPayment : IPaymentMethod, IRefundable
    {
        /// <summary>
        /// This is instance of class and it is used to ensure there is only one instance of this class
        /// </summary>
        private static UPIPayment? Instance = null;

        /// <summary>
        /// This is the private constructor of the class to restrict object creation from outside of the class
        /// </summary>
        private UPIPayment() { }

        /// <summary>
        /// This method will return single instance of this class
        /// </summary>
        /// <returns></returns>
        public static UPIPayment GetInstance()
        {
            if (Instance == null)
            {
                Instance = new UPIPayment();
            }
            return Instance;
        }

        /// <summary>
        /// This method processes payment of given amount
        /// </summary>
        /// <param name="amount">Amount to be paid</param>
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying Rs. {amount} through UPI ID...");
        }

        /// <summary>
        /// This method processes refund of given amount
        /// </summary>
        /// <param name="amount">Amount to be refunded</param>
        public void Refund(decimal amount)
        {
            Console.WriteLine($"Refunding Rs. {amount} through UPI ID....");
        }
    }
}

using sim_cs_practicals.practical7.ocp_lsp;

namespace sim_cs_practicals.practical7.isp_lsp
{
    /// <summary>
    /// This class is used for doing payment through credit card
    /// </summary>
    class CreditCardPayment : IPaymentMethod
    {
        /// <summary>
        /// This is instance of class and it is used to ensure there is only one instance of this class
        /// </summary>
        private static CreditCardPayment? Instance = null;

        /// <summary>
        /// This is the private constructor of the class to restrict object creation from outside of the class
        /// </summary>
        private CreditCardPayment() { }

        /// <summary>
        /// This method will return single instance of this class
        /// </summary>
        /// <returns></returns>
        public static CreditCardPayment GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CreditCardPayment();
            }
            return Instance;
        }

        /// <summary>
        /// This method returns nothing and will process payment for given amount
        /// </summary>
        /// <param name="amount">Amount to be paid</param>
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying Rs. {amount} through Credit Card...");
        }
    }
}

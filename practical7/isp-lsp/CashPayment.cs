using sim_cs_practicals.practical7.ocp_lsp;

namespace sim_cs_practicals.practical7.isp_lsp
{
    /// <summary>
    /// (Liskov Substitution)
    /// Derived class objects can replace base class objects without breaking the behaviour.
    /// 
    /// (Interface Segregation)
    /// CashPayment and CreditCardPayment can pay only do not have functionality to get refund.
    /// UPIPayment has functionality of paying and getting a refund too.
    /// </summary>
    class CashPayment : IPaymentMethod
    {

        /// <summary>
        /// This is instance of class and it is used to ensure there is only one instance of this class
        /// </summary>
        private static CashPayment? Instance = null;

        /// <summary>
        /// This is the private constructor of the class to restrict object creation from outside of the class
        /// </summary>
        private CashPayment() { }

        /// <summary>
        /// This method will return single instance of this class
        /// </summary>
        /// <returns></returns>
        public static CashPayment GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CashPayment();
            }
            return Instance;
        }
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying Rs. {amount} through cash....");
        }
    }
}

using sim_cs_practicals.practical7.interfaces;

namespace sim_cs_practicals.practical7.payment_methods
{
    /// <summary>
    /// This class is used for doing payment through credit card
    /// </summary>
    class CreditCardPayment : IPaymentMethod
    {
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

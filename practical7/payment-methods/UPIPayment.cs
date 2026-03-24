using sim_cs_practicals.practical7.interfaces;

namespace sim_cs_practicals.practical7.payment_methods
{
    /// <summary>
    /// This class is used for payment purpose and this class is also able to get a refund
    /// </summary>
    class UPIPayment : IPaymentMethod, IRefundable
    {
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

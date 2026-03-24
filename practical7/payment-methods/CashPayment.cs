using sim_cs_practicals.practical7.interfaces;

namespace sim_cs_practicals.practical7.payment_methods
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
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying Rs. {amount} through cash....");
        }
    }
}

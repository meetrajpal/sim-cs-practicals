using sim_cs_practicals.practical7.isp_lsp;
using sim_cs_practicals.practical7.ocp_lsp;

namespace sim_cs_practicals.practical7.srp_dip
{
    /// <summary>
    /// (Dependency Inversion)
    /// PaymentProcessor class handles payment processing task and is dependent on abstractions not details.
    /// </summary>
    class PaymentProcessor
    {
        private UserManager _user;
        readonly private IPaymentMethod _paymentMethod;
        readonly private Logger _logger;
        public PaymentProcessor(UserManager user, IPaymentMethod obj, Logger loggerObj)
        {
            _user = user;
            _paymentMethod = obj;
            _logger = loggerObj;
        }

        public void Pay(decimal amount)
        {
            _logger.LogInfo($"Payment initiated for amount Rs. {amount} for user: {_user.Username}...");
            if (amount < 1)
            {
                _logger.LogError($"Paying amount is less than Rs. 1 for user: {_user.Username}");
                _logger.LogInfo($"Stopped process of payment for user: {_user.Username}");
            }
            else if (amount > _user.AvailableBalance)
            {
                _logger.LogError($"Not enough available balance in {_user.Username} user's account: Paying amount is Rs. {amount} and available amount is {this._user.AvailableBalance}");
                _logger.LogInfo($"Payment stopped for user: {_user.Username}.");
            }
            else
            {
                _paymentMethod.Pay(amount);
                _user.AvailableBalance -= amount;
                _user.paymentHistory.Add(amount);
                _logger.LogInfo($"Payment completed successfully for user: {_user.Username}.");
            }
        }
    }

}

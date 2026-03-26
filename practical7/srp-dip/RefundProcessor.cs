namespace practical7.srp_dip;

/// <summary>
/// (Dependency Inversion)
/// RefundProcessor class handles refund process task and is dependent on abstractions not details.
/// </summary>
internal class RefundProcessor
{
    private UserManager _user;
    readonly private IRefundable _refundObj;
    readonly private Logger _logger;

    public RefundProcessor(UserManager user, IRefundable refundObj, Logger logObj)
    {
        _user = user;
        _refundObj = refundObj;
        _logger = logObj;
    }

    public void Refund(decimal amount)
    {
        _logger.LogInfo($"Refund initiated of amount Rs. {amount} for user: {_user.Username}...");

        if (_user.paymentHistory.Contains(amount))
        {
            _refundObj.Refund(amount);
            _user.AvailableBalance += amount;
            _user.paymentHistory.Remove(amount);
            _logger.LogInfo($"Refund of amount Rs. {amount} completed successfully for user: {_user.Username}.");
        }
        else
        {
            _logger.LogError($"No entry found for amount Rs. {amount} in payment history user: {_user.Username}");
        }
    }
}

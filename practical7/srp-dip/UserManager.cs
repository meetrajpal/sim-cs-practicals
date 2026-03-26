namespace practical7.srp_dip;

/// <summary>
/// (Single Responsibility)
/// User class contains user name, payment paymentHistory and available balance of user.
/// PaymentProcessor processes the payment.
/// RefundProcessor processes the refund.
/// Logger classes logs the operations.
/// </summary>
internal class UserManager
{
    readonly private Logger _logger;
    public string Username { get; set; }

    public List<decimal> paymentHistory = new List<decimal>();
    public decimal AvailableBalance { get; set; }

    public UserManager(string name, decimal amount, Logger logger)
    {
        Username = name;
        AvailableBalance = amount;
        _logger = logger;
        _logger.LogInfo($"User created successfully with username: {this.Username}");
    }

    /// <summary>
    /// This method will return void / nothing and will add balance to user's available balance
    /// </summary>
    /// <param name="amount">Amount to add</param>
    public void AddBalance(decimal amount)
    {
        _logger.LogInfo($"Process of adding balance started for user: {this.Username}");
        if (amount < 1)
        {
            _logger.LogError($"Adding balance is less than Rs. 1 for user: {this.Username}");
            _logger.LogInfo($"Stopped process of adding balance due to error for user: {this.Username}");
        }
        else
        {
            AvailableBalance += amount;

            _logger.LogInfo($"Process of adding balance completed successfully for user: {this.Username}");
        }
    }
}

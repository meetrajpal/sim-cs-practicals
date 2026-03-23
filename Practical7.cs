namespace sim_cs_practicals
{
    class Practical7
    {
        /*
         * (Single Responsibility)
         * User class contains user name, payment paymentHistory and available balance of user.
         * PaymentProcessor processes the payment.
         * RefundProcessor processes the refund.
         * Logger classes logs the operations.
         */
        class User
        {
            public string Username { get; set; }

            public List<decimal> paymentHistory = new List<decimal>();

            private decimal availableBalance;
            public decimal AvailableBalance { get; set; }


            public User(string name, decimal amount)
            {
                this.Username = name;
                if (amount < 1000)
                {
                    Console.WriteLine("Initial minimum balance cannot be less than 1000.");
                }
                else
                {
                    this.AvailableBalance = amount;
                }
            }
        }

        /*
         * IPaymentMethod and IRefundable interfaces create a contract list of required methods for payment and refund perposes.
         */
        interface IPaymentMethod
        {
            public void Pay(decimal amount);
        }

        interface IRefundable
        {
            public void Refund(decimal amount);
        }

        /*
         * (Liskov Substitution)
         * Derived class objects can replace base class objects without breaking the behaviour.
         * 
         * (Interface Segregation)
         * CashPayment and CreditCardPayment can pay only do not have functionality to get refund.
         * UPIPayment has functionality of paying and getting a refund too.
         */
        class CashPayment : IPaymentMethod
        {
            public void Pay(decimal amount)
            {
                Console.WriteLine($"Paying {amount} through cash....");
            }
        }

        class UPIPayment : IPaymentMethod, IRefundable
        {
            public void Pay(decimal amount)
            {
                Console.WriteLine($"Paying {amount} through UPI ID...");
            }

            public void Refund(decimal amount)
            {
                Console.WriteLine($"Refunding {amount} through UPI ID....");
            }
        }

        class CreditCardPayment : IPaymentMethod
        {
            public void Pay(decimal amount)
            {
                Console.WriteLine($"Paying {amount} through Credit Card...");
            }
        }



        /*
         * (Dependency Inversion)
         * PaymentProcessor class handles payment processing task and is dependent on abstractions not details.
         */
        class PaymentProcessor
        {
            private User _user;
            readonly private IPaymentMethod _paymentMethod;
            readonly private Logger _logger;
            public PaymentProcessor(User user, IPaymentMethod obj, Logger loggerObj)
            {
                _user = user;
                _paymentMethod = obj;
                _logger = loggerObj;
            }

            public void Pay(decimal amount)
            {
                _logger.LogInfo($"Payment initiated for amount {amount} for user: {_user.Username}...");
                if (amount > _user.AvailableBalance)
                {
                    Console.WriteLine($"You can not pay more. Paying {amount} is more than available amount {this._user.AvailableBalance}.");
                    _logger.LogError($"Not enough available balance in {_user.Username} user's account: Paying amount is {amount} and available amount is {this._user.AvailableBalance}");
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

        /*
         * (Dependency Inversion)
         * RefundProcessor class handles refund process task and is dependent on abstractions not details.
         */
        class RefundProcessor
        {
            private User _user;
            readonly private IRefundable _refundObj;
            readonly private Logger _logger;

            public RefundProcessor(User user, IRefundable refundObj, Logger logObj)
            {
                _user = user;
                _refundObj = refundObj;
                _logger = logObj;
            }

            public void Refund(decimal amount)
            {
                _logger.LogInfo($"Refund initiated of amount {amount} for user: {_user.Username}...");
                if (_user.paymentHistory.Contains(amount))
                {
                    _refundObj.Refund(amount);
                    _user.AvailableBalance += amount;
                    _user.paymentHistory.Remove(amount);
                    _logger.LogInfo($"Refund of amount {amount} completed successfully for user: {_user.Username}.");
                }
                else
                {
                    Console.WriteLine($"No entry found for amount {amount} in your payment history.");
                    _logger.LogError($"No entry found for amount {amount} in payment history user: {_user.Username}");
                }
            }
        }


        /*
         * (Open - Close Principle)
         * This below code section handles all logging operations.
         * Any more logging method can be included without modifying existing code.
         */

        abstract class Logger
        {
            public abstract void LogInfo(string msg);
            public abstract void LogError(string msg);
        }


        class ConsoleLogger : Logger
        {
            public override void LogError(string msg)
            {
                Console.WriteLine($"Logging in console: ERROR: {msg}");
            }

            public override void LogInfo(string msg)
            {
                Console.WriteLine($"Logging in console: INFO: {msg}");
            }
        }

        class FileLogger : Logger
        {
            public override void LogError(string msg)
            {
                Console.WriteLine($"Logging in File: ERROR: {msg}");
            }

            public override void LogInfo(string msg)
            {
                Console.WriteLine($"Logging in File: INFO: {msg}");
            }
        }


        /*
         * This is the Main method of the program.
         */
        public static void main(String[] args)
        {
            User user = new User("Meet Rajpal", 1500);

            ConsoleLogger consoleLogger = new ConsoleLogger();
            FileLogger fileLogger = new FileLogger();

            UPIPayment upiPayment = new UPIPayment();

            PaymentProcessor paymentProcessor = new PaymentProcessor(user, upiPayment, fileLogger);

            Console.WriteLine($"Initial available balance for {user.Username} is {user.AvailableBalance}\n");

            paymentProcessor.Pay(555.25M);
            Console.WriteLine($"Available balance for {user.Username} is {user.AvailableBalance}\n");

            paymentProcessor.Pay(1000);
            Console.WriteLine($"Available balance for {user.Username} is {user.AvailableBalance}\n");

            RefundProcessor refundProcessor = new RefundProcessor(user, upiPayment, consoleLogger);

            refundProcessor.Refund(555.25M);
            Console.WriteLine($"Available balance for {user.Username} is {user.AvailableBalance}\n");

            refundProcessor.Refund(130);
            Console.WriteLine($"Available balance for {user.Username} is {user.AvailableBalance}\n");
        }
    }
}

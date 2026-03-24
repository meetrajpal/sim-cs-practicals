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
            private Logger _logger;
            public string Username { get; set; }

            public List<decimal> paymentHistory = new List<decimal>();
            public decimal AvailableBalance { get; set; }

            public User(string name, decimal amount, Logger logger)
            {
                Username = name;
                AvailableBalance = amount;
                _logger = logger;
                _logger.LogInfo($"User created successfully with username: {this.Username}");
            }

            /*
             * This method will return void / nothing and will add balance to user's available balance
             */
            public void AddBalance(decimal amount)
            {
                _logger.LogInfo($"Process of adding balance started for user: {this.Username}");
                if (amount < 1)
                {
                    Console.WriteLine("You can not add balance less than Rs. 1");
                    _logger.LogError($"Adding balance is less than Rs. 1 for user: {this.Username}");
                    _logger.LogInfo($"Stopped process of adding balance due to error for user: {this.Username}");
                }
                else
                {
                    AvailableBalance += amount;
                    Console.WriteLine($"Rs. {amount} added successfully. Available balance is Rs. {this.AvailableBalance}");
                    _logger.LogInfo($"Process of adding balance completed successfully for user: {this.Username}");
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
                Console.WriteLine($"Paying Rs. {amount} through cash....");
            }
        }

        class UPIPayment : IPaymentMethod, IRefundable
        {
            public void Pay(decimal amount)
            {
                Console.WriteLine($"Paying Rs. {amount} through UPI ID...");
            }

            public void Refund(decimal amount)
            {
                Console.WriteLine($"Refunding Rs. {amount} through UPI ID....");
            }
        }

        class CreditCardPayment : IPaymentMethod
        {
            public void Pay(decimal amount)
            {
                Console.WriteLine($"Paying Rs. {amount} through Credit Card...");
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
                _logger.LogInfo($"Payment initiated for amount Rs. {amount} for user: {_user.Username}...");
                if (amount < 1)
                {
                    Console.WriteLine("Amount can not be less than Rs. 1");
                    _logger.LogError($"Paying amount is less than Rs. 1 for user: {_user.Username}");
                    _logger.LogInfo($"Stopped process of payment for user: {_user.Username}");
                }
                else if (amount > _user.AvailableBalance)
                {
                    Console.WriteLine($"You can not pay more. Paying Rs. {amount} is more than available amount {this._user.AvailableBalance}.");
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
                    Console.WriteLine($"No entry found for amount Rs. {amount} in your payment history.");
                    _logger.LogError($"No entry found for amount Rs. {amount} in payment history user: {_user.Username}");
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
            Console.Write("Enter your name: ");
            string? uname = Console.ReadLine();

            if (string.IsNullOrEmpty(uname) || string.IsNullOrWhiteSpace(uname))
            {
                Console.WriteLine("User name is required it can not be empty.");
            }
            else
            {
                Console.Write("Enter initial opening balance: ");
                decimal openingBalance = Convert.ToDecimal(Console.ReadLine());

                if (openingBalance < 1000)
                {
                    Console.WriteLine("Opening balance can not be less than Rs. 1000.");
                }
                else
                {
                    ConsoleLogger consoleLogger = new ConsoleLogger();
                    FileLogger fileLogger = new FileLogger();

                    UPIPayment upiPayment = new UPIPayment();
                    CashPayment cashPayment = new CashPayment();
                    CreditCardPayment creditCardPayment = new CreditCardPayment();

                    PaymentProcessor paymentProcessor;
                    RefundProcessor refundProcessor;

                    User user = new User(uname, openingBalance, fileLogger);

                    Console.WriteLine($"Initial available balance for {user.Username} is {user.AvailableBalance}\n");

                    int opChoice = 1, payChoice;
                    decimal amount = 0;

                    while (opChoice < 5)
                    {
                        Console.WriteLine("Enter what you want to do:\n1. Do Payment\n2. Get Refund\n3. Add Balance\n4. Show Available Balance\n5. Exit");
                        opChoice = Convert.ToInt32(Console.ReadLine());

                        switch (opChoice)
                        {
                            case 1:
                                Console.WriteLine("Select mode of payment:\n1. Cash\n2. UPI\n3. Credit Card");
                                payChoice = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter paying amount: ");
                                amount = Convert.ToDecimal(Console.ReadLine());

                                switch (payChoice)
                                {
                                    case 1:
                                        paymentProcessor = new PaymentProcessor(user, cashPayment, consoleLogger);
                                        paymentProcessor.Pay(amount);
                                        break;

                                    case 2:
                                        paymentProcessor = new PaymentProcessor(user, upiPayment, consoleLogger);
                                        paymentProcessor.Pay(amount);
                                        break;

                                    case 3:
                                        paymentProcessor = new PaymentProcessor(user, creditCardPayment, consoleLogger);
                                        paymentProcessor.Pay(amount);
                                        break;

                                    default:
                                        Console.WriteLine("Invalid choice for mode of payment. Please enter 1 to 3 only.");
                                        break;
                                }
                                break;

                            case 2:
                                Console.Write("Enter the amount you paid before and now you want refund of it: ");
                                amount = Convert.ToDecimal(Console.ReadLine());

                                refundProcessor = new RefundProcessor(user, upiPayment, fileLogger);
                                refundProcessor.Refund(amount);
                                break;

                            case 3:
                                Console.Write("Enter amount you want to add to your available balance: ");
                                amount = Convert.ToDecimal(Console.ReadLine());

                                user.AddBalance(amount);
                                break;

                            case 4:
                                Console.WriteLine($"Available balance for {user.Username} is {user.AvailableBalance}\n");
                                break;

                            case 5:
                                Console.WriteLine("Program terminated successfully.");
                                break;

                            default:
                                Console.WriteLine("Invalid input. Please enter only 1 to 4.");
                                break;
                        }

                        Console.WriteLine($"Available balance for {user.Username} is {user.AvailableBalance}\n");
                    }
                }
            }
        }
    }
}

using sim_cs_practicals.practical7.isp_lsp;
using sim_cs_practicals.practical7.ocp_lsp;
using sim_cs_practicals.practical7.srp_dip;

namespace sim_cs_practicals.practical7
{
    class Program
    {
        public static void Main(String[] args)
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

                if (decimal.TryParse(Console.ReadLine(), out decimal openingBalance))
                {
                    if (openingBalance < 1000)
                    {
                        Console.WriteLine("Opening balance can not be less than Rs. 1000.");
                    }
                    else
                    {
                        ConsoleLogger consoleLogger = ConsoleLogger.GetInstance();
                        FileLogger fileLogger = FileLogger.GetInstance();

                        UPIPayment upiPayment = UPIPayment.GetInstance();
                        CreditCardPayment creditCardPayment = CreditCardPayment.GetInstance();

                        PaymentProcessor paymentProcessor;
                        RefundProcessor refundProcessor;

                        UserManager user = new UserManager(uname, openingBalance, fileLogger);

                        Console.WriteLine($"Initial available balance for {user.Username} is {user.AvailableBalance}\n");

                        int opChoice = 1, payChoice;
                        decimal amount = 0;

                        while (opChoice < 5)
                        {
                            Console.WriteLine("Enter what you want to do:\n1. Do Payment\n2. Get Refund\n3. Add Balance\n4. Show Available Balance\n5. Exit");

                            if (int.TryParse(Console.ReadLine(), out opChoice))
                            {
                                switch (opChoice)
                                {
                                    case 1:
                                        Console.Write("Enter paying amount: ");

                                        if (decimal.TryParse(Console.ReadLine(), out amount))
                                        {
                                            Console.WriteLine("Select mode of payment:\n1. UPI\n2. Credit Card");

                                            if (int.TryParse(Console.ReadLine(), out payChoice))
                                            {
                                                switch (payChoice)
                                                {
                                                    case 1:
                                                        paymentProcessor = new PaymentProcessor(user, upiPayment, consoleLogger);
                                                        paymentProcessor.Pay(amount);
                                                        break;

                                                    case 2:
                                                        paymentProcessor = new PaymentProcessor(user, creditCardPayment, consoleLogger);
                                                        paymentProcessor.Pay(amount);
                                                        break;

                                                    default:
                                                        Console.WriteLine("Invalid choice for mode of payment. Please enter 1 or 2 only.");
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid input. Please select mode using numbers 1 or 2 only.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Please enter amount in numbers only.");
                                        }

                                        break;

                                    case 2:
                                        Console.Write("Enter the amount you paid before and now you want refund of it: ");

                                        if (decimal.TryParse(Console.ReadLine(), out amount))
                                        {
                                            refundProcessor = new RefundProcessor(user, upiPayment, fileLogger);
                                            refundProcessor.Refund(amount);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Please enter amount in numbers only.");
                                        }
                                        break;

                                    case 3:
                                        Console.Write("Enter amount you want to add to your available balance: ");

                                        if (decimal.TryParse(Console.ReadLine(), out amount))
                                        {
                                            user.AddBalance(amount);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Please enter amount in numbers only.");
                                        }
                                        break;

                                    case 4:
                                        Console.WriteLine($"Available balance for {user.Username} is {user.AvailableBalance}");
                                        break;

                                    case 5:
                                        Console.WriteLine("Program terminated successfully.");
                                        break;

                                    default:
                                        Console.WriteLine("Invalid input. Please enter only numbers from 1 to 5.");
                                        break;
                                }

                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please select operations using numbers 1 to 5 only.");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter balance in numbers only.");
                }
            }
        }
    }
}
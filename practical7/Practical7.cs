using sim_cs_practicals.practical7.srp_dip;
using sim_cs_practicals.practical7.isp_lsp;
using sim_cs_practicals.practical7.ocp_lsp;

namespace sim_cs_practicals.practical7
{
    class Practical7
    {
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
                        CashPayment cashPayment = CashPayment.GetInstance();
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
                            opChoice = Convert.ToInt32(Console.ReadLine());

                            switch (opChoice)
                            {
                                case 1:
                                    Console.Write("Enter paying amount: ");
                                    amount = Convert.ToDecimal(Console.ReadLine());

                                    Console.WriteLine("Select mode of payment:\n1. Cash\n2. UPI\n3. Credit Card");
                                    payChoice = Convert.ToInt32(Console.ReadLine());

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
                else
                {
                    Console.WriteLine("Invalid input. Please enter balance in numbers only.");
                }
            }
        }
    }
}
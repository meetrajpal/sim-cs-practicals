using practical8.models;
using practical8.models.accounts;
using practical8.repositories;
using practical8.services;

namespace practical8
{
    class Program
    {
        public static void Main(String[] args)
        {
            using AccountService accountService = AccountService.GetInstance(AccountRepository.GetInstance(), CustomerRepository.GetInstance());
            using CustomerService customerService = CustomerService.GetInstance(CustomerRepository.GetInstance());
            using TransactionService transactionService = TransactionService.GetInstance(AccountRepository.GetInstance());

            int choice = 0;
            Account? newAccount = null;

            while (choice < 6)
            {
                Console.Write("Enter what you want to perform from below Menu\n1 Create Customer\n2 Create Account (if you are new user then create a customer first)\n3 Deposit Money (you need account number and pin)\n4 Withdraw Money (you need account number and pin)\n5 Get monthly interest (you need account number and pin)\n6 Exit\nEnter your choice in numbers from 1 to 5 only: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter customer name: ");
                            string? custName = Console.ReadLine();

                            if (string.IsNullOrEmpty(custName) || string.IsNullOrWhiteSpace(custName))
                            {
                                Console.WriteLine("Customer name is required. It can not be empty.");
                            }
                            else
                            {
                                Customer? newCustomer = null;

                                try
                                {
                                    newCustomer = customerService.CreateCustomer(custName);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"An error occured while creating a new customer.\n{ex.Message}");
                                }
                                if (newCustomer != null)
                                {
                                    Console.WriteLine($"Customer created successfully with Customer ID: {newCustomer.CustomerId} \nPlease note this ID for further operations.");
                                }
                            }
                            break;

                        case 2:
                            newAccount = null;

                            Console.WriteLine("Enter your Customer ID (displayed after creating new Customer): ");
                            string? custId = Console.ReadLine();

                            if (string.IsNullOrEmpty(custId) || string.IsNullOrWhiteSpace(custId))
                            {
                                Console.WriteLine("Customer ID is required. It can not be empty.");
                            }
                            else
                            {
                                Console.Write("Select account type you want to create: \n1. Savings\n2. Current\n3. Loan\n4. Fixed Deposit \nEnter your choice in numbers from 1 to 4: ");

                                if (int.TryParse(Console.ReadLine(), out int accType))
                                {
                                    decimal amount = 0;

                                    switch ((AccountType)accType)
                                    {
                                        case AccountType.Savings:
                                            Console.WriteLine("Enter initial opening balance");
                                            if (decimal.TryParse(Console.ReadLine(), out amount) && amount >= 1000)
                                            {
                                                Console.Write("Enter 4 digit numeric pin for your account: ");
                                                if (int.TryParse(Console.ReadLine(), out int pin) && pin.ToString().Length == 4)
                                                {
                                                    try
                                                    {
                                                        newAccount = accountService.CreateAccount(custId, amount, AccountType.Savings, pin);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine($"An error occured while creating a new account.\n{ex.Message}");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid input. Enter 4 digit numeric pin only.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Enter amount in numbers only and opening balance for savings account must be minimum Rs. 1000");
                                            }
                                            break;

                                        case AccountType.Current:
                                            Console.WriteLine("Enter initial opening balance");
                                            if (decimal.TryParse(Console.ReadLine(), out amount) && amount >= 30000)
                                            {
                                                Console.Write("Enter 4 digit numeric pin for your account: ");
                                                if (int.TryParse(Console.ReadLine(), out int pin) && pin.ToString().Length == 4)
                                                {
                                                    try
                                                    {
                                                        newAccount = accountService.CreateAccount(custId, amount, AccountType.Current, pin);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine($"An error occured while creating a new account.\n{ex.Message}");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid input. Enter 4 digit numeric pin only.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Enter amount in numbers only and opening balance for current account must be minimum Rs. 30,000");
                                            }
                                            break;

                                        case AccountType.Loan:
                                            Console.WriteLine("Enter initial loan amount");
                                            if (decimal.TryParse(Console.ReadLine(), out amount) && amount >= 50000)
                                            {
                                                Console.Write("Enter 4 digit numeric pin for your account: ");
                                                if (int.TryParse(Console.ReadLine(), out int pin) && pin.ToString().Length == 4)
                                                {
                                                    try
                                                    {
                                                        newAccount = accountService.CreateAccount(custId, amount, AccountType.Loan, pin);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine($"An error occured while creating a new account.\n{ex.Message}");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid input. Enter 4 digit numeric pin only.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Enter amount in numbers only and loan amount must be minimum Rs. 50,000");
                                            }
                                            break;

                                        case AccountType.FixedDeposit:
                                            Console.WriteLine("Enter initial fixed deposit amount");
                                            if (decimal.TryParse(Console.ReadLine(), out amount) && amount >= 50000)
                                            {
                                                Console.Write("Enter 4 digit numeric pin for your account: ");
                                                if (int.TryParse(Console.ReadLine(), out int pin) && pin.ToString().Length == 4)
                                                {
                                                    try
                                                    {
                                                        newAccount = accountService.CreateAccount(custId, amount, AccountType.FixedDeposit, pin);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine($"An error occured while creating a new account.\n{ex.Message}");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid input. Enter 4 digit numeric pin only.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Enter amount in numbers only and fixed deposit amount must be minimum Rs. 50,000");
                                            }
                                            break;

                                        default:
                                            Console.WriteLine("Invalid input. Please select options from menu by entering numbers from 1 to 4 only.");
                                            break;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please select options from menu by entering numbers from 1 to 4 only.");
                                }
                            }
                            if (newAccount != null)
                            {
                                Console.WriteLine($"{newAccount.GetAccountType()} account created successfully with amount of {newAccount.Balance} and \nAccount Number: {newAccount.AccountNumber} \nPlease note this number for further operations.");
                            }
                            break;

                        case 3:
                            Console.WriteLine("Enter your Account Number: ");
                            string? accNo = Console.ReadLine();

                            if (string.IsNullOrEmpty(accNo) || string.IsNullOrWhiteSpace(accNo))
                            {
                                Console.WriteLine("Account number is required. It can not be empty.");
                            }
                            else
                            {
                                Console.WriteLine("Enter amount to deposit");
                                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount >= 1)
                                {
                                    Console.Write("Enter 4 digit numeric pin for your account: ");
                                    if (int.TryParse(Console.ReadLine(), out int pin) && pin.ToString().Length == 4)
                                    {
                                        try
                                        {
                                            transactionService.Deposit(accNo, amount, pin);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"An error occured while depositing amount.\n{ex.Message}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Enter 4 digit numeric pin only.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Enter amount in numbers only AND amount must be minimum Rs. 1");
                                }
                            }
                            break;

                        case 4:
                            Console.WriteLine("Enter your Account Number: ");
                            accNo = Console.ReadLine();

                            if (string.IsNullOrEmpty(accNo) || string.IsNullOrWhiteSpace(accNo))
                            {
                                Console.WriteLine("Account number is required. It can not be empty.");
                            }
                            else
                            {
                                Console.WriteLine("Enter amount to withdraw");
                                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount >= 1)
                                {
                                    Console.Write("Enter 4 digit numeric pin for your account: ");
                                    if (int.TryParse(Console.ReadLine(), out int pin) && pin.ToString().Length == 4)
                                    {
                                        try
                                        {
                                            transactionService.Withdraw(accNo, amount, pin);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"An error occured while depositing amount.\n{ex.Message}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Enter 4 digit numeric pin only.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Enter amount in numbers only AND amount must be minimum Rs. 1");
                                }
                            }
                            break;

                        case 5:
                            Console.WriteLine("Enter your Account Number: ");
                            accNo = Console.ReadLine();

                            if (string.IsNullOrEmpty(accNo) || string.IsNullOrWhiteSpace(accNo))
                            {
                                Console.WriteLine("Account number is required. It can not be empty.");
                            }
                            else
                            {

                                Console.Write("Enter 4 digit numeric pin for your account: ");
                                if (int.TryParse(Console.ReadLine(), out int pin) && pin.ToString().Length == 4)
                                {
                                    try
                                    {
                                        transactionService.CalculateMonthIntereset(accNo, pin);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"An error occured while calculating monthly interest.\n{ex.Message}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Enter 4 digit numeric pin only.");
                                }

                            }
                            break;

                        case 6:
                            Console.WriteLine("Program stopped successfully.");
                            break;

                        default:
                            Console.WriteLine("Invalid input. Please select options from menu by entering numbers from 1 to 6 only.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please select options from menu by entering numbers from 1 to 6 only.");
                }
                Console.WriteLine("");
            }
        }
    }
}

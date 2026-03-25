namespace sim_cs_practicals.practical1
{
    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Arithmetic Operations: \n");

            try
            {
                Console.Write("Enter first number (integer only): ");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter second number (integer only): ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                ArithmeticOperation operation = new Addition(num1, num2);
                Console.WriteLine($"\nSum of {num1} and {num2} is: {operation.Compute()}");

                operation = new Substraction(num1, num2);
                Console.WriteLine($"\nDifference between {num1} and {num2} is: {operation.Compute()}");

                operation = new Multiplication(num1, num2);
                Console.WriteLine($"\nProduct of {num1} and {num2} is {operation.Compute()}");

                operation = new Division(num1, num2);
                Console.WriteLine($"\nDivision of {num1} by {num2} is {operation.Compute():N3}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"\nYou have entered incorrect input. Please enter integers only. \n{ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"\nWhile performing calculations or your entered input is out of range of supported type integer. \n{ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"\nSecond number can not be zero for performing division. \n{ex.Message}");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine($"\nSome of the arithmetic operation is not possible or some error occured. \n{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nSome error occured while performing operations. \n{ex.Message}");
            }




            Console.Write("\nGive any input to check weather its integer or not: ");
            string? userResponse = Console.ReadLine();


            /*
             * int.Parse method will throw error for FormatException if any alphanumeric string is passed
               int.TryParse will return boolean value if the string is parsable to integer and out parameter will have that integer value
               we can ignore the out parameter using: int.TryParse(userResponse, out _)
            */
            if (int.TryParse(userResponse, out int value))
            {
                Console.WriteLine($"The entered value {value} is an integer.\n");
            }
            else
            {
                Console.WriteLine("The entered value is not an integer.\n");
            }
        }
    }
}
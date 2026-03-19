using System;

namespace sim_cs_practicals
{
    class Practical1
    {

        static string FormatDecimals(decimal num)
        {
            return $"{num:N3}";
        }
        public static void main(String[] args)
        {
            try
            {
                Console.Write("Enter first number: ");
                decimal num1 = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter second number: ");
                decimal num2 = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine($"\nSum of {FormatDecimals(num1)} and {FormatDecimals(num2)} is: {FormatDecimals(num1 + num2)}");
                Console.WriteLine($"\nDifference between {FormatDecimals(num1)} and {FormatDecimals(num2)} is: {FormatDecimals(num1 - num2)}");
                Console.WriteLine($"\nProduct of {FormatDecimals(num1)} and {FormatDecimals(num2)} is {FormatDecimals(num1 * num2)}");
                Console.WriteLine($"\nDivision of {FormatDecimals(num1)} by {FormatDecimals(num2)} is {FormatDecimals(num1 / num2)}");
            } catch (FormatException ex)
            {
                Console.WriteLine($"\nYou have entered incorrect input. \n{ex.Message}");
            } catch (DivideByZeroException ex)
            {
                Console.WriteLine($"\nSecond number can not be zero for performing division. \n{ex.Message}");
            } catch (OverflowException ex)
            {
                Console.WriteLine($"\nWhile performing calculations or your entered input is out of range of supported types. \n{ex.Message}");
            } catch (ArithmeticException ex)
            {
                Console.WriteLine($"\nSome of the arithmetic operation is not possible or some error occured. \n{ex.Message}");
            } catch(Exception ex)
            {
                Console.WriteLine($"\nSome error occured while performing operations. \n{ex.Message}");
            }
        }
    }
}
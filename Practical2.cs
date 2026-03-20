using System;
using System.Collections.Generic;
using System.Text;

namespace sim_cs_practicals
{
    class Customer_Account
    {
        public string Bank_Name { get; set; }
        public long Customer_AccountNo { get; set; } 

        public String Customer_Name { get; set; }

        public Customer_Account(long accNo, String custName)
        {
            this.Customer_AccountNo = accNo;
            this.Customer_Name = custName;
        }

        /*
         * 
         This method will print all the information about customer account and will not return anything.
         */
        public void PrintInfo()
        {
            Console.WriteLine($"Customer name: {this.Customer_Name}");
            Console.WriteLine($"Account number: {this.Customer_AccountNo}");
            Console.WriteLine($"Bank name: {this.Bank_Name}");
        }
    }
    class Practical2
    {
        public static void main(String[] args)
        {
            Customer_Account custAcc = new Customer_Account(132564987L, "Meet Rajpal") { Bank_Name = "BOB"};
            custAcc.PrintInfo();
        }
    }
}

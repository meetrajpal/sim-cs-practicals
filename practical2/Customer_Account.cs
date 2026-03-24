namespace sim_cs_practicals.practical2
{
    class Customer_Account
    {
        public string Bank_Name { get; set; }
        public long Customer_AccountNo { get; set; }

        public string Customer_Name { get; set; }

        public Customer_Account(long accNo, string custName)
        {
            this.Customer_AccountNo = accNo;
            this.Customer_Name = custName;
        }

        /// <summary>
        /// This method will return void / nothing and it will print all the information about customer account.
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Customer name: {this.Customer_Name}");
            Console.WriteLine($"Account number: {this.Customer_AccountNo}");
            Console.WriteLine($"Bank name: {this.Bank_Name}");
        }
    }
}

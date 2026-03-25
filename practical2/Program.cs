namespace sim_cs_practicals.practical2
{
    class Program
    {
        public static void Main(String[] args)
        {
            Customer_Account custAcc = new Customer_Account(132564987L, "Meet Rajpal") { Bank_Name = "BOB" };
            custAcc.PrintInfo();
        }
    }
}

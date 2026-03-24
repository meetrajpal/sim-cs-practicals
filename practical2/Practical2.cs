namespace sim_cs_practicals.practical2
{
    class Practical2
    {
        public static void main(String[] args)
        {
            Customer_Account custAcc = new Customer_Account(132564987L, "Meet Rajpal") { Bank_Name = "BOB" };
            custAcc.PrintInfo();
        }
    }
}

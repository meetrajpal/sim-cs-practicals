namespace practical8.utils
{
    static class Utility
    {
        private static long accNo = 0L;
        private static long custId = 0L;
        public static string GenerateAccountNo()
        {
            accNo++;
            return $"ACN{accNo}";
        }

        public static string GenerateCustomerId()
        {
            custId++;
            return $"CID{custId}";
        }
    }
}

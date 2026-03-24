namespace sim_cs_practicals.practical5
{
    class Practical5
    {
        public static void main(String[] args)
        {

            int[] arr = { 71, 32, 63, 44, 95 };

            for (int i = 0; i <= arr.Length; i++)
            {
                try
                {
                    Console.WriteLine($"{i + 1}: {arr[i]}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"You are trying to access index that is not available in accepted range of array. \n{ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Finally block executed.\n");
                }
            }

        }
    }
}

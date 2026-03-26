namespace practical8.utils;

/// <summary>
/// This is the utility class that has methods that provide auto generated ID for account number and customer ID
/// </summary>
internal static class Utility
{
    private static long accNo = 0L;
    private static long custId = 0L;

    /// <summary>
    /// This method generates account number for new account
    /// </summary>
    /// <returns>string of new account number</returns>
    public static string GenerateAccountNo()
    {
        accNo++;
        return $"ACN{accNo}";
    }

    /// <summary>
    /// This method generates customer ID for new customer
    /// </summary>
    /// <returns>string of new customer ID</returns>
    public static string GenerateCustomerId()
    {
        custId++;
        return $"CID{custId}";
    }
}

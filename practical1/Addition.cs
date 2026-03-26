namespace practical1;

/// <summary>
/// This is class for addition operations
/// </summary>
internal class Addition : ArithmeticOperation
{
    /// <summary>
    /// This is public constructor to initialize number 1 and number 2
    /// </summary>
    public Addition(int n1, int n2) : base(n1, n2) { }

    /// <summary>
    /// This is method will perform addition on both numbers and will return result.
    /// </summary>
    public override decimal Compute()
    {
        return Number1 + Number2;
    }
}
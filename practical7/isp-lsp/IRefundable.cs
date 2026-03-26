namespace practical7.isp_lsp;


/// <summary>
/// IRefundable interface creates a contract list of required methods for refund purposes.
/// </summary>
internal interface IRefundable
{
    public void Refund(decimal amount);
}

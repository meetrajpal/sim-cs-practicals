namespace sim_cs_practicals.practical7.isp_lsp
{
    /// <summary>
    /// IPaymentMethod interface creates a contract list of required methods for payment purposes.
    /// </summary>
    interface IPaymentMethod
    {
        public void Pay(decimal amount);
    }
}

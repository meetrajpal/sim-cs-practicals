namespace sim_cs_practicals.practical7.loggers
{
    /// <summary>
    /// Console logger logs statements in console
    /// </summary>
    class ConsoleLogger : Logger
    {
        /// <summary>
        /// This method will log the information statements in console
        /// </summary>
        /// <param name="msg">Message that should be logged</param>
        public override void LogError(string msg)
        {
            Console.WriteLine($"ERROR: {msg}");
        }

        /// <summary>
        /// This method will log the error statements in console
        /// </summary>
        /// <param name="msg">Error message that should be logged</param>
        public override void LogInfo(string msg)
        {
            Console.WriteLine($"INFO: {msg}");
        }
    }

}

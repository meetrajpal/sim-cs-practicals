namespace sim_cs_practicals.practical7.ocp_lsp
{
    /// <summary>
    /// Console logger logs statements in console
    /// </summary>
    class ConsoleLogger : Logger
    {
        /// <summary>
        /// This is instance of class and it is used to ensure there is only one instance of this class
        /// </summary>
        private static ConsoleLogger? Instance = null;

        /// <summary>
        /// This is the private constructor of the class to restrict object creation from outside of the class
        /// </summary>
        private ConsoleLogger() { }

        /// <summary>
        /// This method will return single instance of this class
        /// </summary>
        /// <returns>Instance of Console Logger</returns>
        public static ConsoleLogger GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ConsoleLogger();
            }
            return Instance;
        }

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

namespace sim_cs_practicals.practical7.ocp_lsp
{
    /// <summary>
    /// Console logger logs statements in text file
    /// </summary>
    class FileLogger : Logger
    {
        /// <summary>
        /// This is instance of class and it is used to ensure there is only one instance of this class
        /// </summary>
        private static FileLogger? Instance = null;

        /// <summary>
        /// This is the private constructor of the class to restrict object creation from outside of the class
        /// </summary>
        private FileLogger() { }

        /// <summary>
        /// This method will return single instance of this class
        /// </summary>
        /// <returns></returns>
        public static FileLogger GetInstance()
        {
            if (Instance == null)
            {
                Instance = new FileLogger();
            }
            return Instance;
        }

        /// <summary>
        /// This method will log the information statements in text file
        /// </summary>
        /// <param name="msg">Message that should be logged</param>
        public override void LogError(string msg)
        {
            Console.WriteLine($"Logging in File: ERROR: {msg}");
            File.AppendAllText("logs.txt", $"Logging in File: ERROR: {msg}");
        }

        /// <summary>
        /// This method will log the error statements in text file
        /// </summary>
        /// <param name="msg">Error message that should be logged</param>
        public override void LogInfo(string msg)
        {
            Console.WriteLine($"Logging in File: INFO: {msg}");
            File.AppendAllText("logs.txt", $"Logging in File: INFO: {msg}");
        }
    }

}

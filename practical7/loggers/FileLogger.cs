namespace sim_cs_practicals.practical7.loggers
{
    /// <summary>
    /// Console logger logs statements in text file
    /// </summary>
    class FileLogger : Logger
    {
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

namespace sim_cs_practicals.practical7.loggers
{
    /// <summary>
    /// (Open - Close Principle)
    /// This below code section handles all logging operations.
    /// Any more logging method can be included without modifying existing code.
    /// </summary>
    abstract class Logger
    {
        /// <summary>
        /// This method will log the information statements
        /// </summary>
        /// <param name="msg">Message that should be logged</param>
        public abstract void LogInfo(string msg);

        /// <summary>
        /// This method will log the error statements
        /// </summary>
        /// <param name="msg">Error message that should be logged</param>
        public abstract void LogError(string msg);
    }

}

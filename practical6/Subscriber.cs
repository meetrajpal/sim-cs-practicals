namespace sim_cs_practicals.practical6
{
    class Subscriber
    {
        /// <summary>
        /// This method will return void / nothing. It will get registered with Process Completed event and will called when the event occurs.
        /// </summary>
        /// <param name="sender">Object that invoked the event</param>
        /// <param name="args">Arguments that will be passed</param>
        public static void bl_ProcessComplete(object? sender, EventArgs args)
        {
            Console.WriteLine("Process Completed.");
        }
    }
}

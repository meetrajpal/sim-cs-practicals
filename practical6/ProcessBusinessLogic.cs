namespace sim_cs_practicals.practical6
{
    class ProcessBusinessLogic
    {
        public static event EventHandler? ProcessCompleted;

        /// <summary>
        /// This method will return void / nothing. It will print process started and call process completed method.
        /// </summary>
        public void StartProcess()
        {
            Console.WriteLine("Process started.");
            OnProcessCompleted();
        }

        /// <summary>
        /// This method will return void / nothing and it will invoke the ProcessCompleted event.
        /// </summary>
        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke(this, new EventArgs());
        }
    }
}

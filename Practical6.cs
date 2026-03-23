namespace sim_cs_practicals
{
    class ProcessBusinessLogic
    {
        public event EventHandler? ProcessCompleted;

        /*
         * This method will return void / nothing. It will print process started and call process completed method.
         */
        public void StartProcess()
        {
            Console.WriteLine("Process started.");
            OnProcessCompleted();
        }

        /*
         * This method will return void / nothing and it will invoke the ProcessCompleted event.
         */
        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke(this, new EventArgs());
        }
    }
    class Practical6
    {
        /*
         * This method will return void / nothing. It will get registered with Process Completed event and will called when the event occurs.
         */
        public void bl_ProcessComplete(object? sender, EventArgs args)
        {
            Console.WriteLine("Process Completed.");
        }
        public static void main(String[] args)
        {
            ProcessBusinessLogic publisher = new ProcessBusinessLogic();

            Practical6 subscriber = new Practical6();

            publisher.ProcessCompleted += subscriber.bl_ProcessComplete;

            publisher.StartProcess();
        }
    }
}

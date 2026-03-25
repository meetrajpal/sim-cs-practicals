namespace sim_cs_practicals.practical6
{
    class Program
    {
        public static void Main(String[] args)
        {
            ProcessBusinessLogic.Subscribe(Subscriber.bl_ProcessComplete);

            ProcessBusinessLogic publisher = ProcessBusinessLogic.GetInstance();
            publisher.StartProcess();
        }
    }
}

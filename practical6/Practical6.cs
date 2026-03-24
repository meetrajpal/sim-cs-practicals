namespace sim_cs_practicals.practical6
{
    class Practical6
    {
        public static void main(String[] args)
        {
            ProcessBusinessLogic.Subscribe(Subscriber.bl_ProcessComplete);

            ProcessBusinessLogic publisher = ProcessBusinessLogic.GetInstance();
            publisher.StartProcess();
        }
    }
}

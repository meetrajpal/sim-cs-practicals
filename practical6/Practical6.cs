namespace sim_cs_practicals.practical6
{
    class Practical6
    {
        public static void main(String[] args)
        {
            ProcessBusinessLogic publisher = new ProcessBusinessLogic();

            ProcessBusinessLogic.ProcessCompleted += Subscriber.bl_ProcessComplete;

            publisher.StartProcess();
        }
    }
}

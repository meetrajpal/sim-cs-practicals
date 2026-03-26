namespace practical6;

internal class Program
{
    public static void Main(String[] args)
    {
        ProcessBusinessLogic.Subscribe(Subscriber.bl_ProcessComplete);

        ProcessBusinessLogic publisher = ProcessBusinessLogic.GetInstance();
        publisher.StartProcess();
    }
}

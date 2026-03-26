namespace practical6;

internal class ProcessBusinessLogic
{
    private static event EventHandler? ProcessCompleted;

    private static ProcessBusinessLogic? Instance = null;

    private ProcessBusinessLogic() { }

    public static ProcessBusinessLogic GetInstance()
    {
        if (Instance == null)
        {
            Instance = new ProcessBusinessLogic();
        }

        return Instance;
    }

    /// <summary>
    /// This method is static and returns void / nothing
    /// This method will register the event handler to the ProcessCompleted event without any duplicate handlers.
    /// </summary>
    /// <param name="handler">The event handler method that needs to be registered</param>
    public static void Subscribe(EventHandler handler)
    {
        if (ProcessCompleted == null || !ProcessCompleted.GetInvocationList().Contains(handler))
        {
            ProcessCompleted += handler;
        }
    }

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

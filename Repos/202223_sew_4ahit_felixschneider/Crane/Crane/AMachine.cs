namespace Crane;

public abstract class AMachine : IMachine
{
    public virtual void Run()
    {
        while (true)
        {
            Process();
        }
    }

    public virtual void Process()
    {
        Thread.Sleep(200);
        Console.WriteLine("AMachine: finished work!");
    }
}
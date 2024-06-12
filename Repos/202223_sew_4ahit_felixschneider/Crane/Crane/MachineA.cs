namespace Crane;

public class MachineA : AMachine
{
    public SemaphoreSlim semaphoreMachineA = new SemaphoreSlim(0);
    public SemaphoreSlim semaphoreCrane;

    public MachineA(SemaphoreSlim semaphoreCrane)
    {
        this.semaphoreCrane = semaphoreCrane;
    }
    
    public override void Run()
    {
        while (true)
        {
            semaphoreMachineA.Wait();
            Process();
            semaphoreCrane.Release();
        }
    }

    public override void Process()
    {
        Thread.Sleep(200);
        Console.WriteLine("Machine A: finished work!");
    }
}
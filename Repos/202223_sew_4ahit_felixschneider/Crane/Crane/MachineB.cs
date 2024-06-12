namespace Crane;

public class MachineB : AMachine
{
    public SemaphoreSlim semaphoreMachineB = new SemaphoreSlim(0);
    public SemaphoreSlim semaphoreCrane;
    
    public MachineB(SemaphoreSlim semaphoreCrane)
    {
        this.semaphoreCrane = semaphoreCrane;
    }
    
    public override void Run()
    {
        while (true)
        {
            semaphoreMachineB.Wait();
            Process();
            semaphoreCrane.Release();
        }
    }

    public override void Process()
    {
        Thread.Sleep(200);
        Console.WriteLine("Machine B: finished work!");
    }
}
namespace Crane;

public class CraneClass
{
    private SemaphoreSlim semaphoreCrane;
    public MachineA MachineA;
    public MachineB MachineB;

    public CraneClass(SemaphoreSlim semaphoreCrane, MachineA ma, MachineB mb)
    {
        this.semaphoreCrane = semaphoreCrane;
        MachineA = ma;
        MachineB = mb;
    }
    
    public void Run()
    {
        
        while (true)
        {
            Move("storage", "Machine A");
            MachineA.semaphoreMachineA.Release();
            semaphoreCrane.Wait();
            Move("Machine A", "Machine B");
            MachineB.semaphoreMachineB.Release();
            semaphoreCrane.Wait();
            Move("Machine B", "storage");
        }
    }

    public void Move(string from, string to)
    {
        Thread.Sleep(200);
        Console.WriteLine($"moving from {from} to {to}");
    }
}
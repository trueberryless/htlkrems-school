namespace Conveyor; 

public class MachineA
{
    public static SemaphoreSlim Handshake = new SemaphoreSlim(0);
        
    public void Run() {
        while (true)
        {
            Handshake.Wait();
            Process();
            ConveyorBelt.Handshake.Release();
        }
    }

    private void Process() {
        Thread.Sleep(600);
        Console.WriteLine($"machine a: processed device");
    }
}
namespace Conveyor; 

public class MachineB {
    public static SemaphoreSlim Handshake = new SemaphoreSlim(0);
        
    public void Run() {

        while (true) {
            Handshake.Wait();
            Process();
            ConveyorBelt.Handshake.Release();
        }
    }

    private void Process() {
        Thread.Sleep(500);
        Console.WriteLine($"machine b: processed device");
    }
}
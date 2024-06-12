namespace Conveyor; 

public class ConveyorBelt {
    public static SemaphoreSlim Handshake = new SemaphoreSlim(1);
        
    public void Run() {
        Move();
        MachineA.Handshake.Release();
        while (true)
        {
            Handshake.Wait();
            Handshake.Wait();
            Move();
            MachineA.Handshake.Release();
            MachineB.Handshake.Release();
        }
    }

    private void Move() {
        Thread.Sleep(500);
        Console.WriteLine($"conveyor belt: moving conveyor belt");
    }
}
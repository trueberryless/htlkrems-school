namespace Conveyor;

public class ConveyorBelt
{
    static public SemaphoreSlim BeltGuard = new SemaphoreSlim(2);

    public void Run()
    {
        while (true)
        {
            foreach (var maschineHandshake in Maschine.MaschineHandshakes)
            {
                BeltGuard.Wait();
            }

            Move();

            foreach (var maschineHandshake in Maschine.MaschineHandshakes)
            {
                maschineHandshake.Value.Release();
            }
        }
    }

    public void Move()
    {
        Console.WriteLine("ConveyorBelt moved");
    }
}
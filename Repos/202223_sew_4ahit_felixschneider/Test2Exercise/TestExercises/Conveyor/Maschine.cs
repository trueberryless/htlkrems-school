using System.Diagnostics;

namespace Conveyor;

public class Maschine
{
    static public Dictionary<string, SemaphoreSlim> MaschineHandshakes = new Dictionary<string, SemaphoreSlim>();
    public int Speed { get; set; }
    public string Name { get; set; }

    public Maschine(string name, int speed, SemaphoreSlim handshake)
    {
        Speed = speed;
        Name = name;

        MaschineHandshakes.Add(name, handshake);
    }

    public void Run()
    {
        while (true)
        {
            MaschineHandshakes[Name].Wait();
            
            Process();

            ConveyorBelt.BeltGuard.Release();
        }
    }

    public void Process()
    {
        Thread.Sleep(Speed);
        Console.WriteLine($"{Name}: finished process");
    }
}
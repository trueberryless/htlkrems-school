using System.Runtime.CompilerServices;

namespace GhostTrainGruft;

public class GhostTrain
{
    public static SemaphoreSlim DepartHandshake = new SemaphoreSlim(0);

    public void Run()
    {
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                DepartHandshake.Wait();
            }

            Depart();

            Thread.Sleep(13000);

            Arrive();

            Customer.CanLeaveHandshake.Release(5);
        }
    }

    private void Depart()
    {
        Console.WriteLine("Departing");
        Thread.Sleep(100);
    }

    private void Arrive()
    {
        Console.WriteLine("Ending Ride");
        Thread.Sleep(1000);
    }
}
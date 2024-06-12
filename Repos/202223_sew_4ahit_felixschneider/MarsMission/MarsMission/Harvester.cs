namespace MarsMission;

public class Harvester
{
    public string Code { get; set; }

    public static SemaphoreSlim harvesterSemaphore = new SemaphoreSlim(0);
    public static SemaphoreSlim maxharvesterstore = new SemaphoreSlim(2);

    public Harvester(string code)
    {
        Code = code;
    }

    public void Run()
    {
        while (true)
        {
            harvesterSemaphore.Wait();
            Acknowledge();
            Sentinel.sentinelSemaphore.Release();
            Harvest();
            maxharvesterstore.Wait();
            Store();
            maxharvesterstore.Release();
        }
    }

    private void Acknowledge()
    {
        Thread.Sleep(100);
        Console.WriteLine($"{Code}: Acknowledge signal");
    }

    private void Harvest()
    {
        Console.WriteLine($"{Code}: Harvesting resources");
        Thread.Sleep(1000);
    }

    private void Store()
    {
        Console.WriteLine($"{Code}: Storing resources");
        Thread.Sleep(200);
    }
}
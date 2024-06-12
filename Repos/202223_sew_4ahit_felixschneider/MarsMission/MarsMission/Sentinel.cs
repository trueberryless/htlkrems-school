namespace MarsMission;

public class Sentinel
{
    public string Code { get; set; }

    public static SemaphoreSlim sentinelSemaphore = new SemaphoreSlim(0);

    public Sentinel(string code)
    {
        Code = code;
    }

    public void Run()
    {
        while (true)
        {
            ScanningSurface();
            Signal();
            sentinelSemaphore.Wait();
            Harvester.harvesterSemaphore.Release();
        }
    }

    private void ScanningSurface()
    {
        Console.WriteLine($"{Code}: Scanning Surface");
        Thread.Sleep(500);
    }

    private void Signal()
    {
        Thread.Sleep(800);
        Console.WriteLine($"{Code}: Found raw material");
    }
}
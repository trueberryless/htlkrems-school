namespace Racing; 

public class F1Race
{
    public static SemaphoreSlim RaceStart = new SemaphoreSlim(0);
    public static SemaphoreSlim RaceEnd = new SemaphoreSlim(0);
    
    public int CarCount { get; set; }

    public F1Race() { }

    public F1Race(int carcount)
    {
        CarCount = carcount;
    }

    public void Run()
    {
        for (int i = 0; i < CarCount; i++)
        {
            RaceStart.Wait();
        }
        Start();
        Car.CarHandshake.Release(5);
        for (int i = 0; i < CarCount; i++)
        {
            RaceEnd.Wait();
        }
        End();
    }
    private void Start(){
        Console.WriteLine("Starting Race");
        Thread.Sleep(1000);
    }
    private void End(){
        Console.WriteLine("Race finished");
    }

}
namespace Racing; 

public class Car
{
    public static SemaphoreSlim CarHandshake = new SemaphoreSlim(0);
    public static SemaphoreSlim PistopGuard = new SemaphoreSlim(3);

    public string Racer { get; set; }

    public Car(string racer) {
        Racer = racer;
    }
    
    public void Run()
    {
        F1Race.RaceStart.Release();
        WaitForSignal();
        CarHandshake.Wait();
        Race();
        PistopGuard.Wait();
        TakingPistop();
        PistopGuard.Release();
        Race();
        F1Race.RaceEnd.Release();
    }
    private void WaitForSignal(){
        Console.WriteLine(
            $"{Racer}: Waiting for Start Signal"
        );
        Thread.Sleep(200);
    }

    private void Race() {
        Console.WriteLine($"{Racer}: Racing");
        Thread.Sleep(500);
    }
    private void TakingPistop(){
        Console.WriteLine($"{Racer}: Taking Pit stop");
        Thread.Sleep(500);
    }

    
}
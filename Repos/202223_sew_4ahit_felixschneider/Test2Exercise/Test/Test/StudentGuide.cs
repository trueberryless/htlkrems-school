namespace Test;

public class StudentGuide
{
    public static SemaphoreSlim GroupHandshake = new SemaphoreSlim(0);
    public static SemaphoreSlim EndingHandshake = new SemaphoreSlim(0);
    
    
    public void Run()
    {
        while (true)
        {
            GroupHandshake.Release();
            VisitorGroup.StudentHandshake.Wait();
            BeginningTour();


            EndingHandshake.Wait();
            EndingTour();
            
            
        }
    }

    private void BeginningTour()
    {
        Console.WriteLine("Beginning Tour");
        Thread.Sleep(500);
    }

    private void EndingTour()
    {
        Thread.Sleep(800);
        Console.WriteLine("Ending Tour");
    }
}
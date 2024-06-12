namespace GhostTrainGruft;

public class Customer
{
    public static SemaphoreSlim TicketGuard = new SemaphoreSlim(3);
    public static SemaphoreSlim WaitingGuard = new SemaphoreSlim(10);
    public static SemaphoreSlim TrainCapacityGuard = new SemaphoreSlim(5);
    public static SemaphoreSlim CanLeaveHandshake = new SemaphoreSlim(0);
    
    public void Run()
    {
        while (true)
        {
            WaitingGuard.Wait();
            TicketGuard.Wait();
            
            BuyTicket();

            TicketGuard.Release();
            
            EnterWaitingArea();

            TrainCapacityGuard.Wait();
            
            EnterTrain();

            WaitingGuard.Release();
            GhostTrain.DepartHandshake.Release();
            CanLeaveHandshake.Wait();
            
            LeaveTrain();

            TrainCapacityGuard.Release();
        }
    }
    
    private void BuyTicket()
    {
        Console.WriteLine("Buying Ticket");
        Thread.Sleep(500);
    }
    
    private void EnterWaitingArea()
    {
        Console.WriteLine("Entering Waiting Area");
        Thread.Sleep(100);
    }
    
    private void EnterTrain()
    {
        Console.WriteLine("Entering Train");
        Thread.Sleep(200);
    }
    
    private void LeaveTrain()
    {
        Console.WriteLine("Leaving Train");
        Thread.Sleep(300);
    }
}
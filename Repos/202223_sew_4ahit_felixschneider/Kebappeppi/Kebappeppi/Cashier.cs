namespace Kebappeppi;

public class Cashier
{
    public string Name { get; set; }

    public static SemaphoreSlim CashierSemaphore = new SemaphoreSlim(0);
    private SemaphoreSlim CashierMaxCustomers;
    
    public Cashier(string name)
    {
        Name = name;
        CashierMaxCustomers = new SemaphoreSlim(1);
    }

    public void Run()
    {
        while (true)
        {
            CashierMaxCustomers.Wait();
            CashierSemaphore.Wait();
            Confirm();
            CashierMaxCustomers.Release();
        }
    }

    public void Confirm()
    {
        Console.WriteLine($"{Name}:\t confirm payment");
        Thread.Sleep(1818);
    }
}
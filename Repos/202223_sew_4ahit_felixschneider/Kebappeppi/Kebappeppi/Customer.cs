namespace Kebappeppi;

public class Customer
{
    public string Name { get; set; }

    public static SemaphoreSlim CustomerSemaphore = new SemaphoreSlim(0);

    public Customer(string name)
    {
        Name = name;
    }

    public void Run()
    {
        Order();
        Cook.CookSemaphore.Release();
        CustomerSemaphore.Wait();
        Pay();
        Cashier.CashierSemaphore.Release();
    }

    private void Order()
    {
        Console.WriteLine($"{Name}:\t ordering food");
        Thread.Sleep(1917);
    }

    private void Pay()
    {
        Console.WriteLine($"{Name}:\t paying order");
        Thread.Sleep(1989);
    }
}
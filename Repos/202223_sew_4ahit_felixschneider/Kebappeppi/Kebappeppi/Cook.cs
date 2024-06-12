namespace Kebappeppi;

public class Cook
{
    public string Name { get; set; }

    public static SemaphoreSlim CookSemaphore = new SemaphoreSlim(0);

    public Cook(string name)
    {
        Name = name;
    }

    public void Run()
    {
        while (true)
        {
            CookSemaphore.Wait();
            PrepareMeal();
            Customer.CustomerSemaphore.Release();
        }
    }

    public void PrepareMeal()
    {
        Console.WriteLine($"{Name}:\t cooking food");
        Thread.Sleep(1818);
    }
}
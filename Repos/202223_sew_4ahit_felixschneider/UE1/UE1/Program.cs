
ElectricGenerator.Capacity = 1000;

var laptop = new Machine
{
    MachineName = "Company Notebook",
    Vendor = "Lenovo",
    EnergyConsumption = 270
};

var drill = new Machine
{
    MachineName = "Drill",
    Vendor = "Bosch",
    EnergyConsumption = 100
};

var officeLights = Enumerable.Repeat(new LightSource(), 10);

ElectricGenerator.AddConsumers(officeLights);
ElectricGenerator.AddConsumer(laptop);
ElectricGenerator.AddConsumer(drill);
Console.WriteLine($"Current consumption: { ElectricGenerator.CurrentConsumption} of { ElectricGenerator.Capacity}");
try
{
    Console.WriteLine("Attaching heavy consumer...");
    ElectricGenerator.AddConsumer(new Machine { EnergyConsumption = 2000 });
}
catch (Exception ex)
{
    Console.WriteLine($"OK, I wont't attach it. ({ex.Message})");
}

var lenovoMachines = ElectricGenerator.GetConsumerBy(c => c is Machine m ? m.Vendor == "Lenovo" : false);
Console.WriteLine($"There are {lenovoMachines.Count()} Lenovo machines attached");


public static class ElectricGenerator
{
    public static int Capacity { get; set; }

    public static int CurrentConsumption 
    { 
        get {
            int currentConsumption = 0;
            foreach (var item in Consumers)
            {
                currentConsumption += item.EnergyConsumption;
            }
            return currentConsumption;
        }
    }

    public static int FreeCapacity 
    { 
        get
        {
            return Capacity - CurrentConsumption;
        }
    }

    private static List<Consumer> Consumers = new List<Consumer>();

    public static void AddConsumer(Consumer consumer)
    {
        if (CurrentConsumption + consumer.EnergyConsumption > Capacity)
            throw new NotEnoughCapacityException();
        else Consumers.Add(consumer);
    }

    public static void AddConsumers(IEnumerable<Consumer> consumers)
    {
        foreach (var item in consumers)
        {
            AddConsumer(item);
        }
    }

    public static void DeleteConsumer(int index)
    {
        Consumers.RemoveAt(index);
    }

    public static void DeleteConsumer(Consumer consumer)
    {
        Consumers.Remove(consumer);
    }

    public static List<Consumer> GetConsumerBy(Predicate<Consumer> pre)
    {
        List<Consumer> trueconsumers = new List<Consumer>();
        foreach (var item in Consumers)
        {
            if(pre.Invoke(item))
            {
                trueconsumers.Add(item);
            }
        }
        return trueconsumers;
    }
}

public class Consumer : IEnergyConsumer
{
    public int EnergyConsumption { get; set; }

    public int GetCurrentConsumption()
    {
        return EnergyConsumption;
    }
}

public class Machine : Consumer
{
    public string? MachineName { get; set; }

    public string? Vendor { get; set; }
}

public class LightSource : Consumer
{
    public bool IsDark { get; set; }
}

public interface IEnergyConsumer
{
    public int GetCurrentConsumption();
}

public class NotEnoughCapacityException : Exception
{
    public NotEnoughCapacityException() : base("There is not enough capacity!") { }
    public NotEnoughCapacityException(string message) : base(message) { }
    public NotEnoughCapacityException(string message, Exception innerException) : base(message, innerException) { }
}
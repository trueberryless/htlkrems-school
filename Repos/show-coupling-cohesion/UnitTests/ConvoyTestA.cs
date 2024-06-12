using LastAurora;
using LastAurora.Exceptions;

namespace UnitTests;

public class ConvoyTestA
{
    private Convoy convoy;
    private Truck truck1;
    private Truck truck2;
    private Waggon waggon1;
    private Waggon waggon2;
    
    private Slot slot11;
    private Slot slot12;
    private Slot slot13;
    private Slot slot14;
    private Slot slot21;
    private Slot slot22;
    private Slot slot23;
    private Slot slot24;
    private Slot slot31;
    private Slot slot32;
    private Slot slot33;
    private Slot slot34;
    private Slot slot41;
    private Slot slot42;
    private Slot slot43;
    private Slot slot44;
    
    
    [SetUp]
    public void Setup()
    {
        #region Generate Convoy

        convoy = new Convoy();

        truck1 = new Truck("Biofuel Truck", 80_000, 4, 3, 4, "Truck");
        slot11 = new Slot(SlotType.Machinery, "Biofuel Generator");
        slot12 = new Slot(SlotType.Machinery, "Gatlinggun", "Gatlinggun", "Gatlinggun");
        slot13 = new Slot(SlotType.Predestined, "Crew");
        slot14 = new Slot(SlotType.Default);
        truck1.AddSlot(slot11);
        truck1.AddSlot(slot12);
        truck1.AddSlot(slot13);
        truck1.AddSlot(slot14);
        
        truck2 = new Truck("Nuclearpowered Truck", 100_000, 4, 3, 2, "Truck");
        slot21 = new Slot(SlotType.Machinery, "Nucleargenerator");
        slot22 = new Slot(SlotType.Machinery, "Heavy Ordnanace", "Heavy Ordnanace", "Heavy Ordnanace");
        slot23 = new Slot(SlotType.Predestined, "Crew");
        slot24 = new Slot(SlotType.Default);
        truck2.AddSlot(slot21);
        truck2.AddSlot(slot22);
        truck2.AddSlot(slot23);
        truck2.AddSlot(slot24);

        waggon1 = new Waggon("Reinforced Waggon", 7_000, 4, "Waggon");
        slot31 = new Slot(SlotType.Default);
        slot32 = new Slot(SlotType.Default);
        slot33 = new Slot();
        slot34 = new Slot(SlotType.Machinery, "Plating");
        waggon1.AddSlot(slot31);
        waggon1.AddSlot(slot32);
        waggon1.AddSlot(slot33);
        waggon1.AddSlot(slot34);
        
        waggon2 = new Waggon("Medical Waggon", 15_000, 4, "Waggon");
        slot41 = new Slot(SlotType.Predestined, "Crew");
        slot42 = new Slot(SlotType.Predestined, "Crew");
        slot43 = new Slot(SlotType.Predestined, "Fuel");
        slot44 = new Slot(SlotType.Machinery, "Medicalbay", "Nucleargenerator");
        waggon2.AddSlot(slot41);
        waggon2.AddSlot(slot42);
        waggon2.AddSlot(slot43);
        waggon2.AddSlot(slot44);

        convoy.AddTruck(truck1);
        convoy.AddTruck(truck2);
        
        convoy.AddWaggon(waggon1);
        convoy.AddWaggon(waggon2);

        #endregion
    }

    [Test]
    public void FrontBackTruck()
    {
        Assert.That(convoy.IsFrontTruck(truck1), Is.EqualTo(true));
        Assert.That(convoy.IsFrontTruck(truck2), Is.EqualTo(false));
        Assert.That(convoy.IsBackTruck(truck1), Is.EqualTo(false));
        Assert.That(convoy.IsBackTruck(truck2), Is.EqualTo(true));
    }
    
    [Test]
    public void Speed()
    {
        Assert.That(convoy.Speed, Is.EqualTo(4));
    }
    
    [Test]
    public void Power()
    {
        Assert.That(convoy.Power, Is.EqualTo(6));
    }
    
    [Test]
    public void WaggonsLeft()
    {
        int counter = 0;
        try
        {
            while (true)
            {
                var waggon = new Waggon("Reinforced Fuelwaggon Mach II", 12_000, 4, "Waggon");
                convoy.AddWaggon(waggon);
                counter++;
            }
        }
        catch (NotEnoughPowerException)
        {
            Assert.That(counter, Is.EqualTo(4));
        }
    }

    [Test]
    public void CountWaggons()
    {
        Assert.That(convoy.Count<Waggon>(), Is.EqualTo(2));
        Assert.That(convoy.Power - convoy.Count<Waggon>(), Is.EqualTo(4));
    }
}
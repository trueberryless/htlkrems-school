/*
using System.Collections.Immutable;
using LastAurora;

namespace UnitTests;

public class TestCompositePattern
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test()
    {
        Convoy c = new Convoy();
        
        Truck t1 = new Truck("Tank",10,10_000,5, 4);
        t1.SlotSpace.AddSlot(new Slot("Tracks", SlotType.Machinery));
        t1.SlotSpace.AddSlot(new Slot("Heavy Ordnance 2", SlotType.Machinery));
        t1.SlotSpace.AddSlot(new Slot());
        t1.SlotSpace.AddSlot(new Slot());

        Waggon w11 = new Waggon("StorageWaggon",1000, 4);
        w11.SlotSpace.AddSlot(new Slot("Gunner", SlotType.Predestined));
        w11.SlotSpace.AddSlot(new Slot("Heavy Gunner", SlotType.Predestined));
        
        Waggon w12 = new Waggon("StorageWaggon",1000, 4);
        w12.SlotSpace.AddSlot(new Slot("Chief", SlotType.Predestined));
        w12.SlotSpace.AddSlot(new Slot("Heavy Gunner", SlotType.Predestined));
        
        Addon a121 = new Addon("BIG GUNN", 100,2);
        a121.SlotSpace.AddSlot(new Slot("BIGGUN",SlotType.Machinery));
        a121.SlotSpace.AddSlot(new Slot("Gunner",SlotType.Predestined));
        w12.AddonSpace.AddAddon(a121);
        
        t1.WaggonSpace.AddWaggon(w11);
        t1.WaggonSpace.AddWaggon(w12);
        
        Truck t2 = new Truck("Tank",10,10_000,5,4);
        t2.SlotSpace.AddSlot(new Slot("Tires", SlotType.Machinery));
        t2.SlotSpace.AddSlot(new Slot("Gun", SlotType.Machinery));
        t2.SlotSpace.AddSlot(new Slot());
        t2.SlotSpace.AddSlot(new Slot());
        
        Waggon w21 = new Waggon("AtomBombTransporter",1000, 2);
        w21.SlotSpace.AddSlot(new Slot("AtomBomb", SlotType.Machinery));
        w21.SlotSpace.AddSlot(new Slot("Amok Runner", SlotType.Predestined));
        
        t2.WaggonSpace.AddWaggon(w21);

        c.SetFrontTruck(t1);
        c.SetBackTruck(t2);
        
        Console.WriteLine(c.ReportKeywords());

        List<string> keywords = new List<string>()
        {
            "Tracks",
            "Heavy Ordnance 2",
            "Gunner",
            "Heavy Gunner",
            "Chief",
            "BIGGUN",
            "Tires",
            "Gun",
            "AtomBomb",
            "Amok Runner"
        };
        
        keywords.Sort(); 
        var repKeywords = c.GetKeywordsUnique().ToList();
        repKeywords.Sort();

        Assert.IsTrue(keywords.Zip(repKeywords, (x, y) => x.Equals(y)).Aggregate((acc,x) => acc == x));
    }
}
*/

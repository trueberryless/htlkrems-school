using LastAurora;
using LastAurora.Exceptions;

namespace UnitTests;

public class ConvoyTestB
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

    private Addon addon1;
    private Addon addon2;
    private Addon addon3;
    private Addon addon4;

    private Slot slot51;
    private Slot slot52;
    private Slot slot61;
    private Slot slot62;
    private Slot slot63;
    private Slot slot71;
    private Slot slot72;
    private Slot slot73;
    private Slot slot74;
    private Slot slot81;

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

        addon1 = new Addon("Small Storageaddon", 1_000, 2, "Addon");
        slot51 = new Slot(SlotType.Default);
        slot52 = new Slot(SlotType.Default);
        addon1.AddSlot(slot51);
        addon1.AddSlot(slot52);

        addon2 = new Addon("Armoraddon", 2_000, 3, "Addon");
        slot61 = new Slot(SlotType.Machinery, "Plating");
        slot62 = new Slot(SlotType.Machinery, "Plating");
        slot63 = new Slot(SlotType.Machinery, "Plating");
        addon2.AddSlot(slot61);
        addon2.AddSlot(slot62);
        addon2.AddSlot(slot63);
        
        addon3 = new Addon("Heavy Armor", 5_000, 4, "Addon");
        slot71 = new Slot(SlotType.Machinery, "Plating");
        slot72 = new Slot(SlotType.Machinery, "Plating");
        slot73 = new Slot(SlotType.Machinery, "Plating");
        slot74 = new Slot(SlotType.Machinery, "Plating");
        addon3.AddSlot(slot71);
        addon3.AddSlot(slot72);
        addon3.AddSlot(slot73);
        addon3.AddSlot(slot74);
        
        addon4 = new Addon("Biofuelgeneratoraddon", 25_000, 1, "Addon");
        slot81 = new Slot(SlotType.Machinery, "Biofuelgenerator");
        addon4.AddSlot(slot81);
        
        convoy.AddAddon(addon1);
        convoy.AddAddon(addon2);
        convoy.AddAddon(addon3);
        convoy.AddAddon(addon4);

        #endregion
    }

    [Test]
    public void DuplicateTrucks()
    {
        Assert.Throws<ComponentAlreadyOnConvoy>(() => convoy.AddTruck(truck1));
    }

    [Test]
    public void Convoy3Trucks()
    {
        var truck3 = new Truck("Teslatank", 140_000, 4, 3, 3, "Tank");
        var slot101 = new Slot(SlotType.Machinery, "Tracks");
        var slot102 = new Slot(SlotType.Machinery, "Teslagun");
        var slot103 = new Slot(SlotType.Predestined, "Crew");
        var slot104 = new Slot(SlotType.Default);
        truck3.AddSlot(slot101);
        truck3.AddSlot(slot102);
        truck3.AddSlot(slot103);
        truck3.AddSlot(slot104);
        
        Assert.Throws<TooManyTrucksException>(() => convoy.AddTruck(truck3));
    }

    [Test]
    public void TooManyAddons()
    {
        var addon5 = new Addon("Droneaddon", 15_000, 2, "Addon");
        var slot111 = new Slot(SlotType.Machinery, "Dronestation");
        var slot112 = new Slot(SlotType.Machinery, "Plating");
        addon5.AddSlot(slot111);
        addon5.AddSlot(slot112);

        Assert.Throws<NotEnoughUpgradeableComponents>(() => convoy.AddAddon(addon5));
    }
}
/*using LastAurora;

namespace UnitTests;

public class TestDestroyedSlot
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test()
    {
        SlotSpace s = new SlotSpace(3);

        var slot1 = new Slot("Tracks", SlotType.Machinery);
        
        s.AddSlot(new Slot("Crew", SlotType.Predestined));
        s.AddSlot(slot1);
        
        s.GetHit(slot1);
        s.GetHit(slot1);

        Assert.That(s.Slots[1].SlotState, Is.EqualTo(typeof(SlotDestroyed)));

        Assert.That(new [] { "Crew" }, Is.EqualTo(s.GetKeywords()));
    }
}*/
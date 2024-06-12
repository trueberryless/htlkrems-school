using System.Diagnostics.CodeAnalysis;

namespace LastAurora.Interfaces;

public interface IConfigurableSlots
{
    public void AddSlot(Slot s);
    public void RemoveSlot(Slot s);
    public void GetHit(Slot slot);
    public void Repair(Slot slot);
}
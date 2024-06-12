using System.Runtime.CompilerServices;
using LastAurora.Interfaces;

namespace LastAurora;

public class Slot
{
    public SlotType SlotType { get; init; }
    public ISlotState SlotState { get; private set; }

    private readonly string[] _keywords;

    public IEnumerable<string> Keywords => (!SlotState.AggregateKeyword() ? null : _keywords) ?? Array.Empty<string>();

    public void Hit() => SlotState = SlotState.Hit();
    public void Repair() => SlotState = SlotState.Repair();
    
    public Slot() : this(SlotType.Default, null!) {}
    
    public Slot(SlotType slotType) : this(slotType, null!) {}

    public Slot(SlotType slotType, params string[] keywords)
    {
        this._keywords = keywords;
        SlotType = slotType;
        
        SlotState = new SlotActive();
    }
}
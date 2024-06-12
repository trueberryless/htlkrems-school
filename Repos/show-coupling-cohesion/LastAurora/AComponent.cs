using System.Runtime.CompilerServices;
using LastAurora.Exceptions;

namespace LastAurora;

public abstract class AComponent : IActionHandler
{
    public AComponent(string code, int price, int maxSlotCount, params string[] keywords)
    {
        Code = code;
        Price = price;
        MaxSlotCount = maxSlotCount;

        Slots = new List<Slot>();
        Components = new List<AComponent>();
        _keywords = keywords;
    }

    protected readonly int Price;
    protected string Code;
    protected int MaxSlotCount;
    
    protected List<Slot> Slots { get; set; }
    
    protected List<AComponent> Components { get; set; }

    private readonly string[] _keywords;

    public IEnumerable<string> Keywords => _keywords;

    public IEnumerable<string> AllKeywords => 
        Keywords.Concat(Components.SelectMany(component => component.AllKeywords).Concat(Slots.SelectMany(slot => slot.Keywords)));

    public int PriceSum =>
        Price + Components.Sum(component => component.PriceSum);

    public void AddComponent(AComponent component)
    {
        if (CanAddComponent(component))
            Components.Add(component);
        else
            throw new NotEnoughPowerException();
    }

    public void RemoveComponent(AComponent component)
    {
        Components.Remove(component);
    }

    public AComponent? HasComponent(AComponent child)
    {
        return this == child ? this : Components.Select(parent => parent.HasComponent(child)).FirstOrDefault();
    }

    public void AddSlot(Slot slot)
    {
        if (Slots.Count < MaxSlotCount)
            Slots.Add(slot);
        else
            throw new SlotCapacityReachedException();
    }

    public void RemoveSlot(Slot slot)
    {
        Slots.Remove(slot);
    }

    public int CountComponentType<TComponent>() where TComponent : AComponent => Components.Count(c => c is TComponent);

    public List<AComponent> GetAllComponentsOfOneType<TComponent>() where TComponent : AComponent
    {
        var components = Components.SelectMany(c => c.GetAllComponentsOfOneType<TComponent>()).ToList();
        if (this is TComponent)
            components.Add(this);
        return components;
    }

    public abstract bool CanAddComponent(AComponent component);
}
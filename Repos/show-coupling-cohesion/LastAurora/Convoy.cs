using LastAurora.Exceptions;
using LastAurora.Interfaces;

namespace LastAurora;

public class Convoy : IActionHandler
{
    private Truck? FrontTruck { get; set; }
    private Truck? BackTruck { get; set; }

    public void AddTruck(Truck t)
    {
        if (FrontTruck == t || BackTruck == t)
            throw new ComponentAlreadyOnConvoy();
        
        if (FrontTruck == null)
            FrontTruck = t;
        else if (BackTruck == null)
            BackTruck = t;
        else
            throw new TooManyTrucksException();
    }

    public void RemoveTruck(Truck t)
    {
        if (BackTruck == t)
            BackTruck = null;
        else if (FrontTruck == t)
            FrontTruck = null;
        else
            throw new ComponentNotOnConvoy();
    }

    public bool IsFrontTruck(Truck t) => FrontTruck == t;
    public bool IsBackTruck(Truck t) => BackTruck == t;

    public void AddWaggon(Waggon w)
    {
        if (HasComponent(w) != null)
            throw new ComponentAlreadyOnConvoy();
        
        if ((bool)FrontTruck?.CanAddComponent(w))
            FrontTruck?.AddComponent(w);
        else if ((bool)BackTruck?.CanAddComponent(w))
            BackTruck?.AddComponent(w);
        else
            throw new NotEnoughPowerException();
    }

    public void RemoveWaggon(Waggon w)
    {
        HasComponent(w)?.RemoveComponent(w);
    }

    public void AddAddon(Addon a)
    {
        if (HasComponent(a) != null)
            throw new ComponentAlreadyOnConvoy();
        
        var upgradeable = GetAllComponentsOfOneType<AUpgradeable>();

        foreach (var component in upgradeable.Where(component => component.CanAddComponent(a)))
        {
            component.AddComponent(a);
            return;
        }

        throw new NotEnoughUpgradeableComponents();
    }

    public void RemoveAddon(Addon a)
    {
        HasComponent(a)?.RemoveComponent(a);
    }

    public void SwitchAddon(Addon oldAddon, Addon newAddon)
    {
        var parent = HasComponent(oldAddon);
        parent?.RemoveComponent(oldAddon);
        parent?.AddComponent(newAddon);
    }

    public int Count<TComponent>() where TComponent : AComponent =>
        (FrontTruck?.CountComponentType<TComponent>() ?? 0) + (BackTruck?.CountComponentType<TComponent>() ?? 0);

    public List<AComponent> GetAllComponentsOfOneType<TComponent>() where TComponent : AComponent =>
        (FrontTruck?.GetAllComponentsOfOneType<TComponent>() ?? new List<AComponent>())
        .Concat((BackTruck?.GetAllComponentsOfOneType<TComponent>() ?? new List<AComponent>()))
        .ToList();

    public AComponent? HasComponent(AComponent component) =>
        FrontTruck?.HasComponent(component) ?? BackTruck?.HasComponent(component) ?? null;

    public int Price => (FrontTruck?.PriceSum ?? 0) + (BackTruck?.PriceSum ?? 0);
    public int Power => (FrontTruck?.Power ?? 0) + (BackTruck?.Power ?? 0);
    public int Speed => Math.Max(FrontTruck?.Speed ?? 0, BackTruck?.Speed ?? 0);
    public IEnumerable<string> Keywords => FrontTruck?.AllKeywords.Concat(BackTruck?.AllKeywords ?? Array.Empty<string>()) ?? Array.Empty<string>();
}
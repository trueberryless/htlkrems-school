using System.Diagnostics.CodeAnalysis;

namespace LastAurora.Interfaces;

public interface IConfigurableWaggons
{
    public void AddWaggon(Waggon s);
    public void RemoveWaggon(Waggon s);
}
using LastAurora.Exceptions;
using LastAurora.Interfaces;

namespace LastAurora;

public class Waggon : AUpgradeable
{
    public Waggon(string code, int price, int maxSlotCount, params string[] keywords) : base(code, price, maxSlotCount, keywords)
    {
    }
    
    public override bool CanAddComponent(AComponent component)
    {
        return component switch
        {
            Addon => !Components.Any(c => c is Addon),
            _ => false
        };
    }
}
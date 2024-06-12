using LastAurora.Interfaces;

namespace LastAurora;

public class Addon : AComponent
{
    public Addon(string code, int price, int maxSlotCount, params string[] keywords) : base(code, price, maxSlotCount, keywords)
    {
    }

    public override bool CanAddComponent(AComponent component) => false;
}
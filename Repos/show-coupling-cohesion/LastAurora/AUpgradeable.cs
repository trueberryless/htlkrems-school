namespace LastAurora;

public abstract class AUpgradeable : AComponent
{
    public AUpgradeable(string code, int price, int maxSlotCount, params string[] keywords) : base(code, price, maxSlotCount, keywords)
    {
    }
}
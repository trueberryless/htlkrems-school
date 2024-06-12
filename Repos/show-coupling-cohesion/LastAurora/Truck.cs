using LastAurora.Exceptions;
using LastAurora.Interfaces;

namespace LastAurora;

public class Truck : AUpgradeable
{
    public Truck(string code, int price, int maxSlotCount, int power, int speed, params string[] keywords) : base(code, price, maxSlotCount, keywords)
    {
        Speed = speed;
        Power = power;
    }
    public int Speed { get; set; }
    public int Power { get; set; }

    public override bool CanAddComponent(AComponent component)
    {
        return component switch
        {
            Addon => !Components.Any(c => c is Addon),
            Waggon => Components.Count(c => c is Waggon) < Power,
            _ => false
        };
    }
}


namespace LastAurora;

public interface ISlotState
{
    bool AggregateKeyword();
    ISlotState Hit();
    ISlotState Repair();
}

public class SlotActive : ISlotState
{
    public bool AggregateKeyword() => true;
    public ISlotState Hit() => new SlotDamaged();
    public ISlotState Repair() => this;
}

public class SlotDamaged : ISlotState
{
    public bool AggregateKeyword() => false;
    public ISlotState Hit() => new SlotDestroyed();
    public ISlotState Repair() => new SlotActive();
}

public class SlotDestroyed : ISlotState
{
    public bool AggregateKeyword() => false;
    public ISlotState Hit() => this;
    public ISlotState Repair() => this;
}
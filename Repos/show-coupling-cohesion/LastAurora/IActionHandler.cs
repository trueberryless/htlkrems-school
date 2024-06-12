namespace LastAurora;

public interface IActionHandler
{
    public List<AComponent> GetAllComponentsOfOneType<TComponent>() where TComponent : AComponent;
}
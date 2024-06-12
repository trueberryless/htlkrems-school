namespace Pattern.Command;

public abstract class ACommand : ICommand
{
    protected readonly Robot Robot;

    public ACommand(Robot robot)
    {
        Robot = robot;
    }
    
    public abstract void Do();
    public abstract void Undo();
}
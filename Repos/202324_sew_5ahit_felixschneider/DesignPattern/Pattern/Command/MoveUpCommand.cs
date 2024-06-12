namespace Pattern.Command;

public class MoveUpCommand : ACommand
{
    public MoveUpCommand(Robot robot) : base(robot)
    {
    }

    public override void Do() => Robot.MoveUp();

    public override void Undo() => Robot.MoveDown();
}
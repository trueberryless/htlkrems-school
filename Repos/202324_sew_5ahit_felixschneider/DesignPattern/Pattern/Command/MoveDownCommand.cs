namespace Pattern.Command;

public class MoveDownCommand : ACommand
{
    public MoveDownCommand(Robot robot) : base(robot)
    {
    }

    public override void Do() => Robot.MoveDown();

    public override void Undo() => Robot.MoveUp();
}
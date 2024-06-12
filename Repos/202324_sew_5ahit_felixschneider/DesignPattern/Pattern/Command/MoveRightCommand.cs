namespace Pattern.Command;

public class MoveRightCommand : ACommand
{
    public MoveRightCommand(Robot robot) : base(robot)
    {
    }

    public override void Do() => Robot.MoveRight();

    public override void Undo() => Robot.MoveLeft();
}
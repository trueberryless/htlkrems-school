namespace Pattern.Command;

public class MoveLeftCommand : ACommand
{
    public MoveLeftCommand(Robot robot) : base(robot)
    {
    }

    public override void Do() => Robot.MoveLeft();

    public override void Undo() => Robot.MoveRight();
}
using Pattern.Command;

namespace PatternTest;

public class Command
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CommandTest()
    {
        List<ICommand> commands = new();
        var robot = new Robot
        {
            X = 0,
            Y = 0
        };
        
        commands.Add(new MoveDownCommand(robot));
        commands.Add(new MoveDownCommand(robot));
        commands.Add(new MoveLeftCommand(robot));
        commands.Add(new MoveRightCommand(robot));
        commands.Add(new MoveRightCommand(robot));
        commands.Add(new MoveUpCommand(robot));
        commands.Add(new MoveLeftCommand(robot));
        commands.Add(new MoveRightCommand(robot));
        commands.Add(new MoveRightCommand(robot));
        
        commands.ForEach(c => c.Do());
        
        Assert.That(robot.Y, Is.EqualTo(-1));
        Assert.That(robot.X, Is.EqualTo(2));
        
        commands.ForEach(c => c.Undo());
        
        Assert.That(robot.Y, Is.EqualTo(0));
        Assert.That(robot.X, Is.EqualTo(0));
    }
}
namespace Pattern.Command;

public interface ICommand
{
    void Do();

    void Undo();
}
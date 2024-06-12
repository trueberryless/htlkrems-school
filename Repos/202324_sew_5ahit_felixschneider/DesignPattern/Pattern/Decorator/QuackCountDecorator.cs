using Pattern.Adapter;

namespace Pattern.Decorator;

public class QuackCountDecorator : IQuackable
{
    private readonly IQuackable _quackable;

    public static int Counter = 0;

    public QuackCountDecorator(IQuackable quackable)
    {
        _quackable = quackable;
    }
    
    public string Quack()
    {
        Counter++;
        return _quackable.Quack();
    }
}
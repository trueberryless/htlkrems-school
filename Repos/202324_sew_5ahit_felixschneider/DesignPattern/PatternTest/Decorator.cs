using Pattern.Adapter;
using Pattern.Decorator;

namespace PatternTest;

public class Decorator
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DecoratorTest()
    {
        IQuackable quack1 = new RedheadDuck();
        IHonkable honk1 = new Goose();

        List<IQuackable> quacks = new() { quack1, new HonkAdapter(honk1) };
        quacks = quacks.Select(q => (IQuackable)new QuackCountDecorator(q)).ToList();
        
        var data = quacks.Select(q => q.Quack()).ToList();
        
        Assert.That(QuackCountDecorator.Counter, Is.EqualTo(2));
    }
}

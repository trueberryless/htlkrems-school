using Pattern.Adapter;

namespace PatternTest;

public class Adapter
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AdapterTest()
    {
        IQuackable quack1 = new RedheadDuck();
        IQuackable quack2 = new GingerDuck();
        IQuackable quack3 = new RubberDuck();

        IHonkable honk1 = new Goose();

        List<IQuackable> quacks = new () { quack1, quack2, quack3, new HonkAdapter(honk1) };

        var data = quacks.Select(q => q.Quack()).ToList();
        
        Assert.That(data, Has.Count.EqualTo(4));
        Assert.That(data, Does.Contain("Honk"));
    }
}
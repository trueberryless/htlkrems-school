using Pattern;

namespace PatternTest;

public class Singleton
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SingletonTest()
    {
        PrintDriver p1 = PrintDriver.GetInstance();
        PrintDriver p2 = PrintDriver.GetInstance();
        Assert.That(p1, Is.SameAs(p2));
    }
}
class Program
{
    public delegate int MyDelegate(MyDelegate deleg);

    static void Main()
    {
        MyDelegate myDelegate1 = Method;
        var someNumber = myDelegate1();
        Console.WriteLine(someNumber);
    }

    static int Method(MyDelegate deleg)
    {
        return 2;
    }
}
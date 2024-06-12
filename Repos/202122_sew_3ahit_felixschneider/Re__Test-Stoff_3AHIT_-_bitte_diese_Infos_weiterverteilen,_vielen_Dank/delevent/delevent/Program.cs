// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Person p = new();

p.GrownUp += P_GrownUp;
p.GrownUp += (s => Console.WriteLine("Hey "+s));
p.GrownUp2 += P_GrownUp21;

void P_GrownUp21(object? sender, EventArgs e)
{
    //Console.WriteLine(sender.ToString());
    Console.WriteLine( (e as MyEventArgs)?.Message);
}

void P_GrownUp(string Message)
{
    Console.WriteLine("Hansi sagt mir :" + Message);
}
void P_GrownUp2(string Message)
{
    Console.WriteLine("ha? " + Message);
}

for (int i = 0; i < 20; i++)
{
    p.CelebrateBirthday();
}

class Person
{
    public delegate void WhatToTell(string Message);
    public event WhatToTell GrownUp;

    public event EventHandler GrownUp2;
    public int Age { get; private set ; }

    public void CelebrateBirthday()
    {
        Age++;
        if (Age == 18)
            OnGrownUp();
    }

    private void OnGrownUp()
    {
       
        // Sagen wir das Allen
        if (GrownUp != null)
            GrownUp("Endlich " + Age);

        if (GrownUp2 != null)
            GrownUp2(this, new MyEventArgs { Message= "finally " + Age });
      
    }
}
public class MyEventArgs : EventArgs
{
    public string Message { get; set; }
}
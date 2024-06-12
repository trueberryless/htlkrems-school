using System;

namespace FibonacciZahlen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong a = 1;
            ulong b = 1;
            ulong c = a + b;
            while (true)
            {

                Console.Write(a + ", ");
                c = a + b;
                a = b;
                b = c;
                try
                {
                    Thread.Sleep((int)(1000 / Math.Pow(a, 1.0 / 10)));
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
        }
    }
}
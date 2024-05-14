using System;

namespace P20191126_Fibonacci___Zahlen
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl = 20;
            int loopCounter = 0, fib1 = 0, fib2 = 1;
            do
            {
                if (loopCounter == 0)
                {
                    Console.WriteLine(fib1);
                }
                else if (loopCounter == 1)
                {
                    Console.WriteLine(fib2);
                }
                else
                {
                    int tempTerm = fib1 + fib2;
                    fib1 = fib2;
                    fib2 = tempTerm;
                    Console.WriteLine(fib2);
                }
                loopCounter++;
            } while (loopCounter <= zahl);
            
        }
    }
}

using System;

namespace _20210312_GenericCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator<int> cal = new Calculator<int>();
            Console.WriteLine(cal.Sum(10, 10));
        }
    }
}

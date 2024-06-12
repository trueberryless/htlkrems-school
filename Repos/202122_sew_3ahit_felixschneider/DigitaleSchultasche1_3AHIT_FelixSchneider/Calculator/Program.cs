using System;
using Calculator_DLL;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dummy d = new Dummy();
            //d.Add(34, 32);

            Calculator_DLL.Calculator myCalculator = new Calculator_DLL.Calculator();
            while (true)
            {
                try
                {
                    Console.WriteLine("first number: ");
                    double x = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("operation + - / * : ");
                    string op = Console.ReadLine();
                    Console.WriteLine("second number: ");
                    double y = Convert.ToDouble(Console.ReadLine());
                    if (op == "+")
                        Console.WriteLine(myCalculator.Add(x, y));
                    else if (op == "-")
                        Console.WriteLine(myCalculator.Sub(x, y));
                    else if (op == "*")
                        Console.WriteLine(myCalculator.Mul(x, y));
                    else if (op == "/")
                        Console.WriteLine(myCalculator.Div(x, y));
                    else
                        Console.WriteLine("Wrong input!");
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Wrong input!");
                    Console.WriteLine();
                }
            }
            
        }
    }
}

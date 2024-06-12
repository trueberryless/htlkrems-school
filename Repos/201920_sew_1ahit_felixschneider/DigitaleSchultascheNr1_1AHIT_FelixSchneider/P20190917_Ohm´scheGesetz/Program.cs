using System;

namespace P20190917_Ohm_scheGesetz
{
    class Program
    {
        static void Main(string[] args)
        {
            double u, r, i, erg;
            string op = "";
            

            Console.WriteLine("Was wollen Sie berechnen? U,R,I");
            op = Console.ReadLine();
            
            if (op == "U")
            {
                Console.WriteLine("Geben Sie eine Zahl für die Stromstärke ein!");
                i = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Geben Sie eine Zahl für den Widerstand ein!");
                r = Convert.ToDouble(Console.ReadLine());

                erg = i*r;
                Console.WriteLine(i+" * "+r+" = "+erg+" Volt");

            }
            else
            {
                if (op == "I")
                {
                    Console.WriteLine("Geben Sie eine Zahl für die Spannung ein!");
                    u = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Geben Sie eine Zahl für den Widerstand ein!");
                    r = Convert.ToDouble(Console.ReadLine());

                    erg = u / r;
                    Console.WriteLine(u + " / " + r + " = " + erg+" Ampere");

                }
                else
                {
                    if (op == "R")
                    {
                        Console.WriteLine("Geben Sie eine Zahl für die Stromstärke ein!");
                        i = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Geben Sie eine Zahl für die Spannung ein!");
                        u = Convert.ToDouble(Console.ReadLine());

                        erg = u / i;
                        Console.WriteLine(u + " / " + i + " = " + erg+" Ohm");
                    }                        

                }
            }
        }

        private static void WriteLine(string v)
        {
            throw new NotImplementedException();
        }
    }
}

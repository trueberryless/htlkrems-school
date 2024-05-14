using System;

namespace P20191009
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 123456789;
            int erg = 0;

            Console.WriteLine("C {0:C}", x);
            Console.WriteLine("D {0:D}", x);
            Console.WriteLine("E {0:E}", x);
            Console.WriteLine("F {0:F}", x);
            Console.WriteLine("G {0:G}", x);
            Console.WriteLine("N {0:N}", x);
            Console.WriteLine("P {0:P}", x);
            Console.WriteLine("X {0:X}", x);

            erg = x / 7;

            Console.WriteLine("{0:D}",erg);


            Console.WriteLine("C {0}\a", x);
            Console.WriteLine("D {0}\b5", x);
            Console.WriteLine("E {0}\f", x);
            Console.WriteLine("F {0}\t2ws", x);
            Console.WriteLine("N {0}\vrstth", x);
            Console.WriteLine("P {0}\rsrth", x);
            Console.WriteLine("X {0}\nstrz", x);
        }
    }
}

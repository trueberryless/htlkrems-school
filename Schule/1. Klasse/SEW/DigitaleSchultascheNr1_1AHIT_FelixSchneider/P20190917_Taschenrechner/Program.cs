using System;

namespace P20190917_Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, erg, rest;
            string op = "";

            Console.WriteLine("Bitte geben Sie eine beliebige Zahl ein!");          //Ausgabe
            a = Convert.ToInt32(Console.ReadLine());                                //Eingabe
            Console.WriteLine("Geben Sie nun bitte eine Rechenoperation ein!");     //Ausgabe
            op = Console.ReadLine();                                                //Eingabe
            Console.WriteLine("Bitte geben Sie die zweite Zahl ein!");              //Ausgabe
            b = Convert.ToInt32(Console.ReadLine());                                //Eingabe

            if (op == "+")                                                          
            {
                erg = a + b;
                Console.WriteLine(a+" + "+b+" = "+erg);
                ;
            }
            else
            {
                if (op == "-")
                {
                    erg = a - b;
                    Console.WriteLine(a + " - " + b + " = " + erg);
                }
                else
                {
                    if (op == "*")
                    {
                        erg = a * b;
                        Console.WriteLine(a + " * " + b + " = " + erg);
                        ;
                    }
                    else
                    {
                        if (op == "/")
                        {
                            erg = a / b;
                            rest = a - b * erg;
                            Console.WriteLine(a + " / " + b + " = " + erg + " und "+rest+" Rest");
                            ;
                        }
                    }
                }
            }
        }   

    }
}

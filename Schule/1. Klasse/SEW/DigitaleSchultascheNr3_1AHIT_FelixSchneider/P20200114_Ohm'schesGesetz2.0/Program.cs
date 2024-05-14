using System;

namespace P20200114_Ohm_schesGesetz2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            double u, r, i;
            string op = "";

            Console.WriteLine("Was wollen Sie berechnen? U,R,I");
            op = Console.ReadLine().ToUpper();

            if (op == "U")
            {
                i = SichereEingabe("die Stromstärke (I)");
                r = SichereEingabe("den Widerstand (R)");           
                Console.WriteLine("Das Ergebnis ist: {0} Volt", i * r);
            }
            if (op == "R")
            {
                i = SichereEingabe("die Stromstärke (I)");
                u = SichereEingabe("die Spannung (U)");
                Console.WriteLine("Das Ergebnis ist: {0} Ohm", u / i);
            }
            if (op == "I")
            {
                r = SichereEingabe("den Widerstand (R)");
                u = SichereEingabe("die Spannung (U)");
                Console.WriteLine("Das Ergebnis ist: {0} Ampere", u / r);
            }

        }
        static double Eingabe(string text)
        {
            Console.Write("Bitte geben Sie eine Zahl für {0} ein:\t",text);
            double z = Convert.ToDouble(Console.ReadLine());

            return z;
        }
        static double SichereEingabe(string text)
        {
            Console.Write("Bitte geben Sie eine Zahl für {0} ein:\t", text);                             //Benutzerführung              
            string eingabe = Console.ReadLine();         //Hilfseingabe 
            bool WarDaSchonEinBeistrich = false;

            //wenn nur Ziffern eingegeben worden sind, dann ist es OK => sonst 0
            for (int i = 0; i < eingabe.Length; i++)
            {
                if (eingabe[i] < '0')
                {
                    if(WarDaSchonEinBeistrich == false)
                    {
                        if (eingabe[i] == ',')
                        {
                            WarDaSchonEinBeistrich = true;
                            continue;
                        }
                    }
                    return 0;
                }

                if (eingabe[i] > '9')
                    return 0;
            }

            double z = Convert.ToDouble(eingabe);        //Umwandlung der überprüften Eingabe

            return z;                                       //gehe zurück zum Hauptprogramm
        }

        //    double u, r, i, erg;
        //    string op = "";


        //    Console.WriteLine("Was wollen Sie berechnen? U,R,I");
        //    op = Console.ReadLine().ToUpper();

        //    if (op == "U")
        //    {
        //        Console.WriteLine("Geben Sie eine Zahl für die Stromstärke ein!");
        //        i = Convert.ToDouble(Console.ReadLine());
        //        Console.WriteLine("Geben Sie eine Zahl für den Widerstand ein!");
        //        r = Convert.ToDouble(Console.ReadLine());

        //        erg = i * r;
        //        Console.WriteLine(i + " * " + r + " = " + erg + " Volt");

        //    }
        //    else
        //    {
        //        if (op == "I")
        //        {
        //            Console.WriteLine("Geben Sie eine Zahl für die Spannung ein!");
        //            u = Convert.ToDouble(Console.ReadLine());
        //            Console.WriteLine("Geben Sie eine Zahl für den Widerstand ein!");
        //            r = Convert.ToDouble(Console.ReadLine());

        //            erg = u / r;
        //            Console.WriteLine(u + " / " + r + " = " + erg + " Ampere");

        //        }
        //        else
        //        {
        //            if (op == "R")
        //            {
        //                Console.WriteLine("Geben Sie eine Zahl für die Stromstärke ein!");
        //                i = Convert.ToDouble(Console.ReadLine());
        //                Console.WriteLine("Geben Sie eine Zahl für die Spannung ein!");
        //                u = Convert.ToDouble(Console.ReadLine());

        //                erg = u / i;
        //                Console.WriteLine(u + " / " + i + " = " + erg + " Ohm");
        //            }

        //        }
        //    }
        //}      
    }
}

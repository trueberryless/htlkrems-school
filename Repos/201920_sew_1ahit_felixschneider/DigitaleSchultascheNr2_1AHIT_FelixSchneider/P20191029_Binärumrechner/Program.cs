using System;

namespace P20191029_Binärumrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Bitte geben Sie eine Zahl aus dem Zehnersystem ein!");
                string Zahl10überprüfer = Console.ReadLine().ToUpper();
                long rest = 0, Zahl10 = 0;
                string Ausgabe = "";                                                //Deklarationen und Initialisierungen

                try
                {
                    Zahl10 = Convert.ToInt64(Zahl10überprüfer);                     //Überprüfung ob Umwandlung in die Long Variable möglich ist
                }
                catch
                {
                    if (Zahl10überprüfer == "exit")                                 //Wenn Eingabe Exit ist, wird das Programm beendet
                    {
                        Console.WriteLine("Das Programm wurde beendet!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("ungültige Eingabe");
                        break;
                    }
                }

                do
                {
                    rest = Zahl10 % 2;                                              //Der Rest von der Zahl wird berechnet
                    Ausgabe = rest + Ausgabe;                                       //Zu dem Rest wird der String neuer Rest hinzugefügt
                    Zahl10 = Zahl10 / 2;                                            //Die Zahl wird durch zwei dividiert
                } while (Zahl10 != 0);
                Console.Write("\nDeine Zahl ist binär: " + Ausgabe + "\n\n");       //Ausgabe
            }
            
        }
    }
}

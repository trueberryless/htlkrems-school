using System;

namespace P20201218_ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 3;

            try {
                //y = Convert.ToInt32("o");
                Console.WriteLine(x/y);
            }
            catch (DivideByZeroException) {
                Console.WriteLine("Achtung: nicht durch 0 dividieren!");                
            }
            catch (Exception e) {
                Console.WriteLine("Ein unerwarteter Fehler ist aufgetreten!");
                Console.WriteLine(e.Message);
                return; //Programmende
            }
            finally {
                Console.WriteLine("finally Zweig");
            }

            Console.WriteLine("Das Programm läuft weiter");
        }
    }
}

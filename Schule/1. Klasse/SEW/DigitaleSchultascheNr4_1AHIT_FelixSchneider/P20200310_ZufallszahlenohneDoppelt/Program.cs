using System;

namespace P20200310_ZufallszahlenohneDoppelt
{
    class Program
    {
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Wie viele unterschiedliche Zufallszahlen wollen Sie generieren?");
                Int32.TryParse(Console.ReadLine(), out int anz);
                if(anz >= 45)
                {
                      
                }
                int[] zahlen = new int[anz];
                Zufallszahlen(anz, zahlen);
                Console.WriteLine();
                for(int i = 0; i < zahlen.Length; i++)
                {
                    Console.Write(zahlen[i]+", ");
                }
                Console.Write("\b\b ");
                Console.ReadLine();
            }
        }
        static void Zufallszahlen(int anz, int[] zahlen)
        {
            for (int i = 0; i < anz; i++)
            {
                zahlen[i] = Ueberpruefung(zahlen);
            }        
        }
        static int Ueberpruefung(int[] zahlen)
        {
            int rz = 0;
            Random randy = new Random();
            while (true)
            {
                bool gefunden = false;
                rz = randy.Next(1, 45);
                for(int i = 0;i < zahlen.Length; i++)
                {
                    if(zahlen[i] == rz)
                    {
                        gefunden = true;
                        break;
                    }
                }

                if (gefunden)
                {
                    continue;
                }
                break;
            }
            return rz;
        }
    }
}

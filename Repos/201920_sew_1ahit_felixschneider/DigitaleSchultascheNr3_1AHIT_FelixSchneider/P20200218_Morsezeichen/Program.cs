using System;

namespace P20200218_Morsezeichen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie eine Nachricht ein:\t\t\t");
            string wort = Console.ReadLine().ToUpper();
            string zeichen = "";
            zeichen = WortzuZeichen(wort, zeichen);
            Console.WriteLine(zeichen);
            ZeichenzuTon(zeichen);
        }
        static string WortzuZeichen(string w, string z)
        {
            for(int i = 0; i < w.Length; i++)
            {
                switch (w[i])  {
                    case 'A': z = z + ".- "; break;
                    case 'B': z = z + "-... "; break;
                    case 'C': z = z + "-.-. "; break;
                    case 'D': z = z + "-.. "; break;
                    case 'E': z = z + ". "; break;
                    case 'F': z = z + "..-. "; break;
                    case 'G': z = z + "--. "; break;
                    case 'H': z = z + ".... "; break;
                    case 'I': z = z + ".. "; break;
                    case 'J': z = z + ".--- "; break;
                    case 'K': z = z + "-.- "; break;
                    case 'L': z = z + ".-.. "; break;
                    case 'M': z = z + "-- "; break;
                    case 'N': z = z + "-. "; break;
                    case 'O': z = z + "--- "; break;
                    case 'P': z = z + ".--. "; break;
                    case 'Q': z = z + "--.- "; break;
                    case 'R': z = z + ".-. "; break;
                    case 'S': z = z + "... "; break;
                    case 'T': z = z + "- "; break;
                    case 'U': z = z + "..- "; break;
                    case 'V': z = z + "...- "; break;
                    case 'W': z = z + ".-- "; break;
                    case 'X': z = z + "-..- "; break;
                    case 'Y': z = z + "-.-- "; break;
                    case 'Z': z = z + "--.. "; break;
                    case 'Ä': z = z + ".-.- "; break;
                    case 'Ö': z = z + "---. "; break;
                    case 'Ü': z = z + "..-- "; break;
                    case ' ': z = z + "   "; break;
                    case '.': z = z + "       "; break;
                }
            }
            return z;
        }
        static void ZeichenzuTon(string z)
        {
            for (int i = 0; i < z.Length; i++)
            {
                switch (z[i])  {
                    case '.': Console.Beep(500, 200); Console.Write("."); break; //kurz
                    case '-': Console.Beep(500, 600); Console.Write("-"); break; //lang
                    case ' ': System.Threading.Thread.Sleep(300); Console.Write(" "); break; //Pause
                }
            }
        }
    }
}

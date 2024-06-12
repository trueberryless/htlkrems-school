using System;
using System.IO;

namespace Tierheimverwaltung
{
    class Program
    {
        static Animal[] animals = new Animal[3]
        {
            new Dog(),
            new Bird(),
            new Dog()
        };

        static void Main(string[] args)
        {
            ReadFile();
            WriteFile();
        }

        static void WriteFile()
        {
            using (StreamWriter sw = new StreamWriter("tiere.txt"))
            {
                for (int i = 0; i < animals.Length; i++)
                {
                    sw.WriteLine($"{i + 1}. Animal: {animals[i]}");
                    Console.WriteLine($"{i + 1}. Animal: {animals[i]}");
                }
            }
        }

        static void ReadFile()
        {
            using (StreamReader sr = new StreamReader("tiere.txt"))
            {
                int i = 0;
                while (sr.Peek() != -1)
                {
                    string zeile = sr.ReadLine();
                    string[] splitzeile = zeile.Split(" ");
                    int newweight = Convert.ToInt32(splitzeile[3].Substring(0, splitzeile[3].Length - 3));
                    if (splitzeile[5].Substring(splitzeile[5].Length - 2, 2) == "cm")
                    {
                        int newwingSpan = Convert.ToInt32(splitzeile[5].Substring(0, splitzeile[5].Length - 2));
                        animals[i] = new Bird(wingSpan: newwingSpan, weight: newweight);
                    }
                    else
                    {
                        string newbark = splitzeile[5];
                        animals[i] = new Dog(bark: newbark, weight: newweight);
                    }
                    i++;
                }
            }
        }
    }
}

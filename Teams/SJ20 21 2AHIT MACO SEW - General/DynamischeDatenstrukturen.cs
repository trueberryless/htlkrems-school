using System;
using System.Collections.Generic;

namespace DynamischeDatenstrukturen
{
    class Program
    {
        static void Main(string[] args)
        {
            // statische Datenstruktur: Array
            int[] daten = new int[15];
            Console.WriteLine(daten.Length);

            Array.Resize( ref daten, 30);
            Console.WriteLine(daten.Length);

            // dynamische Datenstruktur: Liste
            List<int> liste = new List<int>();
            Console.WriteLine($"capacity:{liste.Capacity}, count:{liste.Count}");

            liste.Add(1);
            Console.WriteLine($"capacity:{liste.Capacity}, count:{liste.Count}");
            liste.Add(2); liste.Add(3); liste.Add(4);
            Console.WriteLine($"capacity:{liste.Capacity}, count:{liste.Count}");
            liste.Remove(2);
            Console.WriteLine($"capacity:{liste.Capacity}, count:{liste.Count}");
            Console.WriteLine(liste[2]); //hinzu 1 2 3 4 gelöscht 2 also aktuell 1  3  4
                                         //[0][1][2]
            liste.Add(5); liste.Add(6);
            Console.WriteLine($"capacity:{liste.Capacity}, count:{liste.Count}");
            liste.Remove(5); liste.Remove(6);
            Console.WriteLine($"capacity:{liste.Capacity}, count:{liste.Count}");

            liste.AddRange(new List<int> { 7, 8, 9, 10, 11 });
            Console.WriteLine($"capacity:{liste.Capacity}, count:{liste.Count}");
            liste.Add(12);
            Console.WriteLine($"capacity:{liste.Capacity}, count:{liste.Count}");

            for (int i = 0; i < liste.Count; i++)
            {
                Console.Write($"{liste[i]} ");
            }
            Console.WriteLine();
            foreach (var item in liste)
            {
                Console.Write($"{item} ");
            }

        }
    }
}

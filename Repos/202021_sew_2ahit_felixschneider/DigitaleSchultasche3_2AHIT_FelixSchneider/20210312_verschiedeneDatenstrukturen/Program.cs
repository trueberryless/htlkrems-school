using System;
using System.Collections.Generic;

namespace _20210312_verschiedeneDatenstrukturen
{
    class Program
    {
        static void Main(string[] args)
        {
            // statische Datenstrukturen
            int[] daten = new int[15];
            Console.WriteLine(daten.Length);

            Array.Resize(ref daten, 30);
            Console.WriteLine(daten.Length);


            // dynamische Datenstrukturen
            List<int> liste = new List<int>();
            Console.WriteLine($"Capacity: {liste.Capacity}, Count: {liste.Count}");

            liste.Add(1);
            Console.WriteLine($"Capacity: {liste.Capacity}, Count: {liste.Count}");
            liste.Add(2);
            liste.Add(3);
            liste.Add(4);
            Console.WriteLine($"Capacity: {liste.Capacity}, Count: {liste.Count}");
            liste.Remove(2);
            Console.WriteLine($"Capacity: {liste.Capacity}, Count: {liste.Count}");

            Console.WriteLine(liste[2]); //hinzu: 1, 2, 3, 4; gelöscht: 2; also: 1, 3, 4
            //                                                                  [0][1][2]

            liste.Add(5);
            liste.Add(6);
            Console.WriteLine($"Capacity: {liste.Capacity}, Count: {liste.Count}");
            liste.Remove(5);
            liste.Remove(6);
            Console.WriteLine($"Capacity: {liste.Capacity}, Count: {liste.Count}");
            //Capacity: 8, Count: 3 --> löchriger Speicher

            liste.AddRange(new List<int> { 7, 8, 9, 10, 11 });
            Console.WriteLine($"Capacity: {liste.Capacity}, Count: {liste.Count}");

            liste.Add(12);
            Console.WriteLine($"Capacity: {liste.Capacity}, Count: {liste.Count}");

            foreach (var item in liste)
            {
                Console.Write(item + " ");
            }
        }
    }
}

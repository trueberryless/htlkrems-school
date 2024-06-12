using System;

namespace P20210219_ArraySortieren
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] daten = new int[] { 5, 3, 1 };
            Array.Sort(daten);

            string[] namen = new string[] { "Hans", "Sepp", "Susi", "Berta" };
            Array.Sort(namen);

            foreach (var item in daten) {
                Console.WriteLine(item);
            }

            //-----------------string-Klassen-Arrays sortieren-----------------

            Person[] freunde = new Person[]
            {
                new Person{Vorname="Sepp", Nachname="Sorlos"},
                new Person{Vorname="Adam", Nachname="Zander"},
                new Person{Vorname="Berta", Nachname="Zander"},
                new Person{Vorname="Max", Nachname="Mustermann"}
            };

            Array.Sort(freunde);

            foreach (var item in freunde)
            {
                Console.WriteLine($"{item.Nachname} {item.Vorname},");
            }

            //ohne IComparable geht da gar nix ;)
        }

        class Person : IComparable
        {
            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public int CompareTo(object obj)
            {
                Person other = obj as Person;
                if (this.Nachname == other.Nachname)
                    return this.Vorname.CompareTo(other.Vorname);
                else
                    return this.Nachname.CompareTo(other.Nachname);
            }
        }
    }
}

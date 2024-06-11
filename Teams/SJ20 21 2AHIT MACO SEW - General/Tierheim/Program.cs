using System;

namespace ArraySorteren
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] daten = new int[] { 5, 3, 1 };
            Array.Sort(daten);
            string[] namen = new string[] 
                        { "Hans", "Sepp", "Susi", "Berta" };
            Array.Sort(namen);

            foreach (var item in daten)
            {
                Console.WriteLine(item);
            }
            Person[] freunde = new Person[]
              {
                    new Person{Vorname="Sepp", Nachname="Sorglos"},
                    new Person{Vorname="Adam", Nachname="Zander"},
                    new Person{Vorname="Berta", Nachname="Zander"},
                    new Person{Vorname="Max", Nachname="Muster"}
              };

            Array.Sort(freunde);
            //ohne IComparable geht da gar nix :)

        }
    }
  
}

using System;

namespace P20210115_SortierenundSuchen
{
    class Program
    {
        static Random randy = new Random();
        static void Main(string[] args)
        {
            int[] myArray = makeMyArray();            
            bool foundnumber = binary_search(randy.Next(1, 100), myArray);
            Console.WriteLine(foundnumber);
        }

        static int[] makeMyArray()
        {
            int length = randy.Next(10, 20);
            int[] myArray = new int[length];

            //Initialisierung eines Arrays mit random Numbers
            for (int i = 0; i < myArray.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int number = randy.Next(1, 100);
                    if (number == myArray[j])
                        continue;
                    myArray[i] = number;
                }
            }
            Array.Sort(myArray);

            //Ausgabe d. Arrays
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write(myArray[i] + ", ");
            }
            Console.WriteLine();

            return myArray;
        }

        static bool binary_search(int ourValue, int[] myArray)
        {            
            int from = 0, to = myArray.Length, middle = (from + to)/2, counter = 0;

            //Schritt für Schritt näher an die Lösung kommen
            while(true)
            {
                counter++;
                middle = (from + to) / 2;
                Console.WriteLine($"Schritt {counter}: Suche {ourValue} von [{from}] bis [{to}] bei [{middle}].");
                if (myArray[middle] == ourValue)
                    return true;
                else if (myArray[middle] > ourValue)
                    to = middle;
                else
                    from = middle;

                //Überprüfung, für den Fall, dass es die Zahl nicht gibt im Array
                //wenn Anfang und Ende (gleich weit von middle entfernt) beide gleich sind, 
                //kann die Zahl im Array nicht existieren
                if(from == to - 1)
                    break;
            }
            return false;
        }
    }
}
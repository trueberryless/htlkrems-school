using System;
using System.Diagnostics;

namespace P20210122_Sortierverfahren
{
    class Program
    {
        static Random randy = new Random();
        static double ifzaehler = 0, tauschzaehler = 0, minzaehler = 0;
        static void Main(string[] args)
        {
            int value = 1000;
            int[] myArray = new int[value];
            SetValues(myArray, value);
            ifzaehler = 0;
            tauschzaehler = 0;
            minzaehler = 0;

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Bubblesort(myArray);
            Insertionsort(myArray);
            //Selectionsort(myArray);            
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed);
            //WriteArray(myArray);
            double verhaeltnis, verhaeltnis2;
            verhaeltnis = tauschzaehler / ifzaehler * 1000;
            verhaeltnis2 = minzaehler / ifzaehler * 1000000;
            Console.WriteLine($"IF-Zähler: {ifzaehler}\nTausch-Zähler: {tauschzaehler}\nVerhältnis: {verhaeltnis} Promille (IF:Tausch)\nMinzähler: {minzaehler}\nVerhältnis: {verhaeltnis2}ppM (Min in IF)");
        }

        static void Bubblesort(int[] myArray)
        {
            for (int n = myArray.Length; n > 1; --n)
            {
                for (int i = 0; i < n - 1; ++i)
                {
                    ifzaehler++;
                    if(myArray[i] > myArray[i + 1])
                    {
                        int speicher = myArray[i];
                        myArray[i] = myArray[i + 1];
                        myArray[i + 1] = speicher;
                        tauschzaehler++;
                    }
                }
            }
        }

        static void Insertionsort(int[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                int value = myArray[i];
                int j = i;
                while(j > 0 && myArray[j-1] > value)
                {
                    myArray[j] = myArray[j - 1];
                    j--;
                    ifzaehler+=2;
                }
                myArray[j] = value;
                tauschzaehler++;
            }
        }

        static void Selectionsort(int[] myArray)
        {
            int temp, smallest;
            for (int i = 0; i < myArray.Length; i++)
            {
                smallest = i;
                for (int j = i + 1; j < myArray.Length; j++)
                {
                    ifzaehler++;
                    if (myArray[j] < myArray[smallest])
                    {
                        smallest = j;
                        minzaehler++;
                    }
                }
                temp = myArray[smallest];
                myArray[smallest] = myArray[i];
                myArray[i] = temp;
                tauschzaehler++;
            }
        }

        static void SetValues(int[] myArray, int value)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = randy.Next(1, value);
            }
        }

        static void WriteArray(int[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write(myArray[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}

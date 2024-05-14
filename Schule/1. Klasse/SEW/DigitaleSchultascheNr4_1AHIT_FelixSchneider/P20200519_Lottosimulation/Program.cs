using System;

namespace P20200519_Lottosimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] anz = new int[47];
            int[][] alle_zahlen = new int[1000][]; //dieses jagged Array speichert 
            //alle Arrays in einem Array        

            Random r = new Random(); //r ist eine Random-Zahl
            int[] gezogene; //Array

            for(int i = 0; i < 1000; i++)
            {
                gezogene = LiefereZahlen(r);//Array bekommt die Zahlen
                Sortieren(gezogene); //sortiert nach Größe
                alle_zahlen[i] = gezogene; //jedes Array wird ins jagged Array gespeichert
                for(int j = 1; j < 46; j++)
                {
                    anz[j] += CheckValue(gezogene, j); //j geht jede Zahl durch und 
                    //checkt jede einzelne Zahl, wie of sie vorkommt
                }
            }

            Console.WriteLine("Statistik:");
            Ausgabe(anz); //die Statistik wird ausgegeben
            Console.WriteLine("alle Zufallszahlen:");
            Ausgabe_jaggedArray(alle_zahlen); //alle random Arrays werden hintereinander ausgegeben      
        }


        static int[] LiefereZahlen(Random r)
        {
            int[] zz = new int[6];

            //random Zahlen-Generator
            for(int i = 0; i < zz.Length; i++)
            {
                int neu = r.Next(1, 46); //random Zahl
                zz[i] = neu; //wird in eine Stelle des Arrays eingefügt

                //falls zwei Zahlen gleich sind
                for(int pruefposition = 0; pruefposition < i; pruefposition++)
                {
                    if(neu == zz[pruefposition]) //zz[0] == zz[1] == zz[2] ...
                    {
                        i = i - 1; //i muss zurückgesetzt werden, damit der Vorgang wiederholt werden kann
                        break; //springt aus der letzten for-Schleife
                    }
                } //und fängt dann wieder von vorne an
            }
            return zz; //gibt die Zufallszahl zurück
        }

        static int[] Sortieren (int[] zahlen) //sortiert die Zahlen im Array von klein nach groß
        {
            for(int n = zahlen.Length; n > 1; n--) //schränkt den Überprüfungsbereich ein
            {
                for(int i = 0; i < n-1; i++) //schränkt den Überprüfungsbereich ein
                {
                    if (zahlen[i] > zahlen[i+1]) //zwei Zahlen nebeneinander werden ausgetauscht,
                        //wenn die erste größer als die zweite ist
                    {
                        int speicher = zahlen[i]; //erste Zahl wird gespeichert
                        zahlen[i] = zahlen[i + 1]; //erste Zahl wird in die zweite verwandelt
                        zahlen[i + 1] = speicher; //zweite Zahl erhält den Speicher, weil die 
                        // erste Zahl ja schon die zweite Zahl hat, würde es wenig Sinn machen,
                        // der zweiten Zahl die erste Zahl zuzuordnen
                    }
                }
            }
            return zahlen;
        }

        static void Ausgabe (int[] array)
        {
            Console.WriteLine(); //Abstand halten :)
            for(int i = 1; i < array.Length - 1; i++)
            {
                Console.WriteLine("{0}: {1}, ",i, array[i]); //gibt Arrays aus
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Ausgabe_jaggedArray(int[][] jaggedArray) //gibt verschachtelte Arrays aus
        {
            Console.WriteLine();
            for(int i = 0; i < jaggedArray.Length; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    Console.Write(jaggedArray[i][j] + " "); //jagged Array wird ausgegeben
                }
                Console.WriteLine();
            }
        }

        static int Check42 (int[] zahlen) //überprüft die Zahl 42, wie oft sie vorkommt
        {
            int anz = 0;
            for(int i = 0; i < zahlen.Length; i++) //zählt alle Zahlen des Arrays durch
            {
                if (zahlen[i] == 42)
                {
                    anz++; //Anzahl wird um 1 erhöht
                }
            }
            return anz; //diese Anzahl wird zurückgegeben
        }

        static int CheckValue (int[] zahlen, int wert) //wie Check42, nur für jede Zahl
        {
            int anz = 0;
            for (int i = 0; i < zahlen.Length; i++)
            {
                if (zahlen[i] == wert) //Wert wird als Parameter übergeben und hier eingesetzt
                {
                    anz++;
                }
            }
            return anz; //gibt die Anzahl all dieser Werte zurück
        }
    }
}

using System;

namespace P20200107_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Bitte geben Sie ein Wort oder eine Zahl ein:\t\t\t");
                string satz = Console.ReadLine().ToLower();
                bool satzzeichen_gefunden;
                satz = satz.ToLower();          //anders nicht möglich

                int a = 0;                      //Anfang
                int e = satz.Length - 1;        //Ende

                while (a <= e)
                {
                    satzzeichen_gefunden = false;
                    string satzzeichen = ".,;:!?-_ +";
                                   
                    if (satz[a] == satz[e])
                    {
                        a++;
                        e--;
                        continue;
                    }
                    for (int i = 0; i < satzzeichen.Length && satzzeichen_gefunden==false; i++)         //zwei Bedingungen
                    {                                                                                   //  ^
                        if (satz[a] == satzzeichen[i])                                                  //  |
                        {                                                                               //  |
                            a++;                                                                        //  |
                            satzzeichen_gefunden = true;                                                //  |
                        }                                                                               //statt break;
                        if (satz[e] == satzzeichen[i])
                        {
                            e--;
                            satzzeichen_gefunden = true;                            
                        }
                    }
                    if (satzzeichen_gefunden == true)
                        continue;         

                    if (satz[a] != satz[e])
                    {
                        Console.Write("kein ");
                        break;
                    }
                }
                Console.WriteLine("Palindrom");
            }
        }
    }
}

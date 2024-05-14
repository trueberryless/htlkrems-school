using System;

namespace P20191217_Palindromüberprüfung
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string wort = "Alle Bananen, Anabella!";
                //             a                    e
                //              a                  e
                //               a                e
                //                a              e
                //                 a            e
                //                  a           e
                //                   a         e
                //                    a       e
                //                     a     e
                //                      a   e
                //                      a  e
                //                      a e
                //                       x   liegen übereinander

                Console.Write("Bitte geben Sie ein Wort oder eine Zahl ein:\t\t\t");
                string satz = Console.ReadLine().ToLower();

                satz = satz.ToLower();          //anders nicht möglich

                int a = 0;                      //Anfang
                int e = satz.Length - 1;        //Ende

                while (a <= e)
                {
                    if (a != e)
                    {
                        string satzzeichen = ".,;:!?-_<>|=";

                        for (int i = 0; a != e; i++)
                        {
                            if (satz[a] == satzzeichen[i])
                            {
                                a++;
                                continue;
                            }
                            if (satz[e] == satzzeichen[i])
                            {
                                e--;
                                continue;
                            }
                        }
                        
                        if (satz[a] == ' ')
                        {
                            a++;
                            continue;
                        }
                        if (satz[e] == ' ')
                        {
                            e--;
                            continue;
                        }
                        if (satz[a] == '.')
                        {
                            a++;
                            continue;
                        }
                        if (satz[e] == '.')
                        {
                            e--;
                            continue;
                        }
                        if (satz[a] == ',')
                        {
                            a++;
                            continue;
                        }
                        if (satz[e] == ',')
                        {
                            e--;
                            continue;
                        }
                        if (satz[a] == '?')
                        {
                            a++;
                            continue;
                        }
                        if (satz[e] == '?')
                        {
                            e--;
                            continue;
                        }
                        if (satz[a] == '!')
                        {
                            a++;
                            continue;
                        }
                        if (satz[e] == '!')
                        {
                            e--;
                            continue;
                        }
                        if (satz[a] == ':')
                        {
                            a++;
                            continue;
                        }
                        if (satz[e] == ':')
                        {
                            e--;
                            continue;
                        }
                    }
                    if(satz[a] == satz[e])
                    {
                        a++;
                        e--;
                        continue;
                    }
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

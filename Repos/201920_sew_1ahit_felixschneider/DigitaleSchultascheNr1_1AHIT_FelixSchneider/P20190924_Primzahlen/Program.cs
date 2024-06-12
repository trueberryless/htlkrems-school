using System;

namespace P20191008_OlympiadeSiegerehrung
{
    class Program
    {
        static void Main(string[] args)
        {
            int platz = 0;
            string name = "";
            string medaille = "";

            Console.WriteLine("Wie heißen Sie?");
            name = Console.ReadLine();
            Console.WriteLine("Welchen Platz haben Sie bei der Olympiade belegt?");
            platz = Convert.ToInt32(Console.ReadLine());

            if (platz >= 7)
            {
                Console.WriteLine(name + " kann leider nicht an der Siegerehrung teilnehmen!");
            }
            else
            {
                if (platz >= 4)
                {
                    Console.WriteLine(name + " bokommt einen Blumenstrauß!");
                }
                else
                {
                    if (platz == 3)
                    {
                        medaille = "bronzene";
                    }
                    else
                    {
                        if (platz == 2)
                        {
                            medaille = "silberne";
                        }
                        else
                        {
                            if (platz == 1)
                            {
                                medaille = "goldene";
                            }
                            else
                            {
                                if (platz <= -1)
                                {
                                    Console.WriteLine("Ein Platz kann mathematisch gesehen niemals negativ sein!");
                                }
                                else
                                {
                                    if (platz == 0)
                                    {
                                        Console.WriteLine("Die Zahl 0 ist kein zu vergebender Platz!");
                                    }
                                }
                            }
                        }
                        if (medaille != "") // verletzt das DRY-Prinzip nicht
                        {
                            Console.WriteLine("{0} hat die {1} Medaille gewonnen!",name, medaille);
                        }
                       
                    }
                }
            }   

        }
    }
}

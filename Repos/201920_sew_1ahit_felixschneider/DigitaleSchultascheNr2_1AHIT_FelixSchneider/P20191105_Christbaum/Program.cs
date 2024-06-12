using System;
using System.Threading;

namespace P20191105_Christbaum
{
    class Program
    {
        static void Main(string[] args)
        {
            //gewünschte Höhe und Breite des Baumes
            const int size = 566;
            //Zufallsgenerator für den Schneefall
            Random snow = new Random();
            //Zufallsgenerator für Baum
            Random tree = new Random();
            //Zufallsgenerator für Baum
            Random tree1 = new Random();
            while (true)
            {
                //äußere Schleife für jede Zeile
                for (int i = 0; i < size; i++)
                {
                    //Scheeflocken links
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = size; j > i; j--)
                    {
                        if (snow.Next(1, 100) < 35)
                            Console.Write(".");
                        else
                            Console.Write(" ");
                    }
                    //Baum
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("*");
                    for (int j = 0; j < i; j++)
                    {
                        
                        if ((i+j) % 7 == 0)
                        { 
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("0");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("*");                       
                        }
                        else if (tree.Next(1, 100) <= 33)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("i");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("*");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("**");
                        } 
                    }
                   

                    //Schneflocken rechts
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = size; j > i; j--)
                    {
                        if (snow.Next(1, 100) < 35)
                            Console.Write(".");
                        else
                            Console.Write(" ");
                    }
                    Console.WriteLine();//nächste Zeile
                    
                    
                }
                //Stamm
                //Baumstamm Zeilen
                for (int i = 0; i < size/3; i++)
                {
                    //Schneeflocken links unter Baum
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < size - size / 6; j++)
                    {
                        if (snow.Next(1, 100) < 35)
                            Console.Write(".");
                        else
                            Console.Write(" ");
                    }


                    //Baumstamm
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("|");
                    for (int j = 1; j <= size/3; j++)
                    {
                        Console.Write("|");
                    }
                    
                  

                    //Schneeflocken rechts unter Baum
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < size - size / 6; j++)
                    { 
                        if (snow.Next(1, 100) < 35)
                            Console.Write(".");
                        else
                            Console.Write(" ");
                    }
                    Console.WriteLine();

                }
                //Schnee
                int m = 0;
                Console.BackgroundColor = ConsoleColor.White;
                do
                {
                    for (int j = size * 2 + 1; j > 0; j--)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    m++;
                } while (m < size / 6);
                //Console wird wieder schwarz
                Console.BackgroundColor = ConsoleColor.Black;
                //Ende der äußeren Schleife
                //Pause
                System.Threading.Thread.Sleep(1000);
                Console.SetCursorPosition(0, 0);
            }

            
            
        }
    }
}

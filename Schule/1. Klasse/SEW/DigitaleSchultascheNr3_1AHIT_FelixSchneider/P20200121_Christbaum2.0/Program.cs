using System;
using System.Threading;

namespace P20200121_Christbaum2._0
{
    class Program
    {
        
        static int size = 0;

        static Random snow = new Random();
        static Random tree = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie eine beliebige Größe für den Christbaum ein!");
            size = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            while (true)
            {
                for (int i = 0; i < size; i++)
                {
                    Schneeflocken(i);           //Links
                    Baum(i);                    //Links
                    Schneeflocken(i);           //Rechts
                    Console.WriteLine();
                }                
                for (int i = 0; i < size/3; i++)
                {
                    SchneeBaum(i);
                    Baumstamm(i);
                    SchneeBaum(i);
                    Console.WriteLine();                    
                }
                for (int i = 0; i < size/5; i++)
                {
                    Schnee(i);
                }
                System.Threading.Thread.Sleep(1000);
                Console.SetCursorPosition(0, 0);
            }
        }
        static void Schneeflocken(int i)
        {       
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            for (int j = size; j > i; j--)
            {
                if (snow.Next(1, 100) < 35)
                    Console.Write(".");
                else
                    Console.Write(" ");
            }
        }
        static void Baum(int i)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("*");
            for (int j = 0; j < i; j++)
            {

                if ((i + j) % 4 == 0)
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
        }
        static void SchneeBaum(int i)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            for (int j = 0; j < size - size / 6; j++)
            {
                if (snow.Next(1, 100) < 35)
                    Console.Write(".");
                else
                    Console.Write(" ");
            }
            

        }
        static void Baumstamm(int i)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int j = 1; j <= size / 3; j++)
            {
                Console.Write("|");
            }
            if(size < 33)
                Console.Write("|");

        }
        static void Schnee(int i)
        {
            Console.BackgroundColor = ConsoleColor.White;
            for (int j = 0; j <= size*2; j++)
            {
                Console.Write(" ");
            }
            Console.WriteLine();
        }
      
    }
}

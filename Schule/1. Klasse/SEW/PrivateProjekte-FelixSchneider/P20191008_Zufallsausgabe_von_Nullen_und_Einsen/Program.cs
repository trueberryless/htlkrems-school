using System;
using System.Threading;


namespace P20191008_Zufallsausgabe_von_Nullen_und_Einsen
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Random rnd = new Random();
                int x = rnd.Next(10);
                //Thread.Sleep(10);
                Console.Write(x);
            }
        }
    }
}

using System;
using System.Threading;

namespace Binärzahlenausgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Random rnd = new Random();
                int x = rnd.Next(2);
                Console.Write(x);
            }
        }
    }
}

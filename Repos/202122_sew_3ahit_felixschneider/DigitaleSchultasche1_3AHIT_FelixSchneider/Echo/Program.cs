using System;
using Echo_DLL;

namespace Echo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Echo_DLL.Echo.GetEcho(Console.ReadLine())); //Echo_DLL eig nicht notwendig
        }
    }
}

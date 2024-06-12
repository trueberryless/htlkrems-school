using System;

namespace VerstaendnisMainMethode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
                Console.WriteLine("Bitte Argumente angeben");
            else foreach (var item in args)
                {
                    Console.WriteLine(item);
                }
        }
    }
}

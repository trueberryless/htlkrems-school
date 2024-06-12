using System;
using System.Threading;

namespace P20201106_Movers
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimUrtier ut = new AnimUrtier(200);
            ut.Start();
        }
    }
}

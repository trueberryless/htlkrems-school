using System;
using System.Numerics;
using System.Threading;

namespace P20190917_Stoppuhr
{
    class Program
    {

        static void Main(string[] args)
        {
            int s, m, h;
            s = 0;
            m = 0;
            h = 0;
            string so, mo, ho;
            so = "";
            mo = "";
            ho = "";
            Console.Write("00 Stunden 00 Minuten 00 Sekunden");
            Thread.Sleep(1000);
            Console.Clear();
            while (true)
            {
                s++;
                if (s == 60)
                {
                    m++;
                    s = 0;
                }
                if (m == 60)
                {

                    h++;
                    m = 0;
                }
                if (s < 10)
                {
                    so = "0" + s;
                }
                else
                {
                    so = "" + s;
                }
                if (m < 10)
                {
                    mo = "0" + m;
                }
                else
                {
                    mo = "" + m;
                }
                if (h < 10)
                {
                    ho = "0" + h;
                }
                else
                {
                    ho = "" + h;
                }
                Console.WriteLine(ho + " Stunden " + mo + " Minuten " + so + " Sekunden");
                Thread.Sleep(1000);
                Console.Clear();             
            }
        }
    }
}
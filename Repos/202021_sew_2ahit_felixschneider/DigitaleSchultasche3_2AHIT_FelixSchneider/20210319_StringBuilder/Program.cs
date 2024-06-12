using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _20210319_StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Lottozahlen lz = new Lottozahlen();
            lz.Hinzu(43);
            lz.Hinzu(13);
            lz.Hinzu(78);
            lz.Hinzu(12);
            lz.Hinzu(3);
            lz.Hinzu(5);
            lz.Hinzu(24);

            StringBuilder sb = new StringBuilder();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                string x = lz.ToString();
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        class Lottozahlen
        {
            List<int> zahlen = new List<int>();

            public void Hinzu(int neueZahl)
            {
                zahlen.Add(neueZahl);
            }

            public override string ToString()
            {
                zahlen.Sort();
                StringBuilder sb = new StringBuilder();
                foreach(var item in zahlen)
                {
                    sb.Append(item);
                }
                return sb.ToString();
            }
        }
    }
}

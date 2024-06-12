using System;
using System.IO;

namespace P20201218_DateienLesenSchreiben
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("daten.txt");
            sw.WriteLine("Hello, World");
            sw.Flush(); //zwischenspeicher
            sw.WriteLine("Hallo, noch jemand");
            sw.Flush(); //zwischenspeicher
            sw.WriteLine("Hello, allerseits");
            sw.Flush(); //zwischenspeicher
            sw.Close();

            StreamReader sr = new StreamReader("daten.txt");
            while (sr.Peek() != - 1) // -1 entsprach "EOF" also "end of file"
            {
                string zeile = sr.ReadLine();
                Console.WriteLine(zeile);
            }            
            sr.Close();

            using(StreamWriter sw1 = new StreamWriter(@"c:\temp\MyTest.txt")) // @ erspart mir \\ statt \ --- ganuz "bequem"
            {
                sw1.WriteLine("Hello, World");
                sw1.Flush(); //zwischenspeicher
                sw1.WriteLine("Hallo, noch jemand");
                sw1.Flush(); //zwischenspeicher
                sw1.WriteLine("Hello, allerseits");
                sw1.Flush(); //zwischenspeicher
            }   //man spart sich close(), weil dieses vom using 
                //automatisch aufgerufen wird

            using(StreamReader sr1 = new StreamReader("c:\\temp\\MyTest.txt")) // ohne @ brauche ich \\ für \ --- eher "unbequem"
            {
                while (sr1.Peek() != -1)
                {
                    string zeile = sr1.ReadLine();
                    Console.WriteLine(zeile);
                }
            }   //dieses Muster wird normalerweise verwendet            
        }
    }
}

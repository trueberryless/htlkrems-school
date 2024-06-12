using System;
using System.Collections;
using System.Linq;

namespace UebungLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //LINQ = SQL f+r Arrays
            int[] data = { 1, 2, 3, 4, 5, 6, 7 };

            var even = //pretty print SQL syntax
                from x in data 
                where (x % 2 == 0) 
                select x;
            foreach (var item in even)
                Console.Write(item);

            Console.WriteLine();
            var odd = //Methodensyntax
                data.Where((x)=> x % 2 == 1);

            foreach (var item in odd)
                Console.Write(item);

            // --- Iterator (foreach bei input und output)
            // delegate (lambda, anonymous method)
            // -- object initializer
            // -- extension methods
            // -- implicitly typed local variable ("var")
            // -- anonymous class

            A a = new A();
            a.Greet();

            int xx = 23;
            Console.WriteLine(xx.toHex());

            var s = 3.5+"3";

            var v = new { A = 2, B = "Felix" };
            var w = new { A = 3, B = "Susi" };
            v = w;
            //w ist eine anonyme klasse
        }
    }

    public sealed class A { 
        //erweitere die Klasse A - GEHT NED !!
    }
    public static class MyExtensions
    {
        public static void Greet(this A a)
        {
            Console.WriteLine("Hello from a");
        }
        public static string toHex(this int i) {
            return i.ToString("x");
        }

        // MS schrieb eine Extension Methos "Where", welche 
        // IEnumerable um die Funktion eines als objekt übergebenen 
        // Lambda ausdrucks erweitert, welcher genau diese elemente
        // als neues IEnumerable zurückgibt.
            
        // SELECT,GROUPBY,JOIN,FROM,... wurschtwos siehe SQL
        public static IEnumerable Where(this IEnumerable ie) {
            /* add code */
            throw new NotImplementedException();
        }
    }
}

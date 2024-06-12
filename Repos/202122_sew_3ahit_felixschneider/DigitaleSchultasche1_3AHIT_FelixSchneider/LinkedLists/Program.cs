using System;

namespace LinkedLists
{
    class Program
    {
        static Random randy = new Random() { };
        static void Main(string[] args)
        {
            MyLinkedList<string> ll = new MyLinkedList<string>();            
            for (int i = 0; i < 10; i++)          
            {
                ll.InsertFront(randy.Next(1, 10).ToString());
            }
            Console.WriteLine(ll);
            ll.Swap(ll.Head.Next.Next, ll.Head.Next.Next.Next.Next);
            Console.WriteLine(ll);
        }
    }
}

using System;

namespace GenericBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericTree<int> genericTree = new GenericTree<int>();
            genericTree.Insert(new int[] { 7, 1, 4, 2, 8, 3, 9 });

            Console.WriteLine(genericTree.Find(8).Data);
        }
    }
}

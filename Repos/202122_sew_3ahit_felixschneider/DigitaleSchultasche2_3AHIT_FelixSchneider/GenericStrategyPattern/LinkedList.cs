using System;
using System.Collections.Generic;
using System.Text;

namespace GenericStrategyPattern
{
    interface IList<T> where T : IComparable<T>
    {
        Node<T> Head { get; }
        Node<T> Tail { get; }

        //Add a Node
        void InsertFront(Node<T> newNode);
        void InsertLast(Node<T> newNode);
        void InsertSorted(Node<T> newNode);

        //Add a Value
        void InsertFront(T value);
        void InsertLast(T value);
        void InsertSorted(T value);

        //Print
        string PrintList();
        string PrintListReverse();

        //Search and ...
        bool Contains(T value);
        Node<T> Find(T value);

        //Find Minimum & Maximum Recursive
        Node<T> FindMinRec();
        Node<T> FindMaxRec();

        //Remove: remove the node from the list and return it
        Node<T> Remove(T value);

        //Delete: remove the node from the list and delete it
        void Delete(T value);

        //Sort 
        //Use a strategy Pattern with a SortBehavior
        void Sort();

        //Returns true if the whole list is sorted
        bool IsSorted();

        //Print Recursive
        void PrintListRec();
        void PrintListReverseRec();
    }
    class LinkedList<T> where T : IComparable<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDoubleLinkedList
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

    class LinkedList<T> : IList<T> where T : IComparable<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public bool Contains(T value)
        {
            if (Head != null && Tail != null)
            {
                Node<T> tmp = Head;
                while(tmp != null)
                {
                    if (tmp.Data.ToString() == value.ToString())
                        return true;
                    tmp = tmp.Next;
                }
                return false;
            }
            else return false;
        }

        public void Delete(T value)
        {
            if (Head != null && Tail != null)
            {
                Node<T> tmp = Head;
                while(tmp != null)
                {
                    if (tmp.Data.ToString() == value.ToString())
                    {
                        tmp.Prev.Next = tmp.Next;
                        tmp.Next.Prev = tmp.Prev;
                        break;
                    }
                    tmp = tmp.Next;
                }
            }
        }

        public Node<T> Find(T value)
        {
            Node<T> tmp = Head;
            if (Head != null && Tail != null)
            {                
                while (tmp != null)
                {
                    if (tmp.Data.ToString() == value.ToString())
                        break;
                    tmp = tmp.Next;
                }
                if (tmp.Data.ToString() != value.ToString())
                    return null;
            }
            return tmp;
        }

        public Node<T> FindMaxRec()
        {
            Node<T> tmp = Head, max = Head;
            if (Head != null && Tail != null)
            {
                while (tmp.Next != null)
                {
                    if (tmp.Data.ToString().CompareTo(tmp.Next.Data.ToString()) > 0)
                        max = tmp;
                    tmp = tmp.Next;
                }
            }
            return max;
        }

        public Node<T> FindMinRec()
        {
            Node<T> tmp = Head, min = Head;
            if (Head != null && Tail != null)
            {
                while (tmp.Next != null)
                {
                    if (tmp.Data.ToString().CompareTo(tmp.Next.Data.ToString()) < 0)
                        min = tmp;
                    tmp = tmp.Next;
                }
            }
            return min;
        }

        public void InsertFront(Node<T> newNode)
        {
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
                newNode.Next.Prev = newNode;
            }
        }

        public void InsertFront(T value)
        {
            InsertFront(Find(value));
        }

        public void InsertLast(Node<T> newNode)
        {
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Prev = Tail;
                Tail = newNode;
                newNode.Prev.Next = newNode;
            }
        }

        public void InsertLast(T value)
        {
            InsertLast(Find(value));
        }

        public void InsertSorted(Node<T> newNode)
        {
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Node<T> tmp = Head;
                while (tmp.Next.Data.ToString().CompareTo(newNode.Data.ToString()) != 0)
                {
                    newNode.Next = tmp.Next;
                    tmp.Next = newNode;
                    newNode.Prev = tmp;
                    tmp.Next.Prev = newNode;
                }
            }
        }

        public void InsertSorted(T value)
        {
            InsertSorted(Find(value));
        }

        public bool IsSorted()
        {
            if (Head != null && Tail != null)
            {
                Node<T> tmp = Head;
                while(tmp.Next != null)
                {
                    if (tmp.Data.CompareTo(tmp.Next.Data) > 0)
                        return false;
                    tmp = tmp.Next;
                }
            }
            else return false;
            return true;
        }

        public string PrintList()
        {
            StringBuilder sb = new StringBuilder();
            Node<T> tmp = Head;
            while(tmp != null)
            {
                sb.Append(tmp.Data);
                tmp = tmp.Next;
            }
            return sb.ToString();
        }

        public void PrintListRec()
        {
            Node<T> tmp = Head;
            PrintListRec(tmp);
        }

        private void PrintListRec(Node<T> tmp)
        {
            if(tmp != null)
            {
                Console.Write(tmp.Data + ", ");
                PrintListRec(tmp.Next);
            }
        }

        public string PrintListReverse()
        {
            StringBuilder sb = new StringBuilder();
            Node<T> tmp = Tail;
            while (tmp != null)
            {
                sb.Append(tmp.Data);
                tmp = tmp.Prev;
            }
            return sb.ToString();
        }

        public void PrintListReverseRec()
        {
            Node<T> tmp = Head;
            PrintListReverseRec(tmp);
        }
        private void PrintListReverseRec(Node<T> tmp)
        {
            if (tmp != null)
            {
                PrintListRec(tmp.Next);
                Console.Write(tmp.Data + ", ");
            }
        }

        public Node<T> Remove(T value)
        {
            Node<T> tmp = null;
            if (Head != null)
            {
                tmp = Head;
                while (tmp != null)
                {
                    if (tmp.Data.ToString() == value.ToString())
                    {
                        tmp.Prev.Next = tmp.Next;
                        tmp.Next.Prev = tmp.Prev;
                        return tmp;
                    }
                    tmp = tmp.Next;
                }
            }
            return tmp;
        }

        public void Sort()
        {
            if(Head != null)
            {
                Node<T> tmp = Head;
                while(tmp.Next != null)
                {
                    if(tmp.Data.CompareTo(tmp.Next.Data) > 0)
                    {
                        tmp.Next.Prev = tmp.Prev;
                        tmp.Next = tmp.Next.Next;
                        tmp.Prev = tmp.Next.Prev;
                        tmp.Next.Prev.Next = tmp;
                        
                    }
                    tmp = tmp.Next;
                }
            }
        }
    }

    public class HeadIsNullException : Exception
    {
        public HeadIsNullException() { }
        public HeadIsNullException(string msg) { throw new Exception(msg); }
    }
}

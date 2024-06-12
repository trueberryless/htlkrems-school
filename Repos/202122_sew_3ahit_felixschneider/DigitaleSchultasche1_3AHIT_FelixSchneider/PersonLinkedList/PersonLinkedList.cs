using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLinkedList
{
    public class PersonLinkedList
    {
        public PersonNode Head { get; set; }
        public int Length
        {
            get
            {
                int counter = 0;
                PersonNode tmp = Head;
                if (tmp != null)
                    counter = 1;
                while(tmp.Next != null)
                {
                    counter++;
                    tmp = tmp.Next;
                }
                return counter;
            }
        }

        public void InsertFront(string name)
        {
            InsertFront(new PersonNode(name));
        }

        public void InsertFront(PersonNode n)
        {
            if(n != null)
            {
                if (Head == null)
                    Head = n;
                else
                {
                    n.Next = Head;
                    Head = n;
                }
            }
                
        }

        public void InsertLast(string name)
        {
            InsertLast(new PersonNode(name));
        }

        public void InsertLast(PersonNode n)
        {
            if (n != null)
            {
                if (Head == null)
                    Head = n;
                else
                {
                    PersonNode tmp = Head;
                    while (tmp.Next != null)
                        tmp = tmp.Next;
                    tmp.Next = n;
                }
            }
        }

        public void InsertBefore(string value, string idx)
        {            
            InsertBefore(new PersonNode(value), idx);
        }

        public void InsertBefore(PersonNode n, string idx)
        {
            PersonNode idxNode = Head;
            while (idxNode.Name != idx)
                idxNode = idxNode.Next;
            InsertBefore(n, idxNode);
        }

        public void InsertBefore(string value, PersonNode idxNode)
        {
            InsertBefore(new PersonNode(value), idxNode);
        }

        public void InsertBefore(PersonNode n, PersonNode idxNode)
        {
            if (n != null && idxNode != null)
            {
                if (Head == null)
                    Head = n;
                else
                {
                    PersonNode tmp = Head;
                    while (tmp.Next != idxNode)
                        tmp = tmp.Next;
                    n.Next = tmp.Next;
                    tmp.Next = n;
                }
            }
        }

        public void InsertAfter(string value, string idx)
        {
            InsertAfter(new PersonNode(value), idx);
        }

        public void InsertAfter(PersonNode n, string idx)
        {
            PersonNode idxNode = Head;
            while (idxNode.Name != idx)
                idxNode = idxNode.Next;
            InsertAfter(n, idxNode);
        }

        public void InsertAfter(string value, PersonNode idxNode)
        {
            InsertAfter(new PersonNode(value), idxNode);
        }

        public void InsertAfter(PersonNode n, PersonNode idxNode)
        {
            if (n != null && idxNode != null)
            {
                if (Head == null)
                    Head = n;
                else
                {
                    PersonNode tmp = Head;
                    while (tmp != idxNode)
                        tmp = tmp.Next;
                    n.Next = tmp.Next;
                    tmp.Next = n;
                }
            }
        }

        public void Remove(int idx)
        {
            if (Head == null)
                throw new HeadIsNullException();
            PersonNode tmp = Head;
            for (int i = 0; i < idx; i++)
            {
                if (tmp.Next != null)
                    tmp = tmp.Next;
                else
                    throw new Exception("List has not so many nodes!");
            }
            Remove(tmp);
        }

        public void Remove(string value)
        {
            PersonNode tmp = Head;
            while (tmp.Name != value && tmp != null)
                tmp = tmp.Next;
            if (tmp == null)
                throw new Exception("Nobody has this name!");
            Remove(tmp);
        }

        public void Remove(PersonNode n)
        {
            if (n != null)
            {
                if (Head != null)
                {
                    PersonNode tmp = Head;
                    while (tmp.Next != n)
                        tmp = tmp.Next;
                    tmp.Next = tmp.Next.Next;
                }
                else
                    throw new HeadIsNullException();
            }
        }

        public PersonNode Search(string value)
        {
            return Search(Head, value);
        }

        public PersonNode Search(PersonNode start, string value)
        {
            PersonNode tmp = start;
            while (tmp != null)
            {
                if (tmp.Name == value)
                    return tmp;
                tmp = tmp.Next;
            }
            throw new Exception("Nobody has this name!");
        }

        public bool Contains(string value)
        {
            PersonNode tmp = Head;
            while (tmp != null)
            {
                if (tmp.Name == value)
                    return true;
                tmp = tmp.Next;
            }                
            return false;
        }

        public void PrintList()
        {
            if (Head == null)
                throw new HeadIsNullException();
            PersonNode tmp = Head;
            while(tmp.Next != null)
            {
                Console.Write($"{tmp.Name}, ");
                tmp = tmp.Next;
            }
        }
    }

    class HeadIsNullException : Exception
    {
        public HeadIsNullException() { }
        public HeadIsNullException(string msg) : base(msg) { }
    }
}

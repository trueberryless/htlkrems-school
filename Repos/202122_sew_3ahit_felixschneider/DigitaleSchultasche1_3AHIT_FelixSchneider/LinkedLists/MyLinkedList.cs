using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists
{
    class MyLinkedList<T>
    {
        public Node<T> Head { get; private set; }

        public int Length
        {
            get
            {
                int count = 0;
                Node<T> tmp = Head;
                while (tmp != null)
                {
                    count++;
                    tmp = tmp.Next;
                }
                return count;
            }
        }

        public void InsertFront(T value)
        {
            InsertFront(new Node<T>(value));
        }

        public void InsertFront(Node<T> n)
        {
            if (Head == null)
                Head = n;
            else
            {
                n.Next = Head;
                Head = n;
            }
        }

        public void InsertLast(T value)
        {
            InsertLast(new Node<T>(value));
        }

        public void InsertLast(Node<T> n)
        {
            if (Head == null)
                Head = n;
            else
            {
                Node<T> t = Head;
                while (t.Next != null)
                    t = t.Next;
                t.Next = n;
            }
        }

        public void Swap(Node<T> a, Node<T> b)
        {
            if(Head != null)
            {
                Node<T> t1 = Head, t2 = Head;
                while (t1.Next != a || t2.Next != b)
                {
                    if (t1.Next != a)
                        t1 = t1.Next;
                    if (t2.Next != b)
                        t2 = t2.Next;
                }
                t1.Next = b;
                t2.Next = a;
                a.Next = b.Next;
                b.Next = t2;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node<T> tmp = Head;
            while (tmp != null)
            {
                sb.Append(tmp.Content);
                sb.Append(" -> ");
                tmp = tmp.Next;
            }
            sb.Append(Length);
            return sb.ToString();
        }
    }
}

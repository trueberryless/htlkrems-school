using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDoubleLinkedList
{
    class Node<T> where T: IComparable<T>
    {
        public T Data { get; set; }

        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }
    }
}

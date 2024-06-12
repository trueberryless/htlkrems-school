using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBinaryTree
{
    public class Node<T> where T:IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }
}

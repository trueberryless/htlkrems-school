using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists
{
    class Node<T>
    {
        public T Content { get; private set; }

        public Node<T> Next { get; set; }

        public Node(T value)
        {
            this.Content = value;
        }
    }
}

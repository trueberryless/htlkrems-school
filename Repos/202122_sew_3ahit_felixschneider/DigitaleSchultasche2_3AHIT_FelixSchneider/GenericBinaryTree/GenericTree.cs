using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBinaryTree
{
    public class GenericTree<T> where T : IComparable<T>
    {
        protected Random randy = new Random();
        public Node<T> Root { get; set; }

        public Node<T> Find(T item)
        {
            Node<T> tmp = Root;
            return FindRec(item, tmp);
        }

        public Node<T> FindRec(T item, Node<T> tmp)
        {
            if(tmp == null || tmp.Data.ToString() == item.ToString())
                return tmp;
            if (tmp.Data.CompareTo(item) < 0)
                return FindRec(item, tmp.Right);
            return FindRec(item, tmp.Left);            
        }

        public int GetDepth()
        {
            Node<T> tmp = Root;
            return GetDepth(tmp);
        }

        private int GetDepth(Node<T> tmp)
        {
            if (tmp == null)
                return -1;
            else
            {
                int lDepth = GetDepth(tmp.Left);
                int rDepth = GetDepth(tmp.Right);

                if (lDepth > rDepth)
                    return lDepth + 1;
                else return rDepth + 1;

                //return Math.Max(GetDepth(tmp.Left), GetDepth(tmp.Right)) + 1;
            }              
        }        

        public void Insert(T[] arr)
        {
            foreach (var item in arr)
                Insert(item);
        }

        public void Insert(T item)
        {
            Insert(new Node<T>(item));
        }

        public void Insert(Node<T> newNode)
        {
            if(Root == null)
                Root = newNode;
            else
            {
                Node<T> current = Root;
                Node<T> parent;
                while (true)
                {
                    parent = current;
                    if(newNode.Data.CompareTo(current.Data) < 0)
                    {
                        current = current.Left;
                        if(current == null)
                        {
                            parent.Left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if(current == null)
                        {
                            parent.Right = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public void PreOrder()
        {
            if (Root == null)
                throw new TreeIsEmpty();
            PreOrder(Root);
        }

        private void PreOrder(Node<T> tmp)
        {
            if (tmp != null)
            {
                Console.Write(tmp.Data.ToString() + ", ");
                PreOrder(tmp.Left);
                PreOrder(tmp.Right);
            }
        }

        public void InOrder()
        {
            if (Root == null)
                throw new TreeIsEmpty();
            InOrder(Root);
        }

        private void InOrder(Node<T> tmp)
        {
            if (tmp != null)
            {
                InOrder(tmp.Left);
                Console.Write(tmp.Data.ToString() + ", ");
                InOrder(tmp.Right);
            }
        }

        public void PostOrder()
        {
            if (Root == null)
                throw new TreeIsEmpty();
            PostOrder(Root);
        }

        private void PostOrder(Node<T> tmp)
        {
            if (tmp != null)
            {
                PostOrder(tmp.Left);
                PostOrder(tmp.Right);
                Console.Write(tmp.Data.ToString() + ", ");
            }
        }
    }

    public class TreeIsEmpty:Exception
    {
        public TreeIsEmpty() { }
        public TreeIsEmpty(string msg):base(msg) { }
    }
}

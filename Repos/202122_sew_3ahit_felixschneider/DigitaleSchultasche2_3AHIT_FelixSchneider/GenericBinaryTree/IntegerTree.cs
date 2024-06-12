using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBinaryTree
{
    class IntegerTree:GenericTree<int>
    {
        public void GenerateRandomTree(int size)
        {
            if(size > 0)
                GenerateRandomTree(size - 1);
            this.Insert(randy.Next(1, 100));
        }
    }
}

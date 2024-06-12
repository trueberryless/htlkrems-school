using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLinkedList
{
    public class PersonNode
    {
        public string Name { get; private set; }
        public PersonNode Next { get; set; }
        public PersonNode(string name)
        {
            this.Name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vokabeln
{
    public interface IMoveable
    {
        void Move();
    }

    public class Car : IMoveable
    {
        public void Move()
        {
            Console.WriteLine("Das Auto fährt.");
        }
    }

    public class Human : IMoveable
    {
        public void Move()
        {
            Console.WriteLine("Der Mensch geht.");
        }
    }
}

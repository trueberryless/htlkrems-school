using System;

namespace _20210312_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyIntStack mis = new MyIntStack();
            //mis.Push(1);
            //mis.Push(2);
            //mis.Push(3);
            //Console.WriteLine(mis.Pop());
            //Console.WriteLine(mis.Pop());
            //Console.WriteLine(mis.Pop());

            MyGenericStack<int> mgs = new MyGenericStack<int>();  // WICHITG //
            mgs.Push(1);
            mgs.Push(2);
            mgs.Push(3);
            Console.WriteLine(mgs.Pop());
            Console.WriteLine(mgs.Pop());
            Console.WriteLine(mgs.Pop());
        }
    }

    class MyIntStack //Zahlenstapel: LIFO - Last In, First Out
    {
        const int size = 10;
        int[] elements = new int[size];
        int current = 0;

        public void Push(int el)
        {
            elements[current++] = el; //fehlt prüfen auf Überlauf
        }

        public int Pop()
        {
            return elements[--current]; //fehlt prüfen auf Überlauf
        }
    }

    class MyStringStack //Stringstapel: LIFO - Last In, First Out
    {
        const int size = 10;
        string[] elements = new string[size];
        int current = 0;

        public void Push(string el)
        {
            elements[current++] = el; //fehlt prüfen auf Überlauf
        }

        public string Pop()
        {
            return elements[--current]; //fehlt prüfen auf Überlauf
        }
    }

    class MyGenericStack<T> //Generic-Datentyp
    {
        const int size = 10;
        T[] elements = new T[size];
        int current = 0;

        public void Push(T el)
        {
            if (current <= size)
                elements[current++] = el;
            else
                throw new Exception("No place in here!");
        }

        public T Pop()
        {
            if(current >= 0)
                return elements[--current];
            throw new Exception("No more Data!");
        }
    }
}

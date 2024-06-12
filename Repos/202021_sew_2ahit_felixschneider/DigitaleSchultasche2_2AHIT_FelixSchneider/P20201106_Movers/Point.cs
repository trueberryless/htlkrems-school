using System;
using System.Collections.Generic;
using System.Text;

namespace P20201106_Movers
{
    class Point
    {
        char symbol;

        private int x;
        public int X
        {
            get { return x; }
            set { 
                if(value >= 0 && value < Console.WindowWidth)
                    x = value;
            }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set
            {
                if (value >= 0 && value < Console.WindowHeight)
                    y = value;
            }
        }

        public Point()
        {
            x = 0;
            y = 0;
            symbol = '■';
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            symbol = '■';
        }

        public Point(int x, int y, char s)
        {
            X = x;
            Y = y;
            symbol = s;
        }

        public bool IsOnXY(int x, int y)
        {
            if(this.x == x && this.y == y)
                return true;
            return false;
        }

        public void Show()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
}

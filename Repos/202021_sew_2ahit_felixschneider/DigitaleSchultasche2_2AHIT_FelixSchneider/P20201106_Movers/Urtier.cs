using System;
using System.Collections.Generic;
using System.Text;

namespace P20201106_Movers
{
    class Urtier
    {
        static Random randy = new Random();

        Point pos;
        protected ConsoleColor fg;
        protected ConsoleColor bg;
        protected diretion dir;

        public Urtier(int x, int y)
        {
            pos = new Point(x, y);
            fg = ConsoleColor.Red;
            bg = ConsoleColor.Black;
        }

        public Urtier(int x, int y, ConsoleColor fg)
        {
            pos = new Point(x, y);
            this.fg = fg;
            bg = ConsoleColor.Black;
        }

        public int X()
        {
            return pos.X;
        }

        public int Y()
        {
            return pos.Y;
        }

        public ConsoleColor Fg()
        {
            return fg;
        }
        public void Show()
        {
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
            pos.Show();
        }

        public void ChangeFg(ConsoleColor fg)
        {
            this.fg = fg;
        }

        public virtual void Move()
        {
            MoveDirection();
        }

        protected void MoveDirection()
        {
            int x_old = pos.X;
            int y_old = pos.Y;
            dir = GetDirectionRandom();

            switch (dir)
            {
                case diretion.N:
                    pos.Y--;
                    break;
                case diretion.S:
                    pos.Y++;
                    break;
                case diretion.E:
                    pos.X += 2;
                    break;
                case diretion.W:
                    pos.X -= 2;
                    break;
            }

            Show();
            if (pos.IsOnXY(x_old, y_old) == false)
            {
                Console.SetCursorPosition(x_old, y_old);
                Console.Write(" ");
            }
            
        }

        private diretion GetDirectionRandom()
        {
            switch (randy.Next(1, 5))
            {
                case 1: return diretion.N;
                case 2: return diretion.S;
                case 3: return diretion.E;
                case 4: return diretion.W;
                default: return diretion.N;
            }
        }
    }
}

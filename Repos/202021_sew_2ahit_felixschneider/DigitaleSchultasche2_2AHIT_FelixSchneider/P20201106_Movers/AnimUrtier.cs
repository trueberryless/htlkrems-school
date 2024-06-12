using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace P20201106_Movers
{
    class AnimUrtier
    {
        Random randy = new Random();

        private int anzahl;
        public AnimUrtier()
        {
            anzahl = 5;
        }

        public AnimUrtier(int anzahl)
        {
            this.anzahl = anzahl;
        }

        public void Start()
        {
            Console.CursorVisible = false;
            ConsoleColor fg;
            Urtier[] ut = new Urtier[anzahl];
            for(int i = 0; i < anzahl; i ++)
            {
                fg = ColorGenerator();
                ut[i] = new Urtier(randy.Next(1, Console.WindowWidth), randy.Next(1, Console.WindowHeight), fg);
                ut[i].Show();
            }

            while (true)
            {
                for (int i = 0; i < anzahl; i++)
                {
                    ut[i].Move();
                    for(int j = 0; j < anzahl; j++)
                    {
                        if(ut[i].X() == ut[j].X() && ut[i].Y() == ut[j].Y())
                        {
                            ut[j].ChangeFg(ut[i].Fg());
                        }
                    }
                }                
            }
        }

        private ConsoleColor ColorGenerator()
        {
            switch (randy.Next(1, 16))
            {
                case 1: return ConsoleColor.Blue;
                case 2: return ConsoleColor.Red;
                case 3: return ConsoleColor.DarkGray;
                case 4: return ConsoleColor.Yellow;
                case 5: return ConsoleColor.DarkBlue;
                case 6: return ConsoleColor.DarkGreen;
                case 7: return ConsoleColor.Green;
                case 8: return ConsoleColor.DarkRed;
                case 9: return ConsoleColor.Cyan;
                case 10: return ConsoleColor.Magenta;
                case 11: return ConsoleColor.White;
                case 12: return ConsoleColor.DarkMagenta;
                case 13: return ConsoleColor.DarkYellow;
                case 14: return ConsoleColor.Gray;
                case 15: return ConsoleColor.DarkCyan;
                default: return ConsoleColor.Red;
            }
        }
    }
}

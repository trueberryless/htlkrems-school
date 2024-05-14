using System;

namespace P20200526_Schachspielen
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] figurnamen = new string[8, 8];
            int sp = 1;
            string from = "", to = "";
            Grundstellung(figurnamen);
            Console.WriteLine("Beispiel:\te 2   ENTER   e 4");
            while (true)
            {
                Ausgabe(figurnamen);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Eingabe(ref from, ref to, sp);
                Move(figurnamen, from, to);
                sp = sp == 1 ? 2 : 1;
                Console.Clear();
            }

        }
        static void Grundstellung(string[,] figurnamen)
        {
            figurnamen[0, 0] = "sT";
            figurnamen[0, 1] = "sP";
            figurnamen[0, 2] = "sL";
            figurnamen[0, 3] = "sD";
            figurnamen[0, 4] = "sK";
            figurnamen[0, 5] = "sL";
            figurnamen[0, 6] = "sP";
            figurnamen[0, 7] = "sT";
            figurnamen[1, 0] = "sb";
            figurnamen[1, 1] = "sb";
            figurnamen[1, 2] = "sb";
            figurnamen[1, 3] = "sb";
            figurnamen[1, 4] = "sb";
            figurnamen[1, 5] = "sb";
            figurnamen[1, 6] = "sb";
            figurnamen[1, 7] = "sb";

            figurnamen[7, 0] = "wT";
            figurnamen[7, 1] = "wP";
            figurnamen[7, 2] = "wL";
            figurnamen[7, 3] = "wD";
            figurnamen[7, 4] = "wK";
            figurnamen[7, 5] = "wL";
            figurnamen[7, 6] = "wP";
            figurnamen[7, 7] = "wT";
            figurnamen[6, 0] = "wb";
            figurnamen[6, 1] = "wb";
            figurnamen[6, 2] = "wb";
            figurnamen[6, 3] = "wb";
            figurnamen[6, 4] = "wb";
            figurnamen[6, 5] = "wb";
            figurnamen[6, 6] = "wb";
            figurnamen[6, 7] = "wb";

            for(int i = 2; i < 6; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    figurnamen[i, j] = "  ";
                }
            }
        }
        static void Ausgabe(string[,] figurnamen)
        {
            int zeilenzähler = 1; //mehrere Zeilen
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if((i+j) % 2 == 0) //schachbrettmuster
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow; //weiße Felder

                        if (zeilenzähler == 2)
                        {
                            Console.Write("   ");
                            if (figurnamen[i,j] == "wb" || figurnamen[i, j] == "wK" || figurnamen[i, j] == "wD" || figurnamen[i, j] == "wL" || figurnamen[i, j] == "wP" || figurnamen[i, j] == "wT")
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                            }                                
                            if (figurnamen[i,j] == "sb" || figurnamen[i, j] == "sK" || figurnamen[i, j] == "sD" || figurnamen[i, j] == "sL" || figurnamen[i, j] == "sP" || figurnamen[i, j] == "sT")
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                            }                                
                            Console.Write(figurnamen[i,j]);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write("        ");
                        }


                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (zeilenzähler == 1 && j == 7)
                        {
                            Console.Write(" ");
                            Console.Write(8-i);
                        }
                        if (zeilenzähler != 1 && j == 7)
                        {
                            Console.Write("  ");
                        }
                        
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray; //schwarze Felder
                        if (zeilenzähler == 2)
                        {
                            Console.Write("   ");
                            if (figurnamen[i, j] == "wb" || figurnamen[i, j] == "wK" || figurnamen[i, j] == "wD" || figurnamen[i, j] == "wL" || figurnamen[i, j] == "wP" || figurnamen[i, j] == "wT")
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            if (figurnamen[i, j] == "sb" || figurnamen[i, j] == "sK" || figurnamen[i, j] == "sD" || figurnamen[i, j] == "sL" || figurnamen[i, j] == "sP" || figurnamen[i, j] == "sT")
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            Console.Write(figurnamen[i, j]);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write("        ");
                        }

                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (zeilenzähler == 1 && j == 7)
                        {
                            Console.Write(" ");
                            Console.Write(8-i);
                        }
                        if (zeilenzähler != 1 && j == 7)
                        {
                            Console.Write("  ");
                        }
                    }

                }
                zeilenzähler++;
                Console.WriteLine();
                if(zeilenzähler < 4)
                {
                    i--;
                }
                else
                {
                    zeilenzähler = 1;
                }
            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("    A       B       C       D       E       F       G       H     ");

            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Eingabe(ref string from, ref string to, int sp)
        {
            Console.WriteLine("Spieler: " + sp);
            Console.Write("Figur von:\t");
            from = Console.ReadLine();
            Console.Write("zu:\t");
            to = Console.ReadLine();
        }
        static void Move(string[,] figurnamen, string from, string to)
        {
            int i_in = 0, j_in = 0;
            string[] from_split = from.Split(" ");
            switch (from_split[0])
            {
                case "a": j_in = 0; break;
                case "b": j_in = 1; break;
                case "c": j_in = 2; break;
                case "d": j_in = 3; break;
                case "e": j_in = 4; break;
                case "f": j_in = 5; break;
                case "g": j_in = 6; break;
                case "h": j_in = 7; break;
                default: j_in = 0; break;
            }
            i_in = 8 - (Convert.ToInt32(from_split[1]));

            int i_out = 0, j_out = 0;
            string[] to_split = to.Split(" ");
            switch (to_split[0])
            {
                case "a": j_out = 0; break;
                case "b": j_out = 1; break;
                case "c": j_out = 2; break;
                case "d": j_out = 3; break;
                case "e": j_out = 4; break;
                case "f": j_out = 5; break;
                case "g": j_out = 6; break;
                case "h": j_out = 7; break;
                default: j_out = 0; break;
            }
            i_out = 8 - (Convert.ToInt32(to_split[1]));

            figurnamen[i_out, j_out] = figurnamen[i_in, j_in];
            figurnamen[i_in, j_in] = "  ";
        }
    }
}

using System;

namespace P20200505_Viergewinnt
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] vg = new int[7,6]; //Arrys Vier Gewinnt
            int sp = 1, g = 0, runden = 42;
            int[] sm = {5,5,5,5,5,5,5}; //dieses Arrys markiert die unterste Stelle, die in jeder Spalte noch nicht bepielt ist 
            // sm = Spaltenmakierer
            Ausgabe(vg);
            while(runden > 0)
            {
                runden--;
                Eingabe(vg, sp, sm);
                Console.Clear();
                Ausgabe(vg);

                g = GewinnenWaagrecht(vg);
                if (g != 0)
                    break;
                g = GewinnenSenkrecht(vg);
                if (g != 0)
                    break;
                g = GewinnerDiagonal(vg);
                if (g != 0)
                    break;

                sp = sp == 1 ? 2 : 1;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            if (g == 0)
                Console.WriteLine("Unentschieden");
            else
            {
                if (g == 1)
                {
                    Console.Write("Gewinner ");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("red");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write("Gewinner ");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("green");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }                    
            }
        }
        static void Eingabe(int[,] vg, int sp, int[] sm)
        {
            int x;
            do
            {
                Console.WriteLine("Spieler: " + sp);
                Console.Write("Spalte:\t");
                Int32.TryParse(Console.ReadLine(), out x);
            } while (x < 1 || x > 8 || sm[x-1] == -1 || vg[x - 1, sm[x-1]] != 0);

            vg[x - 1, sm[x-1]] = sp;
            sm[x-1]--;
        }
        static void Ausgabe(int[,] vg)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("   1    2    3    4    5    6    7   ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            for (int y = 0; y < 6; y++) //Zeilen in Y
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                for (int x = 0; x < 7; x++) //Spalten in X
                {
                    //Console.Write(ttt[x,y] + " ");
                    switch (vg[x, y])
                    {
                        case 1:
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("   ");
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case 2:
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("   ");
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        default:
                            Console.Write("   ");
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                    }
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine("                                     "); //unterer Rahmen
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine();
            Console.WriteLine();

        }       
        static int GewinnenWaagrecht(int[,] vg)
        {
            
            for (int y = 0; y < 6; y++) // 6 Zeilen müssen überprüft werden; y = Zeile            
                for(int x = 0; x <= 3; x++) // es gibt pro Zeile 4 "Vierer"; x = Spalte                
                    if (vg[x, y] != 0)
                        if (vg[x+1, y] == vg[x, y])
                            if (vg[x+2, y] == vg[x+1, y])
                                if (vg[x+3, y] == vg[x+2, y])
                                    return vg[x, y];                               
            
            return 0; //falls noch niemand 4 in einer Zeile hat
        }
        static int GewinnenSenkrecht(int[,] vg)
        {
            
            for (int x = 0; x < 7; x++) // 7 Spalten müssen überprüft werden; x = Spalte            
                for (int y = 0; y <= 2; y++) // es gibt pro Spalte 3 "Vierer", y = Zeile                 
                    if (vg[x, y] != 0)
                        if (vg[x, y + 1] == vg[x, y])
                            if (vg[x, y + 2] == vg[x, y + 1])
                                if (vg[x, y + 3] == vg[x, y + 2])
                                    return vg[x, y];                
            
            return 0; //falls noch niemand 4 in einer Spalte hat
        }
        static int GewinnerDiagonal(int[,] vg)
        {
            // es gibt 12 Möglichkeiten eine Diagonale in eine Richtung zu "vierern" :)
            for(int x = 0; x < 4; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    if (vg[x, y] != 0) //von links oben nach rechts unten
                        if (vg[x + 1, y + 1] == vg[x, y])
                            if (vg[x + 2, y + 2] == vg[x + 1, y + 1])
                                if (vg[x + 3, y + 3] == vg[x + 2, y + 2])
                                    return vg[x, y];
                    if (vg[x + 3, y] != 0) //von rechts ober nach links unten
                        if (vg[x + 2, y + 1] == vg[x + 3, y])
                            if (vg[x + 1, y + 2] == vg[x + 2, y + 1])
                                if (vg[x, y + 3] == vg[x + 1, y + 2])
                                    return vg[x + 3, y];
                }
            } 
            return 0; //falls noch niemand 4 bei irgendeiner Diagonalen hat
        }
    }    
}

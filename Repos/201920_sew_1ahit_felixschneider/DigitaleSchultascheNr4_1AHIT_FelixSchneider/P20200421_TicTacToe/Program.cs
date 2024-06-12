using System;

namespace P20200421_TicTacToe
{
    class Program
    {
        const int size = 3;
        static void Main(string[] args)
        {
            int[,] ttt = new int[size, size];
            int spieler = 1;
            int g = 0; //Gewinner
            int runden = 9;
            Ausgabe(ttt);
            while (runden > 0)
            {
                runden--;
                Eingabe(ttt, spieler);
                Console.Clear();
                Ausgabe(ttt);

                g = GewinnenWaagrecht(ttt);
                if (g != 0)
                    break;
                g = GewinnenSenkrecht(ttt);
                if (g != 0)
                    break;
                g = GewinnerDiagonal(ttt);
                if (g != 0)
                    break;

                spieler = spieler == 1 ? 2 : 1;
                
            }
            Console.BackgroundColor = ConsoleColor.Black;
            if (g==0)
                Console.WriteLine("Unentschieden");
            else
            {
                if (g == 1)
                    Console.WriteLine("Gewinner x");
                else
                    Console.WriteLine("Gewinner o");
            }
                
            
                    
        }
        static void Eingabe(int[,] ttt, int spieler)
        {
            int x, y;
            do
            {
                Console.WriteLine("Spieler: " + spieler);
                Console.Write("Zeile:\t");
                Int32.TryParse(Console.ReadLine(), out y);
                Console.Write("Spalte:\t");
                Int32.TryParse(Console.ReadLine(), out x);
            } while (x < 1 || y < 1 || x > size || y > size || ttt[x - 1, y - 1] != 0); //Eingabe frei ?

            ttt[x - 1, y - 1] = spieler;
            
        }
        static void Ausgabe(int[,] ttt)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("   1    2    3   ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            for (int y = 0; y < size; y++) //Zeilen in Y
            {               
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write((y+1)+" ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;                              
                for (int x = 0; x < size; x++) //Spalten in X
                {
                    //Console.Write(ttt[x,y] + " ");
                    switch (ttt[x, y])
                    {
                        case 1: 
                            Console.Write(" x ");
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black; 
                            break;
                        case 2: Console.Write(" o ");
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        default: Console.Write("   ");
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                    }
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine("                 "); //unterer Rahmen
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine();
            Console.WriteLine();
            
        }

        // Methode, die überprüft, ob ein Spieler waagrecht gewonnen hat
        // liefert 1, wenn Spieler 1 gewonnen hat
        // liefert 2, wenn Spieler 2 gewonnen hat
        // liefert 0, wenn keiner gewonnen hat
        // Unentschieden nach 9 Runden wird NICHT gemacht
        static int GewinnenWaagrecht(int[,] ttt)
        {
            // 3 Zeilen müssen überprüft werden
            for(int y = 0; y <= 2; y++)     //Zeile ist y-Koordinate
                if (ttt[0, y] != 0)
                    if (ttt[1, y] == ttt[0, y])
                        if (ttt[2, y] == ttt[1, y])
                            return ttt[0, y];
            //wenn bisher niemand gewonnen hat
            return 0;
        }
        
        //Methode, die überprüft, ob ein Spieler senkrecht gewonnen hat

        static int GewinnenSenkrecht(int[,] ttt)
        {
            // 3 Spalten müssen überprüft werden
            for (int x = 0; x <= 2; x++)     //Spalte ist x-Koordinate
                if (ttt[x, 0] != 0)
                    if (ttt[x, 1] == ttt[x, 0])
                        if (ttt[x, 2] == ttt[x, 1])
                            return ttt[x, 0];
            //wenn bisher niemand gewonnen hat
            return 0;
        }
        //Methode, die überprüft, ob ein Spieler diagonal gewonnen hat
        static int GewinnerDiagonal(int[,] ttt)
        {
            //überprüft Diagonale von oben links nach unten rechts
            if (ttt[0, 0] != 0)
                if (ttt[1, 1] == ttt[0, 0])
                    if (ttt[2, 2] == ttt[1, 1])
                        return ttt[0, 0];
            //überprüft Diagonale von oben rechts nach unten links
            if (ttt[2, 0] != 0)
                if (ttt[1, 1] == ttt[2, 0])
                    if (ttt[0, 2] == ttt[1, 1])
                        return ttt[2, 0];
            return 0;
        }
    }



}

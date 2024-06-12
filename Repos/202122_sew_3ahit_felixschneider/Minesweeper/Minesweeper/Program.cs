using System;
using libminesweeper;

namespace Minesweeper
{
    class Program
    {
        public static int SIZE = 12;

        static void Main(string[] args)
        {
            if (SIZE > 26)
                SIZE = 26;
            libminesweeper.Minesweeper m = new libminesweeper.Minesweeper(SIZE, SIZE, SIZE * 2);
            Console.ForegroundColor = ConsoleColor.White;
            if (!Menu(m))
                Console.WriteLine("Bye!");
        }

        static bool Menu(libminesweeper.Minesweeper m)
        {
            bool stop = false;
            do
            {
                Console.Clear();
                Console.Write($"MINESWEEPER: Size:  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{SIZE}x{SIZE} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Bombs: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{SIZE * 2}");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Wollen Sie ein Feld auswählen (P), neu starten (X) oder das Spiel beenden (E)?");
                // Panel, Xtreme Restart (nonsense), Exit 
                string menu_input = Console.ReadLine();
                menu_input = menu_input.ToUpper();

                switch (menu_input)
                {
                    case "P": Panel(m); break;
                    case "X": m.Reset(); Console.Clear(); Menu(m); break;
                    case "E": stop = true; break;
                    default: Console.WriteLine("Ungültige Eingabe! Versuche es nochmal!"); break;
                }
            } while (!stop);
            return false;
        } // Menu (anfangs)

        static bool Panel(libminesweeper.Minesweeper m)
        {
            while(true)
            {
                try
                {
                    Console.WriteLine("Welches Feld wollen Sie auswählen? (Zahl, Enter, Buchstabe, Enter)");
                    int posxzahl = Convert.ToInt32(Console.ReadLine()) - 1;
                    char posychar = Convert.ToChar(Console.ReadLine().ToLower());

                    string panel_action = "R";
                    if (m.GetField != null)
                    {
                        Console.WriteLine("Soll das Feld aufgedeckt oder geflagt werden? (R/F) \nOder drücke E um zurückzukehren!");
                        //Reveal, Flag, Exit
                        panel_action = Console.ReadLine().ToUpper();
                    }

                    int posyzahl = -1;
                    switch (posychar)
                    {
                        case 'a': posyzahl = 0; break;
                        case 'b': posyzahl = 1; break;
                        case 'c': posyzahl = 2; break;
                        case 'd': posyzahl = 3; break;
                        case 'e': posyzahl = 4; break;
                        case 'f': posyzahl = 5; break;
                        case 'g': posyzahl = 6; break;
                        case 'h': posyzahl = 7; break;
                        case 'i': posyzahl = 8; break;
                        case 'j': posyzahl = 9; break;
                        case 'k': posyzahl = 10; break;
                        case 'l': posyzahl = 11; break;
                        case 'm': posyzahl = 12; break;
                        case 'n': posyzahl = 13; break;
                        case 'o': posyzahl = 14; break;
                        case 'p': posyzahl = 15; break;
                        case 'q': posyzahl = 16; break;
                        case 'r': posyzahl = 17; break;
                        case 's': posyzahl = 18; break;
                        case 't': posyzahl = 19; break;
                        case 'u': posyzahl = 20; break;
                        case 'v': posyzahl = 21; break;
                        case 'w': posyzahl = 22; break;
                        case 'x': posyzahl = 23; break;
                        case 'y': posyzahl = 24; break;
                        case 'z': posyzahl = 25; break;
                        default: throw new Exception("bruh");
                    }

                    switch (panel_action)
                    {
                        case "R": 
                            EPlayStatus status = m.Play(posxzahl, posyzahl, EAction.OPEN); 
                            if(status == EPlayStatus.WIN)
                            {
                                Console.Clear();
                                GenerateField(m.GetField);
                                Console.WriteLine("--------------------------------\n|           YOU WON!           |\n--------------------------------");
                                Console.ReadLine();
                                m.Reset();
                                return true;
                            }
                            else if(status == EPlayStatus.LOSE)
                            {
                                Console.Clear();
                                GenerateField(m.GetField);
                                Console.WriteLine("--------------------------------\n|           YOU LOST           |\n--------------------------------");
                                Console.ReadLine();
                                m.Reset();
                                return true;
                            }
                            Console.Clear(); 
                            GenerateField(m.GetField); 
                            break;
                        case "F": m.Play(posxzahl, posyzahl, EAction.FLAG); Console.Clear(); GenerateField(m.GetField); break;
                        case "E": return true;
                        default: Console.WriteLine("Ungültige Eingabe! Versuche es nochmal!"); break;
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong input!");
                }                
            }
        } //eigentliches Spiel

        static void GenerateField(EField[,] Feld)
        {

            Console.SetCursorPosition(0, 0);


            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            for (int i = 0; i < SIZE + 1; i++)
            {
                if (i == 0)
                {
                    Console.Write("  ");
                }
                else
                {
                    if (i >= 10)
                    {
                        Console.Write(" " + (i));
                    }
                    else
                    {
                        Console.Write(" " + (i) + " ");
                    }

                }
            }

            Console.WriteLine();
            for (int i = 0; i < SIZE; i++)
            {

                Console.Write(alphabet[i] + " ");
                Console.ForegroundColor = ConsoleColor.Black;
                for (int j = 0; j < SIZE; j++)
                {
                    if(Feld == null)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray; 
                        Console.Write("| |");
                    }                        
                    else
                    switch (Feld[i, j])
                    {
                        case EField.BOMB: 
                        case EField.ZERO: 
                        case EField.ONE: 
                        case EField.TWO: 
                        case EField.THREE: 
                        case EField.FOUR: 
                        case EField.FIVE: 
                        case EField.SIX: 
                        case EField.SEVEN: 
                        case EField.EIGHT: Console.BackgroundColor = ConsoleColor.Gray; Console.Write("| |"); break;
                        case EField.BOMBFLAG: 
                        case EField.ZEROFLAG: 
                        case EField.ONEFLAG: 
                        case EField.TWOFLAG: 
                        case EField.THREEFLAG: 
                        case EField.FOURFLAG: 
                        case EField.FIVEFLAG: 
                        case EField.SIXFLAG: 
                        case EField.SEVENFLAG: 
                        case EField.EIGHTFLAG: Console.BackgroundColor = ConsoleColor.Blue; Console.Write("|F|"); break;
                        case EField.BOMBACTIVATED: Console.BackgroundColor = ConsoleColor.Red; Console.Write("|*|"); break;
                        case EField.ZEROACTIVATED: Console.BackgroundColor = ConsoleColor.White; Console.Write("|0|"); break;
                        case EField.ONEACTIVATED: Console.BackgroundColor = ConsoleColor.White; Console.Write("|1|"); break;
                        case EField.TWOACTIVATED: Console.BackgroundColor = ConsoleColor.White; Console.Write("|2|"); break;
                        case EField.THREEACTIVATED: Console.BackgroundColor = ConsoleColor.White; Console.Write("|3|"); break;
                        case EField.FOURACTIVATED: Console.BackgroundColor = ConsoleColor.White; Console.Write("|4|"); break;
                        case EField.FIVEACTIVATED: Console.BackgroundColor = ConsoleColor.White; Console.Write("|5|"); break;
                        case EField.SIXACTIVATED: Console.BackgroundColor = ConsoleColor.White; Console.Write("|6|"); break;
                        case EField.SEVENACTIVATED: Console.BackgroundColor = ConsoleColor.White; Console.Write("|7|"); break;
                        case EField.EIGHTACTIVATED: Console.BackgroundColor = ConsoleColor.White; Console.Write("|8|"); break;
                        default:  break;
                    }

                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }

        } // Feld im View ausgeben
    }


}

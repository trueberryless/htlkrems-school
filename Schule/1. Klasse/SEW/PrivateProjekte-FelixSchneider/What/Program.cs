using System;

namespace What
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Treffen Sie eine Wahl:\n\n";
            message += "(N) - Neues Spiel\n";
            message += "(A) - Altes Spiel fortsetzen\n";
            message += "(E) - Beenden\n";
            Console.WriteLine(message);
            Console.Write("Ihre Wahl lautet: ");
            string choice = Console.ReadLine();
            if (choice == "N")
            {
                Console.Write("Neues Spiel...");

                // Anweisungen, die ein neues Spiel starten

            }
            else if (choice == "A")
            {
                Console.Write("Altes Spiel laden ...");

                // Anweisungen, die einen alten Spielstand laden

            }
            else if (choice == "E")
            {
                Console.Write("Spiel beenden ...");

                // Anweisungen, um das Spiel zu beenden

            }
            else
            {
                Console.Write("Ungültige Eingabe ...");

                // weitere Anweisungen

            }
            Console.ReadLine();
        }
    }
    
}

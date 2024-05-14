using System;

namespace P20200128_CaeserVerschluesselung
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Wollen Sie verschlüsseln (ver) oder entschlüsseln (ent)");
                string op = Console.ReadLine().ToLower();
                if(op == "ver")
                {
                    Console.WriteLine("Geben Sie ein beliebiges Wort ein:\t\t\t");
                    string text = Console.ReadLine().ToUpper();
                    Console.WriteLine("Wieviele Stellen wollen Sie verschieben?\t\t\t");
                    int verschiebung = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(Verschlüsseln(text.ToUpper(), verschiebung));
                }
                if(op == "ent")
                {
                    Console.WriteLine("Geben Sie den zu entschlüsselnden Code ein:\t\t\t");
                    string text = Console.ReadLine().ToUpper();
                    Console.WriteLine("Wieviele Stellen wollen Sie verschieben?\t\t\t");
                    int verschiebung = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(Entschlüsseln(text.ToUpper(), verschiebung));
                }
                
            }       
            
        }
        static string Verschlüsseln(string txt, int wieviel)
        {            
            string v = "";
            for (int i = 0; i < txt.Length; i++)//ganzes Wort durchgehen
            {
                //mehrfacher überlauf möglich
                wieviel = wieviel % 26;
                //buchstabe = erster buchstabe des wortes //buchstaben ermitteln
                char buchstabe = txt[i]; 
                //zahl aus buchstaben machen
                int j = buchstabe;
                //zahl erhöhen um wieviel                
                if (buchstabe != ' ')
                    j = j + wieviel;
                if (j > 90)
                    j -= 26;
                //zahl in buchstaben zurückverwandeln
                buchstabe = (char)j;
                //buchstaben ausgeben
                Console.Write(buchstabe);                
            }
            return v;
        }
        static string Entschlüsseln(string txt, int wieviel)
        {
            string v = "";
            for (int i = 0; i < txt.Length; i++)//ganzes Wort durchgehen
            {                
                //mehrfacher überlauf möglich
                wieviel = wieviel % 26;
                //buchstabe = erster buchstabe des wortes //buchstaben ermitteln
                char buchstabe = txt[i];
                //zahl aus buchstaben machen
                int j = buchstabe;
                //zahl erhöhen um wieviel
                if (buchstabe != ' ')
                {
                    j = j - wieviel;
                    if (j < 65)
                        j += 26;
                }
                //zahl in buchstaben zurückverwandeln
                buchstabe = (char)j;
                //buchstaben ausgeben
                Console.Write(buchstabe);
            }
            return v;
        }
    }
}

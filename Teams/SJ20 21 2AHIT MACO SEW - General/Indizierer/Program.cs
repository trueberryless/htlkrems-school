using System;

namespace _2ahitIndizierer
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("Matthias", "Höllerer");
            Player p2 = new Player("Michael", "Jordan");

            Player[] team = new Player[10];
            team[0] = p1;
            team[1] = p2;

            Team t = new Team(10);
            t[0] = p1;
            t[1] = p2;

            Console.WriteLine(t[44]);
            Console.WriteLine(t[1]);
        }
    }
}

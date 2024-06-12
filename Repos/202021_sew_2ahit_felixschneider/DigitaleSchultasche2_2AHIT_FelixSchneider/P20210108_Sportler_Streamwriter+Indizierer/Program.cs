using System;

namespace P20210108_Sportler_Streamwriter_Indizierer
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("Matthias", "Höllerer");
            Player p2 = new Player("Michael", "Jordan");

            Team t = new Team(10);

            t.Load("team.txt");

            //t[0] = p1;
            //t[1] = p2;

            t.Save("team.txt");
        }
    }
}

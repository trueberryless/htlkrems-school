using System;
using System.Collections.Generic;

namespace _20200528_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> marks = new Dictionary<int, string>();

            marks.Add(1, "Sehr gut");
            marks.Add(2, "Gut");
            marks.Add(3, "Befriedigend");
            marks.Add(4, "Genügend");
            marks.Add(5, "Nicht genügend");

            marks[6] = "Geht das?";
            marks[42] = "Das ist die Antwort auf alle Fragen!";
            marks[99] = null;

            Dictionary<string, int> reversedMarks = new Dictionary<string, int>();

            reversedMarks.Add("Sehr gut", 1);
            reversedMarks.Add("Gut", 2);
            reversedMarks.Add("Befriedigend", 3);
            reversedMarks.Add("Genügend", 4);
            reversedMarks.Add("Nicht genügend", 5);

            Console.WriteLine(marks[3]); //Befriedigend
            Console.WriteLine(marks[42]);
            Console.WriteLine(reversedMarks["Sehr gut"]);

            //for (int i = 0; i < marks.Count; i++)
            //{
            //sinnlos!!!
            //}

            foreach (KeyValuePair<int, string> item in marks)
            {
                Console.WriteLine(item.Key + " / " + item.Value);
            }

            Dictionary<string, string> DE = new Dictionary<string, string>();

            DE.Add("Haus", "house");
            DE.Add("Maus", "mouse");
            DE.Add("Ball", "ball");
            DE.Add("Noten", "marks");
            DE.Add("Toll", "nice");
            DE.Add("Fertig", "ready");

            Dictionary<string, string> ED = new Dictionary<string, string>();

            ED.Add("house", "Haus");
            ED.Add("mouse", "Maus");
            ED.Add("ball", "Ball");
            ED.Add("marks", "Noten");
            ED.Add("nice", "Toll");
            ED.Add("ready", "Fertig");
            //ED.Add("ready", "Bereit"); //geht nicht, weil bereits vorhanden
                        
            Console.WriteLine(DE["Haus"]); //house
            if (ED.ContainsKey("ready")) //                                     WICHTIG
                Console.WriteLine(ED["ready"]);

            ED["ready"] = "brutal"; //überschreiben ist brutal
        }
    }
}

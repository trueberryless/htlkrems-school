using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace P20210108_Sportler_Streamwriter_Indizierer
{
    class Player
    {
        string firstName, lastName;

        public Player(string f, string l)
        {
            firstName = f;
            lastName = l;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
    class Team
    {
        Player[] myPlayers;

        public Team(int size)
        {
            myPlayers = new Player[size];
        }

        // Indizierer (Indexer)
        // quasi get/set für Arrays
        public Player this[int idx]
        {
            get
            {
                if (idx <= myPlayers.Length && idx >= 0)
                    return myPlayers[idx];
                else
                    throw new Exception("Team doesn't have so many members!");
            }
            set
            {
                if (idx <= myPlayers.Length && idx >= 0)
                    myPlayers[idx] = value;
                else
                    throw new Exception("Player doesn't fit into team!");
            }
        }

        public void Save(string filename)
        {
            using(StreamWriter sw = new StreamWriter(filename))
            {
                for (int i = 0; i < myPlayers.Length; i++)
                {
                    sw.WriteLine(myPlayers[i]);
                    sw.Flush();
                }
            }
        }

        public void Load(string filename)
        {
            int i = 0;
            using (StreamReader sr = new StreamReader(filename))
            {
                while (sr.Peek() != -1) //EndofFile (EoF)
                {
                    string line = sr.ReadLine();
                    if(line != " ") //Leerzeile
                    {
                        string[] elements = line.Split(' ');
                        myPlayers[i] = new Player(elements[0], elements[1]);
                    }
                    
                }
            }
        }
    }
}
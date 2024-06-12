using System;
using System.Collections.Generic;
using System.Text;

namespace P20210108_Indizierer
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
            get {
                if (idx <= myPlayers.Length && idx >= 0)
                    return myPlayers[idx];
                else
                    throw new Exception("Team doesn't have so many members!");
            }
            set {
                if (idx <= myPlayers.Length && idx >= 0)
                    myPlayers[idx] = value;
                else
                    throw new Exception("Player doesn't fit into team!");
            }
        }


        //evtl weitere Methoden, die nicht im Main sein sollen
    }
}

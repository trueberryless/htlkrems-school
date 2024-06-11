using System;
using System.Collections.Generic;
using System.Text;

namespace _2ahitIndizierer
{
    class Player { 
        string firstName, lastName;
        public Player(string f, string l)
        {
            this.firstName = f;
            this.lastName = l;
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
                //prüfen, ob idx im richtigen Bereich ist
                if (idx < myPlayers.Length && idx >= 0)
                    return myPlayers[idx];
                else
                    throw new Exception("Team does not have so many members");
            }
            set {
                if (idx < myPlayers.Length && idx >= 0)
                    myPlayers[idx] = value;
                else
                    throw new Exception("Player does not fit into Team");
            }
        }

        //evtl weitere Methoden, die nicht im Main sein sollenby
    }
}

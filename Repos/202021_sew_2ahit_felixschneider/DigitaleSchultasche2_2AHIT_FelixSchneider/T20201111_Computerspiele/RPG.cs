using System;
using System.Collections.Generic;
using System.Text;

namespace T20201111_Computerspiele
{
    class RPG:Computerspiel
    {
        public override void Print()
        {
            Console.WriteLine("Es handelt sich um ein RPG Computerspiel.");
        }

        public override string ToString()
        {
            return "Es handelt sich um ein RPG Computerspiel.";
        }
    }
}
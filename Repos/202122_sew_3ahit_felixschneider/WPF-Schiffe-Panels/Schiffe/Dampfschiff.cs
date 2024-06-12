using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffe
{
    public class Dampfschiff : ASchiff
    {
        public int CO2Ausstoss { get; set; }
        public int Passagiere { get; set; }

        public Dampfschiff() : base() { }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Dieses Schiff stößt {CO2Ausstoss}CCF pro Jahr aus und trägt {Passagiere} Passagiere.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{CO2Ausstoss};{Passagiere}");
        }
    }
}

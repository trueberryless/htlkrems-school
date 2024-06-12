using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffe
{
    public class Fischereischiff : ASchiff
    {
        public int Netzgroesse { get; set; }
        public int Fischlagerkapazitaet { get; set; }

        public Fischereischiff() : base() { }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Außerdem hat es ein Netz mit einer FLäche von {Netzgroesse}m² und es kann bis zu {Fischlagerkapazitaet} Fische lagern.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{Netzgroesse};{Fischlagerkapazitaet}");
        }
    }
}

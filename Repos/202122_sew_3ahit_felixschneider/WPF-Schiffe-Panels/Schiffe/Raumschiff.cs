using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffe
{
    public class Raumschiff : ASchiff
    {
        public int MaxGeschwindigkeit { get; set; }
        public int AnzahlLaserkanonen { get; set; }
        public int AnzahlFluegel { get; set; }

        public Raumschiff() : base() { }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Dieses Raumschiff kann maximal mit {MaxGeschwindigkeit}m/s fliegen, hat {AnzahlFluegel} Flügel und {AnzahlLaserkanonen} Laserkanonen.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{MaxGeschwindigkeit};{AnzahlLaserkanonen};{AnzahlFluegel}");
        }
    }
}

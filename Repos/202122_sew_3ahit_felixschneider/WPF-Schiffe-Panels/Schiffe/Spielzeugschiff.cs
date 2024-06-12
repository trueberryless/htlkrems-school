using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Schiffe
{
    public enum Farbe { undefined, Blau, Gruen, Gelb, Rot, Rosa, Violet, Orange, Braun }
    public enum Marke { undefined, Hotweels, LEGO, Playmobil, Hasbro, Mattel, Simba, Fuehrer }

    public class Spielzeugschiff : ASchiff
    {
        public Farbe Farbe { get; set; }
        public Marke Marke { get; set; }

        public Spielzeugschiff() : base() { }

        public override string ToString()
        {
            return String.Format($"Das Schiff {Name} ist {Laenge}cm lang und wurde {Baujahr} erbaut. Außerdem ist das Spielzeug {Farbe} und produziert von {Marke}.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{Farbe};{Marke}");
        }
    }
}

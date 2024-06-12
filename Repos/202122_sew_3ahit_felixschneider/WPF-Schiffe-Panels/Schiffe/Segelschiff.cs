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
    public enum Segelmaterial { undefined, Gewebe, Laminat, Polyester, SolidStripes, Carbon, Aramid, Pentex, Vectran, Nylon }

    public class Segelschiff : ASchiff
    {
        public int Segelhoehe { get; set; }
        public Segelmaterial Segelmaterial { get; set; }

        public Segelschiff() : base() { }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Außerdem hat es {Segelhoehe}m Segelhöhe und das Segel besteht aus {Segelmaterial}.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{Segelhoehe};{Segelmaterial}");
        }
    }
}

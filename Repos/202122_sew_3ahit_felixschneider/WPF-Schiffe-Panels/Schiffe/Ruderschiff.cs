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
    public enum Flagge { undefined, Deutschland, Norwegen, England, Spanien, Russland, USA, China, Japan }
    public class Ruderschiff : ASchiff
    {
        public int Ruderanzahl { get; set; }
        public Flagge Flagge { get; set; }

        public Ruderschiff() : base() { }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Außerdem hat es {Ruderanzahl} Ruder und es hat die {Flagge}-Flagge.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{Ruderanzahl};{Flagge}");
        }
    }
}

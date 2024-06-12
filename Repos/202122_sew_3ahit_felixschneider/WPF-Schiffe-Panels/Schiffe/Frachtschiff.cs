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
    public enum Hafen { undefined, Rotterdam, NewYork, LosAngeles, Hongkong, Tianjin, Busan, Qingdao, Shenzhen, Singapur, Shanghai }

    public class Frachtschiff : ASchiff
    {
        public Hafen RouteVon { get; set; }
        public Hafen RouteNach { get; set; }

        public Frachtschiff() : base() { }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Es fährt von {RouteVon} nach {RouteNach}.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{RouteVon};{RouteNach}");
        }
    }
}

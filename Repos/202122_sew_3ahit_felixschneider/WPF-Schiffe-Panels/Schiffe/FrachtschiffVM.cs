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
    public class FrachtschiffVM : ASchiffVM<Frachtschiff>
    {
        public FrachtschiffVM() : base(new Frachtschiff()) { }

        public Hafen RouteVon
        {
            get { return Schiff.RouteVon; }
            set { 
                if (Schiff.RouteVon != value)
                {
                    Schiff.RouteVon = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Hafen RouteNach
        {
            get { return Schiff.RouteNach; }
            set { 
                if (Schiff.RouteNach != value)
                {
                    Schiff.RouteNach = value;
                    this.OnPropertyChanged();
                }

            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Es fährt von {RouteVon} nach {RouteNach}.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{RouteVon};{RouteNach}");
        }
        static public void AddToFile(Frachtschiff schiff)
        {
            using (StreamWriter sw = new StreamWriter("frachtschiffe.csv", true))
            {
                sw.WriteLine(schiff.ToCSV());
            }
        }

        static public bool DeleteToFile(FrachtschiffVM schiff)
        {
            bool return_value = false;
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader("frachtschiffe.csv"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line != schiff.ToCSV() || return_value == true)
                        sw.WriteLine(line);
                    else return_value = true;
                }
            }

            File.Delete("frachtschiffe.csv");
            File.Move(tempFile, "frachtschiffe.csv");

            return return_value;
        }

        static public List<FrachtschiffVM> FromFile()
        {
            List<FrachtschiffVM> frachtschiffe = new List<FrachtschiffVM>();
            try
            {
                using (StreamReader sr = new StreamReader("frachtschiffe.csv"))
                {
                    while (sr.Peek() != -1)
                    {
                        string? inhalt = sr.ReadLine();
                        if (inhalt != null)
                        {
                            string[] schiff = inhalt.Split(';');
                            frachtschiffe.Add(new FrachtschiffVM()
                            {
                                Name = schiff[0],
                                Laenge = Int32.Parse(schiff[1]),
                                Baujahr = DateTime.Parse(schiff[2]),
                                RouteVon = (Hafen)Enum.Parse(typeof(Hafen), schiff[3]),
                                RouteNach = (Hafen)Enum.Parse(typeof(Hafen), schiff[4])
                            });
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                using (StreamWriter sw = new StreamWriter("frachtschiffe.csv", true))
                {
                    sw.Write("");
                }
            }
            return frachtschiffe;
        }
    }

    public class EnumIntConverterHafen : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Hafen e = (Hafen)value;
            return System.Convert.ToInt32(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Hafen)System.Convert.ToInt32(value);
        }
    }
}

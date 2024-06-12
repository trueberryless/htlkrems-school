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

    public class SpielzeugschiffVM : ASchiffVM<Spielzeugschiff>
    {
        public SpielzeugschiffVM() : base(new Spielzeugschiff()) { }

        public Farbe Farbe
        {
            get { return Schiff.Farbe; }
            set {
                if (Schiff.Farbe != value)
                {
                    Schiff.Farbe = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Marke Marke
        {
            get { return Schiff.Marke; }
            set {
                if (Schiff.Marke != value)
                {
                    Schiff.Marke = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public override string ToString()
        {
            return String.Format($"Das Schiff {Name} ist {Laenge}cm lang und wurde {Baujahr} erbaut. Außerdem ist das Spielzeug {Farbe} und produziert von {Marke}.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{Farbe};{Marke}");
        }

        static public void AddToFile(Spielzeugschiff schiff)
        {
            using (StreamWriter sw = new StreamWriter("spielzeugschiffe.csv", true))
            {
                sw.WriteLine(schiff.ToCSV());
            }
        }

        static public bool DeleteToFile(SpielzeugschiffVM schiff)
        {
            bool return_value = false;
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader("spielzeugschiffe.csv"))
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

            File.Delete("spielzeugschiffe.csv");
            File.Move(tempFile, "spielzeugschiffe.csv");

            return return_value;
        }

        static public List<SpielzeugschiffVM> FromFile()
        {
            List<SpielzeugschiffVM> spielzeugschiffe = new List<SpielzeugschiffVM>();
            try
            {
                using (StreamReader sr = new StreamReader("spielzeugschiffe.csv"))
                {
                    while (sr.Peek() != -1)
                    {
                        string? inhalt = sr.ReadLine();
                        if (inhalt != null)
                        {
                            string[] schiff = inhalt.Split(';');
                            spielzeugschiffe.Add(new SpielzeugschiffVM()
                            {
                                Name = schiff[0],
                                Laenge = Int32.Parse(schiff[1]),
                                Baujahr = DateTime.Parse(schiff[2]),
                                Farbe = (Farbe)Enum.Parse(typeof(Farbe), schiff[3]),
                                Marke = (Marke)Enum.Parse(typeof(Marke), schiff[4])
                            });
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                using (StreamWriter sw = new StreamWriter("spielzeugschiffe.csv", true))
                {
                    sw.Write("");
                }
            }
            return spielzeugschiffe;
        }
    }

    public class EnumIntConverterFarbe : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Farbe e = (Farbe)value;
            return System.Convert.ToInt32(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Farbe)System.Convert.ToInt32(value);
        }
    }

    public class EnumIntConverterMarke : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Marke e = (Marke)value;
            return System.Convert.ToInt32(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Marke)System.Convert.ToInt32(value);
        }
    }
}

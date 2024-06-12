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
    public class RuderschiffVM : ASchiffVM<Ruderschiff>
    {
        public RuderschiffVM() : base(new Ruderschiff()) { }

        public int Ruderanzahl
        {
            get { return Schiff.Ruderanzahl; }
            set { 
                if (Schiff.Ruderanzahl != value)
                {
                    Schiff.Ruderanzahl = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Flagge Flagge
        {
            get { return Schiff.Flagge; }
            set {
                if (Schiff.Flagge != value)
                {
                    Schiff.Flagge = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Außerdem hat es {Ruderanzahl} Ruder und es hat die {Flagge}-Flagge.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{Ruderanzahl};{Flagge}");
        }
        static public void AddToFile(Ruderschiff schiff)
        {
            using (StreamWriter sw = new StreamWriter("ruderschiffe.csv", true))
            {
                sw.WriteLine(schiff.ToCSV());
            }
        }

        static public bool DeleteToFile(RuderschiffVM schiff)
        {
            bool return_value = false;
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader("ruderschiffe.csv"))
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

            File.Delete("ruderschiffe.csv");
            File.Move(tempFile, "ruderschiffe.csv");

            return return_value;
        }

        static public List<RuderschiffVM> FromFile()
        {
            List<RuderschiffVM> ruderschiffe = new List<RuderschiffVM>();
            try
            {
                using (StreamReader sr = new StreamReader("ruderschiffe.csv"))
                {
                    while (sr.Peek() != -1)
                    {
                        string? inhalt = sr.ReadLine();
                        if (inhalt != null)
                        {
                            string[] schiff = inhalt.Split(';');
                            ruderschiffe.Add(new RuderschiffVM()
                            {
                                Name = schiff[0],
                                Laenge = Int32.Parse(schiff[1]),
                                Baujahr = DateTime.Parse(schiff[2]),
                                Ruderanzahl = Int32.Parse(schiff[3]),
                                Flagge = (Flagge)Enum.Parse(typeof(Flagge), schiff[4])
                            });
                        }
                    }
                }
            }            
            catch (FileNotFoundException ex)
            {
                using (StreamWriter sw = new StreamWriter("ruderschiffe.csv", true))
                {
                    sw.Write("");
                }
            }
            return ruderschiffe;
        }
    }

    public class EnumIntConverterFlagge : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Flagge e = (Flagge)value;
            return System.Convert.ToInt32(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Flagge)System.Convert.ToInt32(value);
        }
    }
}

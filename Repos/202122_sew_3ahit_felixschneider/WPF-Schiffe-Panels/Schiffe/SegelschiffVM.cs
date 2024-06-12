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

    public class SegelschiffVM : ASchiffVM<Segelschiff>
    {
        public SegelschiffVM() : base(new Segelschiff()) { }

        public int Segelhoehe
        {
            get { return Schiff.Segelhoehe; }
            set { 
                if (Schiff.Segelhoehe != value)
                {
                    Schiff.Segelhoehe = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Segelmaterial Segelmaterial
        {
            get { return Schiff.Segelmaterial; }
            set { 
                if (Schiff.Segelmaterial != value)
                {
                    Schiff.Segelmaterial = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Außerdem hat es {Segelhoehe}m Segelhöhe und das Segel besteht aus {Segelmaterial}.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{Segelhoehe};{Segelmaterial}");
        }
        static public void AddToFile(Segelschiff schiff)
        {
            using (StreamWriter sw = new StreamWriter("segelschiffe.csv", true))
            {
                sw.WriteLine(schiff.ToCSV());
            }
        }

        static public bool DeleteToFile(SegelschiffVM schiff)
        {
            bool return_value = false;
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader("segelschiffe.csv"))
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

            File.Delete("segelschiffe.csv");
            File.Move(tempFile, "segelschiffe.csv");

            return return_value;
        }

        static public List<SegelschiffVM> FromFile()
        {
            List<SegelschiffVM> segelschiffe = new List<SegelschiffVM>();
            try
            {
                using (StreamReader sr = new StreamReader("segelschiffe.csv"))
                {
                    while (sr.Peek() != -1)
                    {
                        string? inhalt = sr.ReadLine();
                        if (inhalt != null)
                        {
                            string[] schiff = inhalt.Split(';');
                            segelschiffe.Add(new SegelschiffVM()
                            {
                                Name = schiff[0],
                                Laenge = Int32.Parse(schiff[1]),
                                Baujahr = DateTime.Parse(schiff[2]),
                                Segelhoehe = Int32.Parse(schiff[3]),
                                Segelmaterial = (Segelmaterial)Enum.Parse(typeof(Segelmaterial), schiff[4])
                            });
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                using (StreamWriter sw = new StreamWriter("segelschiffe.csv", true))
                {
                    sw.Write("");
                }
            }
            return segelschiffe;
        }
    }

    public class EnumIntConverterSegelmaterial : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Segelmaterial e = (Segelmaterial)value;
            return System.Convert.ToInt32(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Segelmaterial)System.Convert.ToInt32(value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffe
{
    public class RaumschiffVM : ASchiffVM<Raumschiff>
    {
        public RaumschiffVM() : base(new Raumschiff()) { }

        public int MaxGeschwindigkeit
        {
            get { return Schiff.MaxGeschwindigkeit; }
            set
            {
                if (Schiff.MaxGeschwindigkeit != value)
                {
                    Schiff.MaxGeschwindigkeit = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int AnzahlLaserkanonen
        {
            get { return Schiff.AnzahlLaserkanonen; }
            set
            {
                if (Schiff.AnzahlLaserkanonen != value)
                {
                    Schiff.AnzahlLaserkanonen = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int AnzahlFluegel
        {
            get { return Schiff.AnzahlFluegel; }
            set
            {
                if (Schiff.AnzahlFluegel != value)
                {
                    Schiff.AnzahlFluegel = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Dieses Raumschiff kann maximal mit {MaxGeschwindigkeit}m/s fliegen, hat {AnzahlFluegel} Flügel und {AnzahlLaserkanonen} Laserkanonen.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{MaxGeschwindigkeit};{AnzahlLaserkanonen};{AnzahlFluegel}");
        }

        static public void AddToFile(Raumschiff schiff)
        {
            using (StreamWriter sw = new StreamWriter("raumschiffe.csv", true))
            {
                sw.WriteLine(schiff.ToCSV());
            }
        }

        static public bool DeleteToFile(RaumschiffVM schiff)
        {
            bool return_value = false;

            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader("raumschiffe.csv"))
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

            File.Delete("raumschiffe.csv");
            File.Move(tempFile, "raumschiffe.csv");

            return return_value;
        }

        static public List<RaumschiffVM> FromFile()
        {
            List<RaumschiffVM> raumschiffe = new List<RaumschiffVM>();
            try
            {
                using (StreamReader sr = new StreamReader("raumschiffe.csv"))
                {
                    while (sr.Peek() != -1)
                    {
                        string? inhalt = sr.ReadLine();
                        if (inhalt != null)
                        {
                            string[] schiff = inhalt.Split(';');
                            raumschiffe.Add(new RaumschiffVM()
                            {
                                Name = schiff[0],
                                Laenge = Int32.Parse(schiff[1]),
                                Baujahr = Convert.ToDateTime(schiff[2]),
                                MaxGeschwindigkeit = Int32.Parse(schiff[3]),
                                AnzahlLaserkanonen = Int32.Parse(schiff[4]),
                                AnzahlFluegel = Int32.Parse(schiff[5])
                            });
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                using (StreamWriter sw = new StreamWriter("raumschiffe.csv", true))
                {
                    sw.Write("");
                }
            }
            return raumschiffe;
        }
    }
}

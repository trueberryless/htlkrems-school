using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffe
{
    public class FischereischiffVM : ASchiffVM<Fischereischiff>
    {
        public FischereischiffVM() : base(new Fischereischiff()) { }

        public int Netzgroesse
        {
            get { return Schiff.Netzgroesse; }
            set { 
                if (Schiff.Netzgroesse != value)
                {
                    Schiff.Netzgroesse = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int Fischlagerkapazitaet
        {
            get { return Schiff.Fischlagerkapazitaet; }
            set { 
                if (Schiff.Fischlagerkapazitaet != value)
                {
                    Schiff.Fischlagerkapazitaet = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Außerdem hat es ein Netz mit einer FLäche von {Netzgroesse}m² und es kann bis zu {Fischlagerkapazitaet} Fische lagern.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{Netzgroesse};{Fischlagerkapazitaet}");
        }
        static public void AddToFile(Fischereischiff schiff)
        {
            using (StreamWriter sw = new StreamWriter("fischereischiffe.csv", true))
            {
                sw.WriteLine(schiff.ToCSV());
            }
        }

        static public bool DeleteToFile(FischereischiffVM schiff)
        {
            bool return_value = false;
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader("fischereischiffe.csv"))
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

            File.Delete("fischereischiffe.csv");
            File.Move(tempFile, "fischereischiffe.csv");

            return return_value;
        }

        static public List<FischereischiffVM> FromFile()
        {
            List<FischereischiffVM> fischereischiffe = new List<FischereischiffVM>();
            try
            {
                using (StreamReader sr = new StreamReader("fischereischiffe.csv"))
                {
                    while (sr.Peek() != -1)
                    {
                        string? inhalt = sr.ReadLine();
                        if (inhalt != null)
                        {
                            string[] schiff = inhalt.Split(';');
                            fischereischiffe.Add(new FischereischiffVM()
                            {
                                Name = schiff[0],
                                Laenge = Int32.Parse(schiff[1]),
                                Baujahr = DateTime.Parse(schiff[2]),
                                Netzgroesse = Int32.Parse(schiff[3]),
                                Fischlagerkapazitaet = Int32.Parse(schiff[4])
                            });
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                using (StreamWriter sw = new StreamWriter("fischereischiffe.csv", true))
                {
                    sw.Write("");
                }
            }
            return fischereischiffe;
        }
    }
}

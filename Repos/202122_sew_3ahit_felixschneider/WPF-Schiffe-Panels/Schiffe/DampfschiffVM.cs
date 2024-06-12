using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffe
{
    public class DampfschiffVM : ASchiffVM<Dampfschiff>
    {
        public DampfschiffVM() : base(new Dampfschiff()) { }

        public int CO2Ausstoss
        {
            get { return Schiff.CO2Ausstoss; }
            set {
                if (Schiff.CO2Ausstoss != value)
                {
                    Schiff.CO2Ausstoss = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int Passagiere
        {
            get { return Schiff.Passagiere; }
            set {
                if (Schiff.Passagiere != value)
                {
                    Schiff.Passagiere = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format($"Dieses Schiff stößt {CO2Ausstoss}CO2 pro Meile aus und trägt {Passagiere} Passagiere.");
        }

        public override string ToCSV()
        {
            return base.ToCSV() + String.Format($";{CO2Ausstoss};{Passagiere}");
        }

        static public void AddToFile(Dampfschiff schiff)
        {
            using (StreamWriter sw = new StreamWriter("dampfschiffe.csv", true))
            {
                sw.WriteLine(schiff.ToCSV());
            }
        }

        static public bool DeleteToFile(DampfschiffVM schiff)
        {
            bool return_value = false;

            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader("dampfschiffe.csv"))
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

            File.Delete("dampfschiffe.csv");
            File.Move(tempFile, "dampfschiffe.csv");

            return return_value;
        }

        static public List<DampfschiffVM> FromFile()
        {
            List<DampfschiffVM> dampfschiffe = new List<DampfschiffVM>();
            try
            {
                using (StreamReader sr = new StreamReader("dampfschiffe.csv"))
                {
                    while (sr.Peek() != -1)
                    {
                        string? inhalt = sr.ReadLine();
                        if (inhalt != null)
                        {
                            string[] schiff = inhalt.Split(';');
                            dampfschiffe.Add(new DampfschiffVM()
                            {
                                Name = schiff[0],
                                Laenge = Int32.Parse(schiff[1]),
                                Baujahr = Convert.ToDateTime(schiff[2]),
                                CO2Ausstoss = Int32.Parse(schiff[3]),
                                Passagiere = Int32.Parse(schiff[4])
                            });
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                using (StreamWriter sw = new StreamWriter("dampfschiffe.csv", true))
                {
                    sw.Write("");
                }
            }
            return dampfschiffe;
        }
    }
}

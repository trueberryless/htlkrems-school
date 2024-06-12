using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Schiffe
{
    public abstract class ASchiffVM<M> : PropertyChangedClass where M : ASchiff
    {
        public M Schiff;

        public ASchiffVM(M schiff)
        {
            Schiff = schiff;
        }

        public string Name
        {
            get { return Schiff.Name; }
            set
            {
                if (Schiff.Name != value)
                {
                    Schiff.Name = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int Laenge
        {
            get { return Schiff.Laenge; }
            set
            {
                if (Schiff.Laenge != value)
                {
                    Schiff.Laenge = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public DateTime Baujahr
        {
            get { return Schiff.Baujahr; }
            set
            {
                if (Schiff.Baujahr != value)
                {
                    Schiff.Baujahr = value;
                    this.OnPropertyChanged();
                }
            }
        }


        public override string ToString()
        {
            return String.Format($"Das Schiff {Name} ist {Laenge}m lang und wurde {Baujahr} erbaut.");
        }

        public virtual string ToCSV()
        {
            return String.Format($"{Name};{Laenge};{Baujahr.ToShortDateString()}");
        }
    }
}

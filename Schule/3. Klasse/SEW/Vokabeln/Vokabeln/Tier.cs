using System;
using System.Collections.Generic;
using System.Text;

namespace Vokabeln
{
    abstract class ATier
    {
        protected string Name { get; set; }
        protected int Alter { get; set; }

        public override string ToString()
        {
            return Name + ", " + Alter;
        }
    }

    class Hund : ATier
    {
        public string Hundeart { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", " + Hundeart;
        }
    }

    class Katze : ATier
    {
        public string Fellfarbe { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", " + Fellfarbe;
        }
    }
}

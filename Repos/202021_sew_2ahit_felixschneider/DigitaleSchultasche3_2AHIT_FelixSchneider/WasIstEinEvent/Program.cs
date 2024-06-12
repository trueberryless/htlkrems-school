using System;

namespace WasIstEinEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Schueler s = new Schueler();
            s.Matura_geschafft += S_Matura; //Verknüpfung zu Event / Eventhandler registrieren
            s.Matura_geschafft += S_Matura2;
            s.Matura_durchgefallen += S_Matura_durchgefallen;

            s.Prüfen(2, "AM");
            s.Prüfen(5, "D");
            s.Prüfen(3, "E");
            s.Prüfen(5, "AM");

            s.Prüfen(1, "D");
            s.Prüfen(3, "AM");
        }

        private static void S_Matura_durchgefallen(object sender, EventArgs e)
        {
            Console.WriteLine("Heulen");
        }

        private static void S_Matura(object sender, EventArgs e)
        {
            Console.WriteLine("Feiern");
        }

        private static void S_Matura2(object sender, EventArgs e)
        {
            Console.WriteLine("Reise");
        }

        


        class Schueler
        {
            public event EventHandler Matura_geschafft;
            public event EventHandler Matura_durchgefallen;
            int AM, D, E;

            public void Prüfen(int note, string fach)
            {
                fach = fach.ToUpper();
                if (fach == "AM") AM = note;
                if (fach == "D") D = note;
                if (fach == "E") E = note;

                Zeugnisfaellig();
            }

            private void Zeugnisfaellig()
            {
                if(AM > 0 && D > 0 && E > 0)
                {
                    if(AM < 5 && D < 5 && E < 5)
                    {
                        if(Matura_geschafft != null)
                        {
                            Matura_geschafft.Invoke(this, null);
                        }
                    }
                    else
                    {
                        if (Matura_durchgefallen != null)
                        {
                            Matura_durchgefallen.Invoke(this, null);
                        }
                    }
                }
            }
        }
    }
}

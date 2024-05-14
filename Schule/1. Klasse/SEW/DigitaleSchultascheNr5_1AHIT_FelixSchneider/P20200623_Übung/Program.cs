using System;

namespace P20200623_Übung
{
    struct Person
    {
        public string Vorname;
        public string Nachname;
        public int Alter;
        public int Postleitzahl;
        public string Wohnort;
        public int Hausnummer;

        public void Ausgabe()
        {
            Console.WriteLine("Vorname: {0}, Nachname: {1}, Alter: {2}, Wohnort: {3}, Postleitzahl: {4}, Hausnummer: {5}", 
                                this.Vorname, this.Nachname, this.Alter, this.Wohnort, this.Postleitzahl, this.Hausnummer);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person a = new Person();
            a.Vorname = "Felix";
            a.Nachname = "Schneider";
            a.Alter = 15;
            a.Postleitzahl = 3541;
            a.Wohnort = "Senftenberg";
            a.Hausnummer = 13;
            a.Ausgabe();
        }
    }
}

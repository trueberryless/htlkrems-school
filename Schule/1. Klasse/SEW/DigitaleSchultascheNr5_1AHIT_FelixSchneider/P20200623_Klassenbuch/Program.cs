using System;

namespace P20200623_Klassenbuch
{
    struct Person
    { //neuer Datentyp "Person"
        public string Vorname;
        public string Nachname;
        public double note1;
        public double note2;
        public double note3;
        public double Notendurchschnitt()
        {
            return (this.note1 + this.note2 + this.note3) / 3.0;
        }

        public void Ausgabe()
        {
            Console.WriteLine("Vorname: {0}, Nachname: {1}", this.Vorname, this.Nachname);
            Console.WriteLine("Mathe: {0}, Deutsch: {1}", this.note1, this.note2);
            Console.WriteLine("Notendurchschnitt: {0}", this.Notendurchschnitt());
        }
    }
    class Program
    {       
        static void Main(string[] args)
        {
            Person a = new Person();
            a.Vorname = "Hans Peter";
            a.Nachname = "Meier";
            a.note1 = 2;
            a.note2 = 1;
            a.note3 = 4;
            a.Ausgabe();
            
        }

        //public static void Ausgabe(Person p, double nds)
        //{
        //    Console.WriteLine("Vorname: {0}, Nachname: {1}", p.Vorname, p.Nachname);
        //    Console.WriteLine("Mathe: {0}, Deutsch: {1}", p.note1, p.note2);
        //    Console.WriteLine("Notendurchschnitt: {0}", nds );
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P20201209_Firma
{
    class Person
    {
        protected string firstname;
        protected string surname;

        //Konstruktorenverkettung: ein Konstruktor ruft den anderen auf...
        public Person():this("(unbekannt)", "(unbekannt)") { 
            //dieser Copy&Paste-Code fällt durch Konstruktorverkettung weg

            //this.firstname = "unbekannt";
            //this.surname = "unbekannt";
        }
        public Person(string firstname):this(firstname, "(unbekannt)") { }

        //Dieser Konstruktor erledigt die Hauptarbeit
        public Person(string firstname, string surname)
        {
            this.firstname = firstname;
            this.surname = surname;
        }
    }
}

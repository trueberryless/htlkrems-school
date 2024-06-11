using System;


namespace ArraySorteren
{
    class Person : IComparable
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public int CompareTo(object obj)
        {
            Person other = obj as Person;
            if (this.Nachname == other.Nachname)
                return this.Vorname.CompareTo(other.Vorname);
            else
                return this.Nachname.CompareTo(other.Nachname);
        }
    }
}

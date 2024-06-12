using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Schiffe
{
    public abstract class ASchiff
    {
        public string Name { get; set; }
        public int Laenge { get; set; }
        public DateTime Baujahr { get; set; }

        public ASchiff() { }

        public override string ToString()
        {
            return String.Format($"Das Schiff {Name} ist {Laenge}m lang und wurde {Baujahr} erbaut.");
        }

        public virtual string ToCSV()
        {
            return String.Format($"{Name};{Laenge};{Baujahr.ToShortDateString()}");
        }

        static public string[] Schiffsnamen = new string[]
        {
            "Dunedin","Lithgow","Admiral Farragut","Barrosa","The Deepwater","Cobham","Panglima","The Confiance","Rigorous","Inflexible","The Prompt","Cromer Castle","Abondance","The Huron","The Mounsey",
            "Kingsmill","Duke of Edinburgh","Cesar","Gallion","The Bustler","The Kimberley","Noble","Honeysuckle","The Loyal Exploit","Pevensey Castle","Galicia","Claudia","Gallion","London","Kentish","The Chameleon","The Rupert",
            "The Prescott","Narbrough","Valeur","The Easton","Tonnant","Due Repulse","Jerfalcon","Jennet","Wolf","The Douglas","Bowmanville","Highway","The Polaris","Penzance","Largo Bay","Hamilton","Arun",
            "Havannah","Firefly","Basilisk","Malice","The Barfleur","Bedale","Undaunted","Cairns","Negro","Dame de Grace","Hindostan","The Biddeford","Tang","Bugloss","The Campbell","Coote","Brenchley",
            "The Forth","The Prestonian","The Griffin","Dorsetshire","The Churchill","Charger","Petrolla","Bantum","Bellerophon","The Crown Malago","Byron","Tormentor","Duchess of Cumberland","Spark","Kildarton","The Porlock Bay","The Churchill",
            "Furious","Seaforth","The Caldecot Castle","Hespeler","Cobham","Fandango","Chelsham","Newquay","The Indus","Damerham","Advantagia","Alceste","Mendip","The Merlin","Dingley","Brothers","Ulex",
            "Trillium","Matabele","Stalwart","The Ophelia","The Thruster","The Limbourne","Snowberry","Camel","Nerissa","The Ursula","Chance","Germoon Prize","The Polsham","Incendiary","The Padstow Bay","Ossington","America",
            "The Camperdown","Bonaventure","The Monaghan","Aro","The Palma","Clarence","Kilmorey","The Green Linnet","The Loyal Example","Freesia","The Drumheller","Bamborough Castle","Ulysses","Macedonian","Manela","Restless","The Monkton",
            "Snake","Bugloss","Khedive","Aimable","The Granby","Sappho","Syren","The Oakville","Kildarton","Childs Play","Kilcolgan","Mimosa","The Selene","Caroles","The Munlochy","The Audacious","The Arc-en-Ciel"
        };
    }
}

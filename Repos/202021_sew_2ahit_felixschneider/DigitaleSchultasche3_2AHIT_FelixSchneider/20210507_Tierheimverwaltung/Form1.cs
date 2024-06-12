using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _20210507_Tierheimverwaltung
{
    public partial class Form1 : Form
    {
        List<Animal> la = new List<Animal>();
        Dog dog;
        Bird bird;
        public Form1()
        {
            InitializeComponent();
            la.Add(new Dog(name: "Fluffi", bark: "Wuff", weight: 1)); //zwei Anfangstiere
            la.Add(new Bird(name: "Fly", wingSpan: 100, weight: 1)); //sind die nicht süß?
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list.Items.AddRange(la.ToArray()); //liste mit array auffüllen
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(list.SelectedItem == null)
            {
                return;
            }
            Animal animal = list.SelectedItem as Animal;
            if (animal.GetType() == typeof(Dog)) //wenn ausgewähltes Tier ein Hund ist...
            {
                lspezial.Text = "Bark:"; //ein Hund hat eine Bellart
                cbtype.SelectedIndex = 0; //an 1ter Stelle (Index: [0])
                dog = list.SelectedItem as Dog;
                tbname.Text = Convert.ToString(dog.Name); //Name ändern
                ldate.Text = Convert.ToString(dog.RecordingDate);
                tbweight.Text = Convert.ToString(dog.Weight) + "kg";
                tbspezial.Text = Convert.ToString(dog.Bark) + "!";
            }
            else if (animal.GetType() == typeof(Bird))
            {
                lspezial.Text = "Wing Span:";
                cbtype.SelectedIndex = 1;
                bird = list.SelectedItem as Bird;
                tbname.Text = Convert.ToString(bird.Name);
                ldate.Text = Convert.ToString(bird.RecordingDate);
                tbweight.Text = Convert.ToString(bird.Weight) + "kg";
                tbspezial.Text = Convert.ToString(bird.WingSpan) + "cm";
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            la.Add(new Dog(name: "Dog", bark: "Wuff", weight: 0)); //Standardhund hinzufügen
            list.Items.Clear(); //aktualisieren
            list.Items.AddRange(la.ToArray());
        }
        private void remove_Click(object sender, EventArgs e)
        {
            if(list.SelectedItem != null)
            {
                la.RemoveAt(list.SelectedIndex);
                list.Items.Clear(); //aktualisieren
                list.Items.AddRange(la.ToArray());
            }           
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (list.SelectedItem == null)
            {
                return;
            }
            if (list.SelectedItem.GetType() == typeof(Dog))
            {
                // eingegebene Daten in Array speichern
                dog.Name = tbname.Text;
                dog.Weight = 0;
                string weight = "";
                for (int i = 0; i < tbweight.Text.Length; i++)
                {
                    string zahlen = ".1234567890";
                    for (int j = 0; j < zahlen.Length; j++)
                    {
                        if(tbweight.Text[i] == zahlen[j])
                        {
                            weight += tbweight.Text[i];
                        }
                    }
                }
                if (weight != "")
                    dog.Weight = Convert.ToInt32(weight);
                else dog.Weight = 0;
                dog.Bark = "";
                for (int i = 0; i < tbspezial.Text.Length; i++)
                {
                    if(tbspezial.Text[i] != '!')
                    {
                        dog.Bark += tbspezial.Text[i];
                    }
                }
            }
            else if(list.SelectedItem.GetType() == typeof(Bird))
            {
                bird.Name = tbname.Text;
                bird.Weight = 0;
                string weight = "";
                for (int i = 0; i < tbweight.Text.Length; i++)
                {
                    string zahlen = ".1234567890";
                    for (int j = 0; j < zahlen.Length; j++)
                    {
                        if (tbweight.Text[i] == zahlen[j])
                        {
                            weight += tbweight.Text[i];
                        }
                    }
                }
                if (weight != "")
                    dog.Weight = Convert.ToInt32(weight);
                else dog.Weight = 0;
                bird.WingSpan = 0;
                string wingSpan = "";
                for (int i = 0; i < tbspezial.Text.Length; i++)
                {
                    string zahlen = ".1234567890";
                    for (int j = 0; j < zahlen.Length; j++)
                    {
                        if (tbspezial.Text[i] == zahlen[j])
                        {
                            wingSpan += tbspezial.Text[i];
                        }
                    }
                }
                if(wingSpan != "")
                    bird.WingSpan = Convert.ToInt32(wingSpan);
                else bird.WingSpan = 0;
            }
            RefreshList();
        }

        private void save_Click(object sender, EventArgs e) //Datei abspeichern
        {
            SaveFileDialog sd = new SaveFileDialog();
            if (sd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sd.FileName))
                {
                    foreach (var item in la)
                    {
                        if(item.GetType() == typeof(Dog))
                        {
                            sw.WriteLine("Dog;" + item.Name + ";" + item.RecordingDate + ";" + item.Weight + ";" + ((Dog)item).Bark);
                        }
                        else if(item.GetType() == typeof(Bird))
                        {
                           sw.WriteLine("Bird;" + item.Name + ";" + item.RecordingDate + ";" + item.Weight + ";" + ((Bird)item).WingSpan);
                        }
                    }
                }
            }
        }

        private void load_Click(object sender, EventArgs e) //Datei laden
        {
            OpenFileDialog od = new OpenFileDialog();
            la.Clear();
            if (od.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(od.FileName))
                {
                    while (sr.Peek() > 0)
                    {
                        string line = sr.ReadLine();
                        string[] elements = line.Split(';');
                        if(elements[0] == "Dog")
                        {
                            la.Add(new Dog(name: elements[1], rD: Convert.ToDateTime(elements[2]), weight: Convert.ToInt32(elements[3]), bark: elements[4]));
                        }
                        else if(elements[0] == "Bird")
                        {
                            la.Add(new Bird(name: elements[1], rD: Convert.ToDateTime(elements[2]), weight: Convert.ToInt32(elements[3]), wingSpan: Convert.ToInt32(elements[4])));
                        }
                    }
                }
            }
            RefreshList();
        }

        private void cbtype_SelectedIndexChanged(object sender, EventArgs e) //Tierart ändern
        {
            if(lspezial.Text == "Bark:" && cbtype.SelectedIndex != 0 || lspezial.Text == "Wing Span:" && cbtype.SelectedIndex != 1)
            {
                la.RemoveAt(list.SelectedIndex);
                if (cbtype.SelectedIndex == 0)
                    la.Add(new Dog(name: "Dog", bark: "Wuff", weight: 0));
                else if (cbtype.SelectedIndex == 1)
                    la.Add(new Bird(name: "Bird", wingSpan: 100, weight: 0));
                RefreshList();
            }
        }

        void RefreshList()
        {
            int index = list.SelectedIndex;
            list.Items.Clear();
            list.Items.AddRange(la.ToArray());
            list.SelectedIndex = index;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }

    abstract class Animal
    {
        public DateTime RecordingDate { get; set; }
        public double Weight { get; set; }
        public string Name { get; set; }

        //Constructors
        public Animal() : this("unnamed", DateTime.Now, 0) { }

        public Animal(double weight) : this("unnamed", DateTime.Now, weight) { }

        public Animal(DateTime rD, double weight):this("unnamed", rD, weight) { }

        public Animal(string name, DateTime recordingDate, double weight)
        {
            Name = name;
            RecordingDate = recordingDate;
            if (weight > 0)
                Weight = weight;
        }
    }

    class Bird : Animal
    {
        public int WingSpan { get; set; }

        //Constructors
        public Bird() : this("unnamed", 0, DateTime.Now, 0) { }

        public Bird(int wingSpan) : this("unnamed", wingSpan, DateTime.Now, 0) { }

        public Bird(int wingSpan, double weight) : this("unnamed", wingSpan, DateTime.Now, weight) { }

        public Bird(string name, int wingSpan, double weight) : this(name, wingSpan, DateTime.Now, weight) { }

        public Bird(int wingSpan, DateTime rD, double weight) : this("unnamed", wingSpan, rD, weight) { }

        public Bird(string name, int wingSpan, DateTime rD, double weight) : base(name, rD, weight)
        {
            WingSpan = wingSpan;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    class Dog : Animal
    {
        public string Bark { get; set; }

        //Constructors
        public Dog() : this("unnamed", "none", DateTime.Now, 0) { }

        public Dog(string bark) : this("unnamed", bark, DateTime.Now, 0) { }

        public Dog(string bark, double weight) : this("unnamed", bark, DateTime.Now, weight) { }
        public Dog(string name, string bark, double weight) : this(name, bark, DateTime.Now, weight) { }

        public Dog(string bark, DateTime rD, double weight) : this("unnamed", bark, rD, weight) { }

        public Dog(string name, string bark, DateTime rD, double weight) : base(name, rD, weight)
        {
            this.Bark = bark;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
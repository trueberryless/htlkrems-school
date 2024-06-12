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

namespace _20210507_Listen
{
    public partial class Form1 : Form
    {
        List<Person> lp = new List<Person>();
        Person person;
        public Form1()
        {
            InitializeComponent();
            lp.Add(new Person { FirstName = "Susi", LastName = "Sorglos" });
            lp.Add(new Person { FirstName = "Tom", LastName = "Turbo" });
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            person = listBox1.SelectedItem as Person;
            tbFirstName.Text = person.FirstName;
            tbLastName.Text = person.LastName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(lp.ToArray());
        }

        private void save_Click(object sender, EventArgs e)
        {
            person.FirstName = tbFirstName.Text;
            person.LastName = tbLastName.Text;

            listBox1.Items.Clear();
            listBox1.Items.AddRange(lp.ToArray());
        }

        private void save_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            if (sd.ShowDialog()== DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sd.FileName))
                {
                    foreach (var item in lp)
                    {
                        sw.WriteLine(item.FirstName + ";" + item.LastName);
                    }
                }
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            lp.Clear();
            if(od.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(od.FileName))
                {
                    while(sr.Peek() > 0)
                    {
                        string line = sr.ReadLine();
                        string[] elements = line.Split(';');
                        lp.Add(new Person { FirstName = elements[0], LastName = elements[1] });
                    }
                }
            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(lp.ToArray());
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}

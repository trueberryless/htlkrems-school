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
using Newtonsoft.Json;

namespace _20210528_DictionaryForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, Word> DictWords = new Dictionary<string, Word>();

        private void Form1_Load(object sender, EventArgs e)
        {
            using(StreamReader sr = new StreamReader("words.json"))
            {
                while(sr.Peek() > 0)
                {
                    string line = sr.ReadLine();
                    DictWords = JsonConvert.DeserializeObject<Dictionary<string, Word>>(line);
                }
            }
            lblist.Items.AddRange(new List<string>(DictWords.Keys).ToArray()); //liste mit array auffüllen
            //lblist.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbword.Text == "")
            {
                lwordright.Text = DictWords[lblist.SelectedItem.ToString()].WordRight.ToString();
                lwordwrong.Text = DictWords[lblist.SelectedItem.ToString()].WordWrong.ToString();
                return;
            }
            if (tbword.Text == DictWords[lblist.SelectedItem.ToString()].EnglishWord)
            {
                bcheck.BackColor = Color.Green;
                DictWords[lblist.SelectedItem.ToString()].WordRight++;
                lwordright.Text = DictWords[lblist.SelectedItem.ToString()].WordRight.ToString();
            }
            else
            {
                bcheck.BackColor = Color.OrangeRed;
                DictWords[lblist.SelectedItem.ToString()].WordWrong++;
                lwordwrong.Text = DictWords[lblist.SelectedItem.ToString()].WordWrong.ToString();
            }
            tbword.Text = "";
            using (StreamWriter sw = new StreamWriter("words.json"))
            {
                sw.WriteLine(JsonConvert.SerializeObject(DictWords));
            }
        }        

        private void bcheck_Click(object sender, EventArgs e)
        {
            if (lblist.SelectedIndex == 0)
                return;
            if(tbword.Text == DictWords[lblist.SelectedItem.ToString()].EnglishWord)
            {
                bcheck.BackColor = Color.Green;
                DictWords[lblist.SelectedItem.ToString()].WordRight++;
                lwordright.Text = DictWords[lblist.SelectedItem.ToString()].WordRight.ToString();
            }
            else
            {
                bcheck.BackColor = Color.OrangeRed;
                DictWords[lblist.SelectedItem.ToString()].WordWrong++;
                lwordwrong.Text = DictWords[lblist.SelectedItem.ToString()].WordWrong.ToString();
            }
            tbword.Text = "";
            using (StreamWriter sw = new StreamWriter("words.json"))
            {
                sw.WriteLine(JsonConvert.SerializeObject(DictWords));
            }
        }

        private void badd_Click(object sender, EventArgs e)
        {
            
            foreach (var item in DictWords)
            {
                if (tbaddkey.Text == item.Key)
                {
                    tbaddkey.Text = "";
                    tbaddvalue.Text = "";
                    return;
                }                    
            }
            DictWords.Add(tbaddkey.Text, new Word() { EnglishWord = tbaddvalue.Text, WordRight = 0, WordWrong = 0 });
            lblist.Items.Clear();
            lblist.Items.AddRange(new List<string>(DictWords.Keys).ToArray());
            using(StreamWriter sw = new StreamWriter("words.json"))
            {
                sw.WriteLine(JsonConvert.SerializeObject(DictWords));
            }
            tbaddkey.Text = "";
            tbaddvalue.Text = "";
        }

        private void bremove_Click(object sender, EventArgs e)
        {
            if(lblist.SelectedIndex != 0)
            {
                string word = lblist.SelectedItem.ToString();
                DictWords.Remove(word);
                lblist.Items.Clear();
                lblist.Items.AddRange(new List<string>(DictWords.Keys).ToArray());
                using (StreamWriter sw = new StreamWriter("words.json"))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(DictWords));
                }
            }
            
        }

        private void bsave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            if (sd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sd.FileName))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(DictWords));
                }
            }
        }

        private void bload_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(od.FileName))
                {
                    while (sr.Peek() > 0)
                    {
                        string line = sr.ReadLine();
                        DictWords = JsonConvert.DeserializeObject<Dictionary<string, Word>>(line);
                    }
                }
            }

            lblist.Items.Clear();
            lblist.Items.AddRange(new List<string>(DictWords.Keys).ToArray());
        }
    }
}

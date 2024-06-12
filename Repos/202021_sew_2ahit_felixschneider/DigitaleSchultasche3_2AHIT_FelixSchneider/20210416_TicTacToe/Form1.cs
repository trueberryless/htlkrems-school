using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLibary;

namespace _20210416_TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Example ee = new Example();
        TicTacToe ttt = new TicTacToe();

        const int SIZE = 200;
        
        private Button BuildButton(string text, string name, int posx, int posy)
        {
            Button b = new Button();
            b.Text = text;
            b.Name = name;

            b.Left = posx;
            b.Top = posy;

            b.Width = SIZE;
            b.Height = SIZE;

            Controls.Add(b);
            return b;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            // Button Nr auslesen
            string nr = clicked.Name.Substring(clicked.Name.Length - 1);

            // Spielstein setzen und auswerten
            string response = ttt.SetElement(Convert.ToInt32(nr)).ToString();
            if (response != " ")
                clicked.Text = response; // Kein Fehler => Button Text setzten

            char winner = ttt.GetWinner(); // Gewinner ermitteln
            if (winner != ' ')
                MessageBox.Show("The winner is: " + winner); // Ja!
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(ee.Hallo());
            Button b;
            for (int i = 1; i < 10; i++)
            {
                b = BuildButton("", i.ToString(), (i - 1) % 3 * SIZE, (i - 1) / 3 * SIZE);
                b.Click += Button_Click;
            }
        }
    }
}

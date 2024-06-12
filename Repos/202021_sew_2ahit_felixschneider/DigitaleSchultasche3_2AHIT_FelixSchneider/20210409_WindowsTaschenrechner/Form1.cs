using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20210409_WindowsTaschenrechner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int SIZE = 200;
        private Button BuildButton(string text, int posx, int posy)
        {
            Button b = new Button();
            b.Text = text;

            b.Left = posx;
            b.Top = posy;

            b.Width = SIZE;
            b.Height = SIZE;

            Controls.Add(b);
            return b;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button b;
            // Button 0
            b = BuildButton("0", SIZE, 5 * SIZE);
            b.Click += Ziffer_Click;
            // Buttons 1-9
            for (int i = 1; i <= 9; i++)
            {
                b = BuildButton(i.ToString(), (i - 1) % 3 * SIZE, 4 * SIZE - (i - 1) / 3 * SIZE);
                b.Click += Ziffer_Click;
            }
            // Rechenoperatoren
            string[] op = { "=", "+", "-", "*", "/" };
            for (int i = 4; i >= 0; i--)
            {
                b = BuildButton(op[i], 3 * SIZE, 5 * SIZE - i * SIZE);
                b.Click += RechenOp_Click; ;
            }
        }

        private void RechenOp_Click(object sender, EventArgs e)
        {
            Button gedrueckt = sender as Button;
            //MessageBox.Show("Rechenoperation gedrückt: " + gedrueckt.Text);

            if(lbl_wert.Text != "")
            {
                lbl_wert.Text = Berechne(lbl_operator.Text, lbl_wert.Text, textBox1.Text).ToString();
            }
            else
            {
                lbl_wert.Text = textBox1.Text;
            }

            lbl_operator.Text = gedrueckt.Text;
            textBox1.Text = "";
        }

        private void Ziffer_Click(object sender, EventArgs e)
        {
            Button gedrueckt = sender as Button;
            //MessageBox.Show("Ziffer gedrückt: " + gedrueckt.Text);

            textBox1.Text = textBox1.Text + gedrueckt.Text;
        }        

        public double Berechne(string op, string wert1, string wert2)
        {
            Double.TryParse(wert1, out double a);
            Double.TryParse(wert2, out double b);
            switch(op)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
            }
            return 0;
        }
    }
}

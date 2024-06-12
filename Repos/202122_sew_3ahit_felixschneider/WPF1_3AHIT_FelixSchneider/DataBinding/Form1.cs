namespace DataBinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Substring(0, textBox1.Text.Length - 1) == textBox2.Text || textBox2.Text == "")
                textBox2.Text = textBox1.Text;
        }
    }
}
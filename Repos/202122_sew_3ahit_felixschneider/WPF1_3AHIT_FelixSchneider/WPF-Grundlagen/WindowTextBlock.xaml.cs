using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Grundlagen
{
    /// <summary>
    /// Interaktionslogik für WindowTextBlock.xaml
    /// </summary>
    public partial class WindowTextBlock : Window
    {
        public WindowTextBlock()
        {
            InitializeComponent();
            ReadFile("text.txt");
        }

        private void ReadFile(string filename)
        {
            tblFile.Text = System.IO.File.ReadAllText(filename);
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
    }
}

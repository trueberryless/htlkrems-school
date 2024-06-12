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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Grundlagen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBoxResult result = MessageBox.Show("Stimmen Sie der Verwendung von Cookies zu?", "Cookies", 
                MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Schön, das wollten wir!", "Cookies");
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Schade, dann werden gewisse Funktionen nicht unterstützt!", "Cookies");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Tschau!", "Cookies");
                    this.Close();
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowTextBlock w = new WindowTextBlock();
            w.Show();
        }
    }
}

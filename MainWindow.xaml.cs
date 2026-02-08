using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string j = "";
        public MainWindow()
        {
            InitializeComponent();
            Equal.Click += equalValues;
            char[] digits = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // Added digits
            int n = 0x221A;
            int j = 0x21E6;
            string p = char.ConvertFromUtf32(j);
        }
        
        private void equalValues(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(j);
        }
    }
}
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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HandleHelloClick(object sender, RoutedEventArgs e)
        {
            var text = "";
            foreach (var child in MainGrid.Children)
                if (child is TextBox box)
                    text = $"{text}{box.Text} \n";

            MessageBox.Show("Hello " + text);
        }
    }
}
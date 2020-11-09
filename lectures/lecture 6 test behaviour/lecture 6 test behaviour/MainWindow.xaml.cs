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

namespace lecture_6_test_behaviour
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

        private void btnForLoop_Click(object sender, RoutedEventArgs e)
        {
            List<int> lstLoopedNumbers = new List<int>();

            lstLoopedNumbers.Clear();

            for (int irStartingIndex = 100; irStartingIndex > 10; irStartingIndex = irStartingIndex + 300000000)
            {
                lstLoopedNumbers.Add(irStartingIndex);
            }
        }
    }
}

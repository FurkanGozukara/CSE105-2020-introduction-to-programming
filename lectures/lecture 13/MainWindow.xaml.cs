using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using NCalc;

namespace lecture_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtUserInput.Focus();
            listBoxResults.ItemsSource = Results;
       
        }

        private ObservableCollection<string> _Results = new ObservableCollection<string>();
        public ObservableCollection<string> Results
        {
            get { return _Results; }
            set
            {
                _Results = value;
            }
        }

        private void textAddingButtonClick(object sender, RoutedEventArgs e)
        {
            Button myButton = (Button)sender;

            txtUserInput.Text += myButton.Content.ToString();
            focusInputBox();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserInput.Text.Length > 0)
            {
                txtUserInput.Text = txtUserInput.Text.Substring(0, txtUserInput.Text.Length - 1);
            }
            focusInputBox();
        }

        private void focusInputBox()
        {
            txtUserInput.Focus();
            txtUserInput.SelectionStart = txtUserInput.Text.Length;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUserInput.Text = "";
            focusInputBox();
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            decimal decResult = decimal.Zero;
            try
            {
                decResult = Evaluate(txtUserInput.Text);
            }
            catch (Exception E)
            {
                MessageBox.Show("You have entered an incorrect mathmetical equation. Here error message:\n " + E.Message);
                return;
            }

            Results.Insert(0, txtUserInput.Text + "\t=" + decResult.ToString("N5"));
            btnClear_Click(null, null);
        }

        public static decimal Evaluate(String input)
        {
            NCalc.Expression e = new NCalc.Expression(input);
            var result = e.Evaluate();

            decimal h2 = Decimal.Parse(result.ToString(), System.Globalization.NumberStyles.Any);

            return Convert.ToDecimal(h2);
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter))
            {
                btnEqual_Click(null, null);
            }
            if ((e.Key == Key.D4 && Keyboard.IsKeyDown(Key.RightAlt)))
            {
                e.Handled = true;
            }
        }

        //use a white list of characters to be entered into the textbox to prevent user from entering invalid characters
        List<string> lstWhiteListedCharacters = new List<string> { "1", "2", "3", "+", "-" };
    }
}

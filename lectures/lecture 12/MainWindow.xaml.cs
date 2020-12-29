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

namespace lecture_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            helper_methods.runningWindow = this;
            tabLoggedIn.IsEnabled = false;
            tabLogout.Visibility = Visibility.Hidden;
            tabLogout.IsEnabled = false;
        }

        private void btnCompleteRegister_Click(object sender, RoutedEventArgs e)
        {
            Tuple<bool, string> registerResult = MainFunctions.tryToRegister(this);

            if (registerResult.Item1 == false)
            {
                MessageBox.Show(registerResult.Item2);
                return;
            }

            MessageBox.Show("You have successfully registered. Now you will be automatically logged-in");

            helper_methods.doLogin(this.txtUserName_Register.Text);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainFunctions.tryLogin(this);
        }

        public void displayMessage(string srMessage)
        {
            MessageBox.Show(srMessage);
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            helper_methods.doLogOut();
        }

        private void btnGoToRegister_Click(object sender, RoutedEventArgs e)
        {
            tabRegister.IsSelected = true;
        }
    }
}

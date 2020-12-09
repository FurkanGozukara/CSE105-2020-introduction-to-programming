using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using static lecture_8.static_extensions;//with this way i am adding all the public methods, fields, properties, etc. of that class to this class

namespace lecture_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {//scope level 0

        List<RadioButton> lstRadioButtonsList;//scope level 1
        List<RadioButton> lstScoresofLetters;//scope level 1
        List<RadioButton> lstLettersOfScopes;//scope level 1
        List<ListBoxItem> listOfListBoxItems = new List<ListBoxItem>();

        public MainWindow()//this is the constructor of our main window application //scope level 1
        {
            //after constructor is called the class is initialized in this case the application itself
            InitializeComponent();

            lstRadioButtonsList = new List<RadioButton> { rbGuest, rbStudent, rbLecturer, rbAdmin };



            string srTwo = "2";


        }

        private void bindItemsSource(object sender, EventArgs e)
        {
            if (listBox1.ItemsSource == null)
                listBox1.ItemsSource = listOfListBoxItems;

            listBox1.Items.Refresh();
        }

        private void btnShowSelected_Click(object sender, RoutedEventArgs e) //scope level 1
        {
            var vrResult = lameWayShowRadioButtonMessage();
            MessageBox.Show(vrResult);
        }

        private List<string> properWayShowRadioButtonMsg() //scope level 1
        {
            List<string> lstMessages = new List<string>();

            var vrSingeList = new List<RadioButton>(lstLettersOfScopes);

            vrSingeList.AddRange(lstScoresofLetters);

            //with only single foreach i will loop through all radio buttons
            foreach (var vrButton in vrSingeList)
            {
                if (vrButton.IsChecked == true)
                {
                    lstMessages.Add("the content of selected button: " + vrButton.Content + "\n\nThe value of selected radio button: " + vrButton.DataContext);
                }
            }

            if (lstMessages.Count == 0)
                lstMessages.Add("no radio button is selected");

            return lstMessages;

        }

        private string lameWayShowRadioButtonMessage() //scope level 1
        {
            string srShowMsg = null;

            if (rbGuest.IsChecked == true)
                srShowMsg = "Guest account is selected";
            if (rbStudent.IsChecked == true)
                srShowMsg = "Student account is selected";
            if (rbLecturer.IsChecked == true)
                srShowMsg = "Lecturer account is selected";
            if (rbAdmin.IsChecked == true)
                srShowMsg = "Admin account is selected";



            //if none of  the radio buttons is selected and string is still empty
            if (string.IsNullOrEmpty(srShowMsg) == true) //scope level 2
            {
                srShowMsg = "no radio button is selected - is null or empty";
            }

            //if none of  the radio buttons is selected and string is still empty
            //if the string is null, this below method will throw an unhandled error
            //if (srShowMsg.Length < 1)
            //{

            //}

            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators
            //Null-conditional operators ?. and ?[]
            if (srShowMsg?.Length < 1)//so ? ensures that the object is not null before executing the method or the property of the object
            {
                srShowMsg = "no radio button is selected - lenght control";
            }

            //pr => is a lambda expression : https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions

            int irSelectedRadioButtonCout = 0;//1
            foreach (var vrPerRadioButton in lstRadioButtonsList)//2
            {//3
                if (vrPerRadioButton.IsChecked == true)//4
                    irSelectedRadioButtonCout++;//5
            }//6

            if (irSelectedRadioButtonCout == 0)//7
            {

            }

            //this single line of code is equal to above 7 lines of code
            if (lstRadioButtonsList.Where(pr => pr.IsChecked == true).ToArray().Length == 0)
            {
                Random randGenerator = new Random();
                int irRandomNumber = randGenerator.Next(0, lstRadioButtonsList.Count);
                //since my list has 4 elements, max value will be 3
                //min value will be 0

                lstRadioButtonsList[irRandomNumber].IsChecked = true;
                //lameWayShowRadioButtonMessage();
            }

            return srShowMsg;
        }

        private void btnClearSelection_Click(object sender, RoutedEventArgs e)
        {
            foreach (var vrPerRadioButton in lstRadioButtonsList)
            {
                vrPerRadioButton.IsChecked = false;
            }

            //the below code is equal to above code
            rbAdmin.IsChecked = false;
            rbGuest.IsChecked = false;
            rbLecturer.IsChecked = false;
            rbStudent.IsChecked = false;
        }

        private void btnShowSelectedRadio_Click(object sender, RoutedEventArgs e)
        {
            if (lstScoresofLetters == null)
            {
                lstScoresofLetters = new List<RadioButton>();
                lstLettersOfScopes = new List<RadioButton>();

                foreach (RadioButton rb in FindVisualChildren<RadioButton>(this))
                {
                    if (rb.GroupName == "ScoresOfLetters")
                    {
                        lstScoresofLetters.Add(rb);
                    }
                    if (rb.GroupName == "LettersOfScores")
                    {
                        lstLettersOfScopes.Add(rb);
                    }
                }
            }


            foreach (var vrPerMsg in properWayShowRadioButtonMsg())
            {
                MessageBox.Show(vrPerMsg);
            }
        }

        private void btnShowSelectedCheckBoxes_Click(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox perCheckBox in FindVisualChildren<CheckBox>(this.secondGroupd))
            {
                if (perCheckBox.IsChecked == true)
                {
                    MessageBox.Show($"checked box content: {perCheckBox.Content}\n\nChecked box value {perCheckBox.DataContext}");
                }
            }
        }

        private void btnAddRandomnumbers_Click(object sender, RoutedEventArgs e)
        {
            Random myRand = new Random();

            for (int i = 0; i < 10; i++)
            {
                listBox1.Items.Add(myRand.Next().ToString("N0"));
            }
        }



        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.Items.Count > 2)
                listBox1.Items[2] = "900,000,000";

            if (listBox1.Items.Count > 3)
                listBox1.Items.Insert(3, "750,000,000,000");

            if (listBox1.Items.Count > 5)
                listBox1.Items.RemoveAt(5);

            if (listBox1.Items.Count > 7)
                MessageBox.Show(listBox1.Items[7].ToString());

            ListBoxItem myCustomItem = new ListBoxItem();
            myCustomItem.Content = "custom item something";
            myCustomItem.Foreground = Brushes.Blue;
            myCustomItem.Background = Brushes.Yellow;
            myCustomItem.FontSize = 20;
            myCustomItem.DataContext = "95,545,487,564";

            listBox1.Items.Add(myCustomItem);

            ListBoxItem gg = (ListBoxItem)listBox1.Items[listBox1.Items.Count - 1];
            MessageBox.Show("square root of data of last listbox item is : " + Math.Sqrt(Convert.ToDouble(gg.DataContext.ToString().Replace(",", ""))).ToString("N6"));
        }

        private void btnDataSourceBinding_Click(object sender, RoutedEventArgs e)
        {

          

            Random random = new Random();

            //i am dynamically getting all color structs Colors class
            var colors = typeof(Colors)
             .GetProperties(BindingFlags.Static | BindingFlags.Public)
             .ToDictionary(p => p.Name,
                           p => new SolidColorBrush((Color)p.GetValue(null, null))
                          );

            List<SolidColorBrush> lstSolidcolors = new List<SolidColorBrush>();

            foreach (var item in colors)
            {
                lstSolidcolors.Add(item.Value);
            }

            for (int i = 0; i < 1; i++)
            {

                Brush randomBrush1 = (Brush)lstSolidcolors[(random.Next(lstSolidcolors.Count))];
                Brush randomBrush2 = (Brush)lstSolidcolors[(random.Next(lstSolidcolors.Count))];

                ListBoxItem myCustomItem = new ListBoxItem();
                myCustomItem.Foreground = randomBrush1;
                myCustomItem.Background = randomBrush2;
                myCustomItem.FontSize = 20;
                myCustomItem.Content = random.Next().ToString("N0");
                listOfListBoxItems.Add(myCustomItem);
            }


            bindItemsSource(null, null);

        }
    }
}

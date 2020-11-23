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
using System.IO;

namespace lecture_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            initUserAuthComboBox();

            initNumberCountsComboBox();
        }

        public class customNumber
        {
            public string srDisplayName { get; set; } = "Select Random Number Count";
            public int irNumberCount { get; set; } = 1;
        }

        List<customNumber> lstMyCustomNumbers = new List<customNumber>();

        private void initNumberCountsComboBox()
        {
            customNumber defaultCustomNumber = new customNumber();
            lstMyCustomNumbers.Add(defaultCustomNumber);

            customNumber firstNumber = new customNumber();
            firstNumber.irNumberCount = 10;
            firstNumber.srDisplayName = "First Level Number Count";

            lstMyCustomNumbers.Add(firstNumber);

            customNumber secondNumber = new customNumber
            {
                irNumberCount = 50,
                srDisplayName = "Second Level Number Count"
            };

            lstMyCustomNumbers.Add(secondNumber);

            lstMyCustomNumbers.Add(new customNumber { irNumberCount = 300, srDisplayName = "Third Level Number Count" });

            lstMyCustomNumbers.Add(new customNumber());
            lstMyCustomNumbers[lstMyCustomNumbers.Count - 1].irNumberCount = 750;
            lstMyCustomNumbers[lstMyCustomNumbers.Count - 1].srDisplayName = "Fourth Level Number Count";

            lstMyCustomNumbers.Add(new customNumber());
            lstMyCustomNumbers.Last().irNumberCount = 1000;
            lstMyCustomNumbers.Last().srDisplayName = "Ultimate Level Number Count";

            cmbNumberCount.ItemsSource = lstMyCustomNumbers;
            cmbNumberCount.DisplayMemberPath = "srDisplayName";
            cmbNumberCount.SelectedValuePath = "irNumberCount";

            cmbNumberCount.SelectedIndex = 0;

            for (int i = 0; i < lstMyCustomNumbers.Count; i++)
            {
                lstMyCustomNumbers[i].srDisplayName = lstMyCustomNumbers[i].srDisplayName + $" ({lstMyCustomNumbers[i].irNumberCount.ToString("N0")})";
            }

        }

        private void initUserAuthComboBox()
        {
            cmbUserTitles.Items.Add("Select user authority level");
            cmbUserTitles.Items.Add("Guest");
            cmbUserTitles.Items.Add("Student");
            cmbUserTitles.Items.Add("Assistant");
            cmbUserTitles.Items.Add("Lecturer");
            cmbUserTitles.Items.Add("Admin");
            cmbUserTitles.Items.Add("Super Admin");
            cmbUserTitles.Items.Add("Heroic Admin");

            cmbUserTitles.SelectedIndex = 0;
        }

        private void btnShowSelectedItemValue_Click(object sender, RoutedEventArgs e)
        {
            //this works because all of the items of combobox are strings 
            var vrSelectedValue = cmbUserTitles.SelectedItem.ToString();

            int irSelectedAuthorityLevel = 0;
            int irSelectedAuthoritySecurityLevel = 0;

            switch (vrSelectedValue)
            {
                case "Guest":
                    irSelectedAuthorityLevel = 1;
                    irSelectedAuthoritySecurityLevel = 0;
                    break;
                case "Student":
                    irSelectedAuthorityLevel = 2;
                    irSelectedAuthoritySecurityLevel = 1;
                    break;
                case "Assistant":
                    irSelectedAuthorityLevel = 3;
                    irSelectedAuthoritySecurityLevel = 3;
                    break;
                case "Lecturer":
                    irSelectedAuthorityLevel = 5;
                    irSelectedAuthoritySecurityLevel = 5;
                    break;
                case "Admin":
                    irSelectedAuthorityLevel = 9;
                    irSelectedAuthoritySecurityLevel = 9;
                    break;
                default://if none of the other cases are satisfied the default condition is executed // this is like capture all else / other conditions
                    irSelectedAuthorityLevel = -1;
                    irSelectedAuthoritySecurityLevel = -1;
                    vrSelectedValue = "No Title Selected";
                    break;
            }


            //this below if and else sequence equal to above switch case
            if (vrSelectedValue == "Guest")
            {
                irSelectedAuthorityLevel = 1;
                irSelectedAuthoritySecurityLevel = 0;
            }
            else
           if (vrSelectedValue == "Student")
            {
                irSelectedAuthorityLevel = 2;
                irSelectedAuthoritySecurityLevel = 1;
            }
            else
           if (vrSelectedValue == "Assistant")
            {
                irSelectedAuthorityLevel = 3;
                irSelectedAuthoritySecurityLevel = 3;
            }
            else
           if (vrSelectedValue == "Assistant")
            {
                irSelectedAuthorityLevel = 5;
                irSelectedAuthoritySecurityLevel = 5;
            }
            else
           if (vrSelectedValue == "Admin")
            {
                irSelectedAuthorityLevel = 9;
                irSelectedAuthoritySecurityLevel = 9;
            }
            else
            {
                irSelectedAuthorityLevel = -1;
                irSelectedAuthoritySecurityLevel = -1;
                vrSelectedValue = "No Title Selected";
            }

            string srMsg = $@"
Selected Authority Title = {vrSelectedValue}
Selected Authority Level = {irSelectedAuthorityLevel}
Selected Authority Security Level = {irSelectedAuthoritySecurityLevel}";

            MessageBox.Show(srMsg);
        }

        private void btnWriteRandomNumbers_Click(object sender, RoutedEventArgs e)
        {
            //this won't work because all of the items of combobox are custom class objects
            var vrSelectedValue = cmbNumberCount.SelectedItem.ToString();

            //int irSelectedValue = Convert.ToInt32(cmbNumberCount.SelectedValue);
            //this is explicitly setting the object type equal to Conver.ToInt32 
            //this below is equal to above explicity convert.toint32 methodoloy
            int irSelectedValue = (int)cmbNumberCount.SelectedValue;

            writeAsSingleString(irSelectedValue);

            writeAsLines(irSelectedValue);

            writeAsAppendText(irSelectedValue);

            writeAsStream(irSelectedValue);
        }

        private void writeAsSingleString(int irRandomNumberCount)
        {
            Random myRand = new Random();

            string srRandomNumbers = "";

            //this is the lowest performance because string concatenation is the slowest one
            //each time when you concatenate a string, it generates a new string object
            //so this consumes a lot of cpu
            for (int i = 0; i < irRandomNumberCount; i++)
            {
                srRandomNumbers += $"Index {i}:\t\t" + myRand.Next().ToString("N0") + "\r\n";
            }

            //this will overwrite the previous file
            File.WriteAllText("writeAsSingleString.txt", srRandomNumbers, Encoding.UTF8);
        }

        private void writeAsLines(int irRandomNumberCount)
        {
            Random myRand = new Random();

            List<string> lstLines = new List<string>();

            for (int i = 0; i < irRandomNumberCount; i++)
            {
                lstLines.Add($"Index {i}:\t\t" + myRand.Next().ToString("N0"));
            }

            File.WriteAllLines("writeAsLines.txt", lstLines, Encoding.UTF8);
        }

        private void writeAsAppendText(int irRandomNumberCount)
        {
            Random myRand = new Random();

            for (int i = 0; i < irRandomNumberCount; i++)
            {
                //this is also very poor performance because each time it will open the text file, write append the new text and then close the text file
                //this will not overwrite the previous file but append text to it
                File.AppendAllText("writeAsAppendText.txt", $"Index {i}:\t\t" + myRand.Next().ToString("N0") + Environment.NewLine, Encoding.UTF8);

                //this overwrites and delete the previous file
                File.WriteAllText("WriteAllText.txt", $"Index {i}:\t\t" + myRand.Next().ToString("N0") + Environment.NewLine, Encoding.UTF8);
            }
        }

        private void writeAsStream(int irRandomNumberCount)
        {
            Random myRand = new Random();

            StreamWriter swWriterNoAppend = new StreamWriter(
                "writeAsStream_no_append.txt",
                    append: false,
                        Encoding.UTF8);

            StreamWriter swWriterAppend = new StreamWriter(
                "writeAsStream_append.txt",
                    append: true,
                        Encoding.UTF8);

            StreamWriter swWriterNoAppend_autoFlush = new StreamWriter(
    "writeAsStream_no_append_auto_flush.txt",
        append: false,
            Encoding.UTF8);
            swWriterNoAppend_autoFlush.AutoFlush = true;

            StreamWriter swWriterAppend_autoFlush = new StreamWriter(
                "writeAsStream_append_auto_flush.txt",
                    append: true,
                        Encoding.UTF8);
            swWriterAppend_autoFlush.AutoFlush = true;

            List<StreamWriter> lstMyWriters = new List<StreamWriter> { swWriterNoAppend, swWriterAppend, swWriterNoAppend_autoFlush, swWriterAppend_autoFlush };

            for (int i = 0; i < irRandomNumberCount; i++)
            {
                swWriterNoAppend.WriteLine($"Index {i}:\t\t" + myRand.Next().ToString("N0"));
                swWriterNoAppend.Flush();//immedaitely writes the cache to the file therefore no data loss
                //however this may slow down your application

                swWriterAppend.WriteLine($"Index {i}:\t\t" + myRand.Next().ToString("N0"));
                swWriterAppend.Flush();

                //for more information related to auto flash : https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter.autoflush?view=net-5.0
                swWriterNoAppend_autoFlush.WriteLine($"Index {i}:\t\t" + myRand.Next().ToString("N0"));
                swWriterAppend_autoFlush.WriteLine($"Index {i}:\t\t" + myRand.Next().ToString("N0"));
            }

            foreach (var vrWriter in lstMyWriters)
            {
                vrWriter.Close();
            }
        }

        private void btnFileReadingExamples_Click(object sender, RoutedEventArgs e)
        {
            string srEntireFile = File.ReadAllText("writeAsStream_append_auto_flush.txt", Encoding.UTF8);

            string srEntireFile_v2 = "";
            foreach (string srLine in File.ReadLines("writeAsStream_append_auto_flush.txt", Encoding.UTF8))
            {
                srEntireFile_v2 += srLine + Environment.NewLine;
            }

            string srEntireFile_v3 = "";
            List<string> lstAllLines = File.ReadAllLines("writeAsStream_append_auto_flush.txt", Encoding.UTF8).ToList();
            srEntireFile_v3 = string.Join("\r\n", lstAllLines);

            string srEntireFile_v4 = "";
            StreamReader srReader = new StreamReader("writeAsStream_append_auto_flush.txt", Encoding.UTF8);
            srEntireFile_v4 = srReader.ReadToEnd();
            srReader.Close();

            string srEntireFile_v5 = "";
            srReader = new StreamReader("writeAsStream_append_auto_flush.txt", Encoding.UTF8);
            while(true)
            {
                string srNewline = srReader.ReadLine();
                if (string.IsNullOrEmpty(srNewline) == true)
                    break;
                srEntireFile_v5 += srNewline;
            }
            srReader.Close();
        }
    }
}

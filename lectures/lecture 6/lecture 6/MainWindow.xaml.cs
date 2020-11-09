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

namespace lecture_6
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
            string MyTestString = "hello world";

            //MessageBox.Show(MyTestString);

            //this one is same as below one
            for (int irStartingIndex = 0; irStartingIndex < 10; irStartingIndex++)
            {

            }

            List<int> lstLoopedNumbers = new List<int>();

            //this one is same as above one
            for (int irStartingIndex = 1; irStartingIndex < 10; irStartingIndex = irStartingIndex + 1)
            {
                lstLoopedNumbers.Add(irStartingIndex);
            }

            lstLoopedNumbers.Clear();

            for (int irStartingIndex = -2; irStartingIndex < 10; irStartingIndex = irStartingIndex + 1)
            {
                lstLoopedNumbers.Add(irStartingIndex);
            }

            lstLoopedNumbers.Clear();

            for (int irStartingIndex = 0; irStartingIndex < 10; irStartingIndex = irStartingIndex + 2)
            {
                lstLoopedNumbers.Add(irStartingIndex);
            }

            //guess which values would the lstLoopedNumbers contain?
            //0 2 4 6 8 

            lstLoopedNumbers.Clear();

            //this checks condition whether smaller or equal to
            for (int irStartingIndex = 0; irStartingIndex <= 10; irStartingIndex = irStartingIndex + 2)
            {
                lstLoopedNumbers.Add(irStartingIndex);
            }

            //guess which values would the lstLoopedNumbers contain?
            //0 2 4 6 8 10

            lstLoopedNumbers.Clear();

            for (int irStartingIndex = 0; irStartingIndex <= 10; irStartingIndex = irStartingIndex + 3)
            {
                lstLoopedNumbers.Add(irStartingIndex);
                irStartingIndex--; // irStartingIndex=irStartingIndex-1;
            }

            //0 2 4 6 8 10

            lstLoopedNumbers.Clear();


            //so key here is, whenever this conditions become false, the loop ends immediately
            // irStartingIndex > 10;
            for (int irStartingIndex = 100; irStartingIndex > 10; irStartingIndex = irStartingIndex - 10)
            {
                lstLoopedNumbers.Add(irStartingIndex);
            }

            // 100 90 80 70 60 50 40 30 20 

            lstLoopedNumbers.Clear();

            for (
                    int irStartingIndex = 100;
                        irStartingIndex > 10;
                            irStartingIndex = irStartingIndex / 2
                )
            {
                lstLoopedNumbers.Add(irStartingIndex);
            }

            // 100 50 25 12  

            lstLoopedNumbers.Clear();

            int irCommonIndex = 100;//this is definition

            //this for loop will work like above
            for (; irCommonIndex > 10; irCommonIndex = irCommonIndex / 2)
            {
                lstLoopedNumbers.Add(irCommonIndex);
            }

            lstLoopedNumbers.Clear();

            irCommonIndex = 100;//this is value assigment / setting / initilization

            //this loop would run forever because the condition would never become false
            //for (; irCommonIndex > 10;)
            //{
            //    lstLoopedNumbers.Add(irCommonIndex);
            //}


            for (; irCommonIndex > 10;)
            {
                lstLoopedNumbers.Add(irCommonIndex);
                irCommonIndex = irCommonIndex / 2;
            }

            //the last index of the list is equal to number of elements inside list - 1
            //because index starts from 0 not 1
            for (int i = 0; i < lstLoopedNumbers.Count; i++)
            {
                MessageBox.Show(lstLoopedNumbers[i].ToString());
            }

            //this below equals to above
            //works only if there is a single line command after the for loop or if else,etc.
            for (int i = 0; i < lstLoopedNumbers.Count; i++)
                MessageBox.Show(lstLoopedNumbers[i].ToString());

            for (int i = 0; i < lstLoopedNumbers.Count; i++)
            {
                MessageBox.Show(lstLoopedNumbers[i].ToString());
                if (i == 1)
                    break;
            }
        }

        private void btnForEachExample_Click(object sender, RoutedEventArgs e)
        {
            List<string> myAnimalsList = new List<string> { "cat", "mouse", "dog", "lion" };
            myAnimalsList.AddRange(new List<string> { "bird", "eagle" });
            myAnimalsList.Add("fox");
            myAnimalsList.Add("owl");

            foreach (var vrMyAnimal in myAnimalsList)
            {

            }

            foreach (string srMyAnimal in myAnimalsList)
            {
                //  MessageBox.Show(srMyAnimal);
            }

            //this would throw error
            //foreach (string srMyAnimal in myAnimalsList)
            //{
            //    myAnimalsList.Add("new animal");
            //}

            //this below would throw enumeration modified error while looping
            //foreach (string srMyAnimal in myAnimalsList)
            //{
            //   if(srMyAnimal=="lion")
            //    {
            //        myAnimalsList[7] = "burrowing owl";
            //    }
            //}

            //this below would work because now the foreach loop is looping through a different new list than original myAnimalsList
            //this below basically composes a deep copy (deep clone) of original array and loops through it
            foreach (string srMyAnimal in myAnimalsList.ToList())
            {
                if (srMyAnimal == "lion")
                {
                    myAnimalsList[7] = "burrowing owl";
                }

                if (srMyAnimal == "lion")
                {
                    break;
                }
            }

            //this also works to modify original array
            for (int i = 0; i < myAnimalsList.Count; i++)
            {
                if (i == 2)
                {
                    myAnimalsList.Insert(3, "new animal");
                }

                //   MessageBox.Show(myAnimalsList[i]);
            }

            //if you are not going to modify the enumerated the list / array foreach is better than for loop

            int[,] twoDimensionArray = new int[,]
                { { 1,2,3} , { 4,5,6 } };

            //both arrays are equal

            int[,] twoDimensionArray_v2 = new int[2, 3]
              { { 1,2,3} , { 4,5,6 } };


        }

        private void btnWhileExample_Click(object sender, RoutedEventArgs e)
        {
            int irCounter = 0;

            //when condition is set to be true, the while loop runs forever until the loop is broken with a break
            while (true)
            {
                // MessageBox.Show(irCounter.ToString());

                if (irCounter % 5 == 0 && irCounter > 0)
                    break;

                irCounter++;
            }

            //when condition is set to something else than true, the while loop runs forever until the condition becomes false

            irCounter = 0;
            while (irCounter < 6)
            {
                //  MessageBox.Show(irCounter.ToString());

                irCounter++;
            }

            irCounter = 6;
            while (irCounter < 6)
            {
                MessageBox.Show(irCounter.ToString());

                irCounter++;
            }

        }

        private void btnDoWhileLoop_Click(object sender, RoutedEventArgs e)
        {
            int irCounter = 0;
            do
            {
                // MessageBox.Show(irCounter.ToString());

                irCounter++;
            } while (irCounter < 6);

            irCounter = 6;
            do
            {
                MessageBox.Show(irCounter.ToString());

                irCounter++;
            } while (irCounter < 6);

        }

        private void btnThreadsleepExample_Click(object sender, RoutedEventArgs e)
        {
            _labelCounter.Content = "test content";

            int irCounter = 0;

            int irDefaultSleepMs = 500;

            int irThreadSleepMs = irDefaultSleepMs;

            bool blParsingResult = int.TryParse(txtSleepMs.Text, out irThreadSleepMs);

            //if input string is not a numerical value that can be converted to integer
            //this below code causes unhandled exception. therefore using try parse method is much better
            //irThreadSleepMs = Convert.ToInt32(txtSleepMs.Text);

            //alternatively we can use try catch however it is more expansive than try parse

            //this try catch would prevent application crash however this is more expensive in terms of system resources usage than try parse method. the try parse method is the appropriate way
            try
            {
                irThreadSleepMs = Convert.ToInt32(txtSleepMs.Text);
            }
            catch
            {
                irThreadSleepMs = irDefaultSleepMs;
            }

            if (!blParsingResult) // so this is equal to  if (blParsingResult==false)
                irThreadSleepMs = irDefaultSleepMs;

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    _labelCounter.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        _labelCounter.Content = irCounter.ToString();
                    }));

                    System.Threading.Thread.Sleep(irThreadSleepMs);
                    irCounter++;
                }
            });


            //List<string> lstDates = new List<string>();

            //for (int i = 0; i < 10; i++)
            //{
            //    lstDates.Add(DateTime.Now.ToString());
            //    System.Threading.Thread.Sleep(2 * 1000);
            //}


        }

        //until any method call get executed, the calling thread of that method is frozen. in button clicks, the ui thread is the calling thread therefore it is frozen until the click method is fully executed. therefore, in below example, the ui will not be updated until entire for loop ends. so, we will see only the 9 as the label content at the end
        private void btnSimpleUpdateUserInterface_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                _labelCounter.Content = i.ToString();

                System.Threading.Thread.Sleep(500);
            }
        }

        //pressing ctrl k then ctrl d organize the code
    }
}

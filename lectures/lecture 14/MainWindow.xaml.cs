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
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace lecture_14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string seperateKey = "3830c08609c2bdd736f077121fb74b10e5dc4d1a0ec531cd9364fdd291757218";
        private readonly string lineStartKey = "ec3d00212250fb995d08c5a0692febc3fedb243281eb3defe45fa3fbf992c23f";
        //using named variables for constant values

        public MainWindow()
        {
            InitializeComponent();
            listBoxResults.ItemsSource = UserLogs;
            startTimer();
            initToolTips();
        }

        private  void initToolTips()
        {
            btnSave.ToolTip = "this will append your input to the end of your username logs. if no logs exists, it will compose a new logs file";
        }

        private static DateTime dtApplicationStartDate = DateTime.Now;

        private void startTimer()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Start();
        }

        int irMethodCall = 1;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = $"({irMethodCall}) the application were running since " + (DateTime.Now - dtApplicationStartDate).TotalMilliseconds.ToString("N0") + " mili seconds";
            irMethodCall++;
        }

        private ObservableCollection<string> _Results = new ObservableCollection<string>();
        public ObservableCollection<string> UserLogs
        {
            get { return _Results; }
            set
            {
                _Results = value;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string srFilePath = null;
            //if (checkValidFileName(txtUserName.Text, ref srFilePath) == false)
            if (txtUserName.Text.CheckUserNameValidty() == false)
                return;

            srFilePath = txtUserName.Text.composeUserfilePath();

            File.AppendAllText(srFilePath, lineStartKey + DateTime.Now + seperateKey + txtUserInput.Text + "\r\n");

            UserLogs.Insert(0, static_classes.formatUserLog(UserLogs.Count + 1, DateTime.Now.ToString(), txtUserInput.Text));

            txtUserInput.Text = "";
        }

        private static int irLineNumberOfUserLogs = 0;

        private void load_logs(object sender, RoutedEventArgs e)
        {
            var vrFilePath = txtUserName.Text.composeUserfilePath();

            if (!File.Exists(vrFilePath))
            {
                MessageBox.Show("no logs available for entered username!");
                return;
            }

            string[] userArray = File.ReadAllText(vrFilePath).Split(lineStartKey).Where(perElementOfMyList => perElementOfMyList.Length > 0).ToArray();
            Array.Reverse(userArray);

            UserLogs.Clear();

            irLineNumberOfUserLogs = userArray.Length;

            foreach (var vrPerUserInput in userArray)
            {
                var userInputSeperated = vrPerUserInput.Split(seperateKey);
                UserLogs.Add(static_classes.formatUserLog(irLineNumberOfUserLogs, userInputSeperated[0],
                    userInputSeperated[1]));
                irLineNumberOfUserLogs--;
            }

        }


        //this method has flaws and not working correctly when user enters : as username
        private static bool checkValidFileName(string srUserName, ref string srFilePath)
        {
            srFilePath = srUserName.composeUserfilePath();

            if (File.Exists(srFilePath))
                return true;

            try
            {
                File.WriteAllText(srFilePath, "");
            }
            catch
            {
                MessageBox.Show("invalid username is entered");
                return false;
            }

            File.Delete(srFilePath);
            return true;
        }

        static Dictionary<int, double> dicIntDoubleVals = new Dictionary<int, double>();
        List<Tuple<int, double>> listIntDoubleVals = new List<Tuple<int, double>>();

        private void btnInitNumbers_Click(object sender, RoutedEventArgs e)
        {
            Random myRand = new Random();

            for (int i = 0; i < 20000000; i++)
            {
                double myRandDouble = myRand.NextDouble();
                dicIntDoubleVals.Add(i, myRandDouble);
                listIntDoubleVals.Add(new Tuple<int, double>(i, myRandDouble));
            }
        }

        private void dictionary_test(object sender, RoutedEventArgs e)
        {
            int irTestKey = Convert.ToInt32(txtKey.Text);

            Stopwatch testWatch = new Stopwatch();
            testWatch.Start();
            if (dicIntDoubleVals.ContainsKey(irTestKey))
            {
                var val = dicIntDoubleVals[irTestKey];
            }
            testWatch.Stop();
            var vrTimeForDictionary = testWatch.ElapsedTicks;// with ticks we get 10000 more presicement because 1 miliseconds = 10000 ticks

            testWatch.Reset();//you have to reset or it continues from where it left
            testWatch.Start();
            var vrVal2 = listIntDoubleVals.Where(pr => pr.Item1 == irTestKey).FirstOrDefault();

            testWatch.Stop();
            var vrTimeForList = testWatch.ElapsedTicks;

            UserLogs.Insert(0, @$"time passed for dictionary: ticks: {vrTimeForDictionary.ToString("N0")}

{(vrTimeForDictionary/10000).ToString("N0")} ms

for list: {vrTimeForList.ToString("N0")}

{(vrTimeForList / 10000).ToString("N0")} ms

list calculation took {(vrTimeForList/ vrTimeForDictionary).ToString("N0")} times more");
        }
    }
}

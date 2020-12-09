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
using System.Net.Http;
using System.Net;

namespace lecture_9
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

        private void btnFileStream_Click(object sender, RoutedEventArgs e)
        {
            FileStream fl = new FileStream("source_Code_of_toros.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);



            var wbClient = new WebClient();
            var url = "https://www.toros.edu.tr/";
            byte[] sourceCodeBytes = wbClient.DownloadData(url);
            fl.Write(sourceCodeBytes, 0, sourceCodeBytes.Length);

            fl.Close();
            fl.Dispose();
            wbClient.Dispose();//the dispose will dispose that object and free all of the resources it uses
            //network or input output related objects should get disposed of as soon as possible once their job is finished

            string srFile = "gg";

            var httpClient = new HttpClient();
            url = "https://www.toros.edu.tr/toros/images/favicon/apple-icon-180x180.png";
            sourceCodeBytes = wbClient.DownloadData(url);

            var fs = new FileStream("favicon.ico", FileMode.Create);
            fs.Write(sourceCodeBytes, 0, sourceCodeBytes.Length);

            fs.Close();

            using (var wbb2 = new WebClient())
            {
                string srTempFileName = "apple_logo.png";
                wbb2.DownloadFile("https://www.toros.edu.tr/toros/images/favicon/apple-icon-180x180.png", srTempFileName);
            }

            // wbb2. this does not exists after the scope of using and it is always disposed off properly
            // srTempFileName this does not exists after scope of using as well

            //when you should use using?
            //when you are working with hard drive manipulating objects such as streamwriter, file stream, or when you are working with database modifying objects or when you are working with network related objects such as WebClient HttpClient etc.

            //should you use FileStream? no. use StreamWriter or File.Write, read, etc.
            //use file stream only when it is absolutely necessary
        }

        private void btnReadImagesAsBytes_Click(object sender, RoutedEventArgs e)
        {
            FileStream fsRead = new FileStream("picture.png", FileMode.Open, FileAccess.Read, FileShare.None);

            //file stream is lowest level programming

            List<byte> lstBytes = new List<byte>();

            while (true)
            {
                var vrByte = fsRead.ReadByte();
                if (vrByte == -1)
                    break;
                lstBytes.Add(Convert.ToByte(vrByte));
            }

            fsRead.Close();

            var vrBytesAll = File.ReadAllBytes("picture.png").ToList();
        }

        private void btnGoToRegisterTab_Click(object sender, RoutedEventArgs e)
        {
            //tabRegister.IsSelected = true;
            tabRegister.Focus();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            int irActualNumberOfTabs = menuTabs.Items.Count - 2;
            if (menuTabs.SelectedIndex == 0)
            {
                menuTabs.SelectedIndex = irActualNumberOfTabs - 1;
            }
            else
                menuTabs.SelectedIndex--;//this is equal to  menuTabs.SelectedIndex= menuTabs.SelectedIndex-1;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int irActualNumberOfTabs = menuTabs.Items.Count - 2;
            if (menuTabs.SelectedIndex == irActualNumberOfTabs - 1)
            {
                menuTabs.SelectedIndex = 0;
            }
            else
                menuTabs.SelectedIndex++;

        }
    }
}

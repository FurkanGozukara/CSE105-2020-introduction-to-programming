using System;
using System.Collections.Generic;
using System.Threading;

namespace lecture_3
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime myDate = DateTime.Now;

            Console.WriteLine("ShortTime pattern (t) is below");
            var vrFormattedString = return_formatted_DateTime(myDate, "{0:t}");
            Console.WriteLine(vrFormattedString);

            Console.WriteLine("LongTime pattern (T) is below");
            vrFormattedString = return_formatted_DateTime(myDate, "{0:T}");
            Console.WriteLine(vrFormattedString);

            List<string> lstMyList = new List<string>();
            lstMyList.Add("Furkan");
            lstMyList.Add("Gözükara");
            lstMyList.Add("furkan.gozukara@toros.edu.tr");
            lstMyList.Add("Toros University");

            //in c#, indexes always start from 0 for the first element in all lists arrays and such objects

            Console.WriteLine("firt way: \tmy name is {0}, my surname is {1}, my email is {2}", lstMyList[0],
                lstMyList[1],
                lstMyList[2]);

            string srSentence = string.Format("second way: \tmy name is {0}, my surname is {1}, my email is {2}", lstMyList[0],
                lstMyList[1],
                lstMyList[2],
                lstMyList[3]);

            Console.WriteLine(srSentence);

            srSentence = string.Format("third way: \tmy school is {3}, my name is {0}, my surname is {1}, my email is {2}", lstMyList[0],
                lstMyList[1],
                lstMyList[2],
                lstMyList[3]);

            Console.WriteLine(srSentence);

            srSentence = string.Format("fourth way: \tmy school is {0}", lstMyList[3],
    lstMyList[1],
    lstMyList[2],
    lstMyList[3]);

            Console.WriteLine(srSentence);

            srSentence = string.Format("fith way: \tmy name twice times is {0} {0}, my school name 3 times is {1} {1} {1}", lstMyList[0],
lstMyList[3],
lstMyList[2],
lstMyList[3]);

            Console.WriteLine(srSentence);

            srSentence = $"sixth way: \tmy name twice times is {lstMyList[0]} {lstMyList[0]}, my school name 3 times is {lstMyList[3]} {lstMyList[3]} {lstMyList[3]}";

            Console.WriteLine(srSentence);

            //this is string concatenation
            srSentence = "seventh way: \tmy name twice times is " + lstMyList[0] + " " + lstMyList[0] + ", my school name 3 times is " + lstMyList[3] + " " + lstMyList[3] + " " + lstMyList[3];

            //ctrl + k + d at the same time. it automatically formats the code

            Console.WriteLine(srSentence);

            //date time formatting : https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
            Console.WriteLine("dd = day of the month from 01, dddd The full name of the day of the week, hh = using a 12-hour clock from 01 to 12.");

            vrFormattedString = return_formatted_DateTime(myDate, "{0:dd dddd hh}");

            Console.WriteLine(vrFormattedString);

            Console.WriteLine("mm = The minute, from 00 through 59 , MMMM = The full name of the month , tt = The AM/PM designator.");

            vrFormattedString = return_formatted_DateTime(myDate, "{0:MMMM mm tt}");

            Console.WriteLine(vrFormattedString);

            Console.WriteLine("current date minute: " + DateTime.Now.Minute);
            Console.WriteLine("seconds of myDate : " + myDate.Second);
            Console.WriteLine("year of myDate : " + myDate.Year);

            DateTime myPlus355Hours = myDate.AddHours(355.32);

            vrFormattedString = "current date is : " + return_formatted_DateTime(myDate, "{0:yyyy MMMM dd dddd HH mm tt}");

            Console.WriteLine(vrFormattedString);

            vrFormattedString = "date is after 355.32 hours : " + return_formatted_DateTime(myPlus355Hours, "{0:yyyy MMMM dd dddd HH mm tt}");

            Console.WriteLine(vrFormattedString);

            var myNumber = 32.54 + " 54.320";

            Console.WriteLine("double + string = " + myNumber);

            var myNumber2 = 32.54 + 32;

            Console.WriteLine("double + int = " + myNumber2);

            var myNumber3 = DateTime.Now + new TimeSpan(355, 32, 11);

            Console.WriteLine("datetime + time span = " + myNumber3);

            var myNumber4 = 32.544324123455 + 32;

            myNumber4 = Math.Round(myNumber4, 2);

            Console.WriteLine("fixed double + int = " + myNumber4);

            myNumber4 = 32.544324123455 + 32;

            Console.WriteLine("string formatted double + int = " + myNumber4.ToString("N3"));

            Console.WriteLine("string formatted double + int = " + myNumber4.ToString("N0"));

            var vrFlooredNumber = Math.Floor(myNumber4);

            Console.WriteLine("floored double = " + vrFlooredNumber);

            Console.WriteLine("integer 7/2 = {0}", 7 / 2);

            Console.WriteLine("integer (integers are always floored) 26/3 = {0}", 26 / 3);

            Console.WriteLine("current culture of the thread is : "
                + Thread.CurrentThread.CurrentCulture.Name);

            double dblTest = 2312132.5544;
            Console.WriteLine("2312132.5544 printed in en-US culture: " + dblTest.ToString("N2"));
            Console.WriteLine(DateTime.Now);

            string srFirstVal = "3,543,554.32";
            string srSecondVal = "3.543.554,32";

            var dblConverted1 = Convert.ToDouble(srFirstVal);
            var dblConverted2 = 0.0;

            double.TryParse(srSecondVal, out dblConverted2);

            Console.WriteLine("in en-US {0} is converted to a double as {1} and {2} is converted to a double as {3}",
                srFirstVal, dblConverted1, srSecondVal, dblConverted2);

            //ctrl k then ctrl d


            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");

            Console.WriteLine("current culture of the thread is : "
            + Thread.CurrentThread.CurrentCulture.Name);
            Console.WriteLine("2312132.5544 printed in tr-TR culture: " + dblTest.ToString("N2"));
            Console.WriteLine(DateTime.Now);

            dblConverted1 = -1.0;
            dblConverted2 = -1.0;

            bool blResult1 = double.TryParse(srFirstVal, out dblConverted1);
            bool blResult2 = double.TryParse(srSecondVal, out dblConverted2);

            if (blResult1 == false)
            {
                dblConverted1 = -2;
            }
            if (blResult2 == false)
            {
                dblConverted2 = -3;
            }

            Console.WriteLine("in tr-TR {0} is converted to a double as {1} and {2} is converted to a double as {3}",
                srFirstVal, dblConverted1, srSecondVal, dblConverted2);

        }

        //private means is accesbility level
        //In general, a static modifier can be used with data and functions that do not require an instance of a class to be accessed.It is mostly used when the data and behavior of a class do not depend on object identity.The use of static classes and members improves code efficiency.
        //string means that the method will return an object in string type
        private static string return_formatted_DateTime(DateTime myDateTime, string srDateFormat)
        {
            return string.Format(srDateFormat, myDateTime);
        }
    }
}

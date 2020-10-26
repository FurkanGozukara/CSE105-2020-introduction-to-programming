using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace lecture_4___arrays
{
    class Program
    {

        //https://www.w3schools.com/cs/cs_arrays.asp
        static void Main(string[] args)
        {
            string[] cars;//this is declared but never used

            string[] cars2 = { "Volvo", "Volvox", "BMW01", "BMW00", "Ford", "Mazda" };

            Console.WriteLine("the maximum value in cars2 array = " + cars2.Max());

            Console.WriteLine("the minimum value in cars2 array = " + cars2.Min());


            string srCars2Joined = string.Join(" : ", cars2);

            Console.WriteLine($"case 1 : the values in cars2 array unsorted : {srCars2Joined}");
            Console.WriteLine($"case 2 : the values in cars2 array unsorted : {{srCars2Joined}}");
            Console.WriteLine($"case 3 : the values in cars2 array unsorted : {{{srCars2Joined}}}");

            //below string concatenation equals to : string srCars2Joined = string.Join(" : ", cars2);
            string srCars2Joined_v2 = cars2[0] + " : " + cars2[1] + " : " + cars2[2]
                + " : " + cars2[3] + " : " + cars2[4] + " : " + cars2[5];

            string srCarsJoined_v3 = "";

            for (int irStartingSeed = 0; irStartingSeed < cars2.Length; irStartingSeed++)
            {
                Console.WriteLine("for looping and currently irStartingSeed = " + irStartingSeed);

                //srCarsJoined_v3+= means srCarsJoined_v3=srCarsJoined_v3+
                srCarsJoined_v3 += cars2[irStartingSeed];
                if ((irStartingSeed + 1) < cars2.Length)
                {
                    srCarsJoined_v3 = srCarsJoined_v3 + " : ";
                }
            }

            Console.WriteLine("foreach loop output");
            foreach (string srValue in cars2)
            {
                Console.WriteLine("===");
                Console.WriteLine("output srValue: " + srValue);
                Console.WriteLine("===");
            }

            string srCarsJoined_v4 = "";
            int irCounter = 0;
            foreach (string srValue in cars2)
            {
                srCarsJoined_v4 += srValue;
                if ((irCounter + 1) < cars2.Length)
                    srCarsJoined_v4 += " : ";
                irCounter++;
            }

            string srCarsJoined_v5 = "";
            foreach (string srValue in cars2)
            {
                srCarsJoined_v5 += srValue + " : ";
            }

            srCarsJoined_v5 = srCarsJoined_v5.Substring(0, srCarsJoined_v5.Length - (" : ".Length));

            string srName = "ABCD";

            Console.WriteLine("how many characters do srName have = " + srName.Length);
            Console.WriteLine("srName.Substring(0) = " + srName.Substring(0));
            Console.WriteLine("srName.Substring(1) = " + srName.Substring(1));
            Console.WriteLine("srName.Substring(1,1) = " + srName.Substring(1, 1));
            Console.WriteLine("srName.Substring(1,2) = " + srName.Substring(1, 2));
            Console.WriteLine("srName.Substring(2,1) = " + srName.Substring(2, 1));
            Console.WriteLine("srName.Substring(2) = " + srName.Substring(2));

            string[] cars3 = new string[10];

            Console.WriteLine("default value of string array is :" + cars3[0]);

            //how to print BMW to the screen?
            //every arrays or lists or enumarable variables in c# starts index from 0 not 1
            Console.WriteLine(cars2[1]);//this will print BMW to the screen

            int[] irArrayNull;

            int[] irArray5 = new int[5];

            Console.WriteLine("default value of int array is :" + irArray5[0]);

            int[] irMyValues = new int[32];

            char[] charArray = new char[10];

            Console.WriteLine("default value of char array is :" + charArray[0]);

            //default values of different object types
            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/default-values

            charArray[5] = 'F';

            Console.WriteLine("the sixth character of the char array = " + charArray[5]);

            int[] myArray2 = new int[] { 32, 12, 455, 1255, 55 };

            Console.WriteLine("the first number of the myArray2 array = " + myArray2[0]);

            Console.WriteLine("lenght of myArray2 array = " + myArray2.Length);

            //since this is single dimension array lenght = number of elements in that array
            Console.WriteLine("number of objects in myArray2 array = " + myArray2.Length);

            Console.WriteLine("the maximum number in myArray2 array = " + myArray2.Max());

            Console.WriteLine("the minimum number in myArray2 array = " + myArray2.Min());

            Console.Clear();
            Console.WriteLine("the console is cleared");

            Random myRandGenerator = new Random();
            int irMyRand = myRandGenerator.Next();
            //N0 means add thousands seperator with 0 floating point precision
            Console.WriteLine("single random number = " + irMyRand.ToString("N0"));
            int[] myHundredElemetsArray = new int[100];

            // \t is special tab character
            string srPrint = string.Join("\t", myHundredElemetsArray);

            Console.WriteLine("myHundredElemetsArray before assigning random numbers:" + Environment.NewLine + srPrint);

            //because c# is case sensitive Length is correct spelling. length would give error
            for (int irArrayIndex = 0; irArrayIndex < myHundredElemetsArray.Length; irArrayIndex++)
            {
                myHundredElemetsArray[irArrayIndex] = myRandGenerator.Next(0,10000);
            }

            srPrint = string.Join("\t", myHundredElemetsArray);

            Console.WriteLine("myHundredElemetsArray after assigning random numbers without thousand seperator formatting:" + Environment.NewLine + srPrint);

            srPrint = "";
            for (int irStartingSeed = 0; irStartingSeed < myHundredElemetsArray.Length; irStartingSeed++)
            {
                srPrint += myHundredElemetsArray[irStartingSeed].ToString("N0");
                if ((irStartingSeed + 1) < myHundredElemetsArray.Length)
                {
                    srPrint = srPrint + "\t";
                }
            }

            Console.WriteLine("myHundredElemetsArray after assigning random numbers:" + Environment.NewLine + srPrint);

            Array.Sort(myHundredElemetsArray);

            //this part is called as  LinQ : .Select(pr => pr.ToString("N0")));
            srPrint = string.Join("\t", myHundredElemetsArray.Select(pr => pr.ToString("N0")));

            Console.WriteLine("myHundredElemetsArray after sorting ascending :" + Environment.NewLine + srPrint);

            Array.Sort(myHundredElemetsArray);//sorts by ascending
            Array.Reverse(myHundredElemetsArray);//reverses the list therefore sorted by ascending becomes sorted by descending

            srPrint = string.Join("\t", myHundredElemetsArray.Select(pr => pr.ToString("N0")));
            Console.WriteLine("myHundredElemetsArray after sorting descending :" + Environment.NewLine + srPrint);

            //once the array is initalized you can not change its size / dimension unless you initialize it again

            //myHundredElemetsArray[100] = 23124;// this will not work since array is initalized as 100 elements
            //System.IndexOutOfRangeException: 'Index was outside the bounds of the array.'

            int[] mySecondArray = new int[101];
            myHundredElemetsArray.CopyTo(mySecondArray,0);
            mySecondArray[100] = 231244;

            myHundredElemetsArray = new int[101];// this reinitialize the array with 101 storage
            myHundredElemetsArray[100] = 231244;

            //my matrix is  3,1,2 first row
            //5,8,9 is second row
            //third row is 12,65,86

            int[,] arryTwoDimensional = new int[4, 5];

            arryTwoDimensional[0, 0] = 3;
            arryTwoDimensional[0, 1] = 1;
            arryTwoDimensional[0, 2] = 2;
            arryTwoDimensional[1, 0] = 5;
            arryTwoDimensional[1, 1] = 8;
            arryTwoDimensional[1, 2] = 9;
            arryTwoDimensional[2, 0] = 12;
            arryTwoDimensional[2, 1] = 65;
            arryTwoDimensional[2, 2] = 86;

            Console.WriteLine("number of all elements inside arryTwoDimensional = " + arryTwoDimensional.Length);

            Console.WriteLine("arryTwoDimensional.GetLength(0) = " + arryTwoDimensional.GetLength(0));

            Console.WriteLine("arryTwoDimensional.GetLength(1) = " + arryTwoDimensional.GetLength(1));

            for (int irFirstDimension = 0; irFirstDimension < arryTwoDimensional.GetLength(0); irFirstDimension++)
            {
                for (int irSecondDimension = 0; irSecondDimension < arryTwoDimensional.GetLength(1); irSecondDimension++)
                {
                    Console.WriteLine($"[{irFirstDimension}:{irSecondDimension}] = {arryTwoDimensional[irFirstDimension, irSecondDimension]}");
                }
            }

            arryTwoDimensional = new int[,] { { 3, 1, 2 }, { 5, 8, 9 }, { 12, 65, 86 } };

            int[,,] arryThreeDimensional = new int[,,] { 
                { { 3, 1, 2 },{32,8,87 } }
                , { { 46, 76, 11 }, { 675, 213, 2673 } }
                  , { { 3246, 456, 2131 }, { 656, 7867, 563 } }
                  , { { 2345, 78, 78768 }, { 456, 234, 54654 } }
            };

            Console.WriteLine("printing arryThreeDimensional");
            foreach (var vrPerValue in arryThreeDimensional)
            {
                Console.Write(vrPerValue+"\t");
            }
            Console.Write("\n");

            for (int irDimensionCount = 0; irDimensionCount < arryThreeDimensional.Rank; irDimensionCount++)
            {
                Console.WriteLine($"arryThreeDimensional.GetLength({irDimensionCount}) = " + arryThreeDimensional.GetLength(irDimensionCount));
            }

            for (int irFirstDimension = 0; irFirstDimension < arryThreeDimensional.GetLength(0); irFirstDimension++)
            {
                for (int irSecondDimension = 0; irSecondDimension < arryThreeDimensional.GetLength(1); irSecondDimension++)
                {
                    for (int irThirdDimension = 0; irThirdDimension < arryThreeDimensional.GetLength(2); irThirdDimension++)
                    {
                        Console.WriteLine($"[{irFirstDimension}:{irSecondDimension}:{irThirdDimension}] = {arryThreeDimensional[irFirstDimension, irSecondDimension, irThirdDimension]}");
                    }
                }
            }

            Console.ReadLine();


        }
    }
}

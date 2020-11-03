using System;
using System.Collections.Generic;

namespace lecture_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //firstPartofLecture();

            int[,] irTwoDimensional = new int[32, 64];

            int[][] irJaggedArray = new int[32][];

            Random myRand = new Random();

            for (int i = 0; i < irJaggedArray.GetLength(0); i++)
            {
                irJaggedArray[i] = new int[myRand.Next(1, 100)];
            }

            int[][][,][,,] irJaggedArray_v2 = new int[32][][,][,,];

            irJaggedArray_v2[3] = new int[10][,][,,];

            irJaggedArray_v2[3][4] = new int[2, 2][,,];

            irJaggedArray_v2[3][4][1, 1] = new int[5, 4, 3];

            //Why we have both jagged array and multidimensional array?
            //https://stackoverflow.com/questions/4648914/why-we-have-both-jagged-array-and-multidimensional-array

            int[] irMySimpleArray = new int[] { 3, 5, 11, 12 };

            //how to remove element 5 from the array?
            //how to add new element 8 to the array?
            //both are not possible without array copy and initilization of new array
            //so what I can use instead?
            //I can use lists which are dynamic array

            List<int> lstMyIntList = new List<int>();

            lstMyIntList.Add(3);
            lstMyIntList.Add(5);
            lstMyIntList.Add(11);
            lstMyIntList.Add(12);
            lstMyIntList.Add(5);
            lstMyIntList.Add(3);

            lstMyIntList.Remove(5);//it will remove the 5 at the index 1
            lstMyIntList.RemoveAt(lstMyIntList.Count - 1);//so this will remove the last element of the list

            int[] irArrayofList = lstMyIntList.ToArray();
            var vrArrayOfList = lstMyIntList.ToArray();

            //you can use var keyword for anything. it will automatically detect the type/class of left side of assigment

            lstMyIntList.AddRange(new List<int> { 100, 200, 300 });

            lstMyIntList.AddRange(lstMyIntList);

            var vrList2 = new List<int> { 6, 7, 8, 9 };

            lstMyIntList.AddRange(vrList2);

            bool blResult = lstMyIntList.Contains(200);

            Console.WriteLine("lstMyIntList contains 200 or not? : " + blResult);

            blResult = lstMyIntList.Contains(2010);

            Console.WriteLine("lstMyIntList contains 2010 or not? : " + blResult);

            int[] irArrayCopyList = new int[lstMyIntList.Count];

            lstMyIntList.CopyTo(irArrayCopyList);

            lstMyIntList.RemoveRange(3, 2);

            lstMyIntList.Reverse();

            lstMyIntList.Sort();//sorts by ascending the list

            lstMyIntList.Reverse();//after sorting by ascending if you reverse the list you get descending order

            lstMyIntList.RemoveAll(pr => pr > 5);//we use lambda expression here - we will see them in future lessons but get an idea know

            blResult = lstMyIntList.Exists(pr => pr == 5);
            blResult = lstMyIntList.Exists(pr => pr == 15);

            lstMyIntList[1] = 32;

            lstMyIntList.Clear();

            Console.Clear();//this clears the console screen

            foreach (var vrPerItem in lstMyIntList)
            {
                Console.WriteLine("per item: " + vrPerItem);
            }

            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators

            int A = 12, B = 20;

            //variables are case sensitive in C# therefore a!=B
            if (A == B)//equality
            {
                Console.WriteLine("A is equal to B");
            }
            else
            {
                Console.WriteLine("A is not equal to B");
            }

            if (A > B)//bigger
            {
                Console.WriteLine("A is bigger than B");
            }
            else
            {
                Console.WriteLine("A is not bigger than B");
            }

            if (A >= B)//bigger or equal
            {
                Console.WriteLine("A is bigger than or equal to B");
            }
            else
            {
                Console.WriteLine("A is not bigger than or equal B");
            }

            bool blABOpResult;

            if (A >= B)
            {
                blABOpResult = true;
            }
            else
                blABOpResult = false;

            if (A >= B)
                blABOpResult = true;//you dont have to put curly bracket { if assigment or operation is single line
            else
                blABOpResult = false;//you dont have to put curly bracket { if assigment or operation is single line

            if (blABOpResult)// if boolean variable is true which  is the condition checked
            {
                Console.WriteLine("blABOpResult is true");
            }

            if (blABOpResult == true)//this line equals above if check
            {
                Console.WriteLine("blABOpResult is true");
            }

            // ! Unary ! (logical negation) operator.
            if (!blABOpResult)//if blABOpResult is not true
            {
                Console.WriteLine("blABOpResult is false");
            }

            if (blABOpResult == false)//this line equals above if check
            {
                Console.WriteLine("blABOpResult is false");
            }

            bool passed = false;
            Console.WriteLine(!passed);  // output: True
            Console.WriteLine(!true);    // output: False


            bool blTrue = true, blFalse = false;

            Console.WriteLine("blTrue & blFalse : " + (blTrue & blFalse));//Logical AND operator & : result false
            Console.WriteLine("blTrue | blFalse : " + (blTrue | blFalse));//Logical OR operator | : result true

            // Logical exclusive OR operator ^
            Console.WriteLine("true ^ true : " + (true ^ true));   // result is false 
            Console.WriteLine("true ^ false : " + (true ^ false));  // result is true  
            Console.WriteLine("false ^ true : " + (false ^ true));  // result is true 
            Console.WriteLine("false ^ false : " + (false ^ false));// result is false 


            // Logical AND operator &
            Console.WriteLine("true & true : " + (true & true)); // result is true 
            Console.WriteLine("true & false : " + (true & false)); // result is false 
            Console.WriteLine("false & true : " + (false & true)); // result is false 
            Console.WriteLine("false & false : " + (false & false)); // result is false 


            // Logical OR operator |
            Console.WriteLine("true | true : " + (true | true)); // result is true 
            Console.WriteLine("true | false : " + (true | false)); // result is true 
            Console.WriteLine("false | true : " + (false | true)); // result is true 
            Console.WriteLine("false | false : " + (false | false)); // result is false 

            //Conditional logical AND operator &&
            Console.WriteLine("true && true : " + (true && true));
            Console.WriteLine("true && false : " + (true && false));
            Console.WriteLine("false && true : " + (false && true));
            Console.WriteLine("false && false : " + (false && false));

            //Conditional logical OR operator ||
            Console.WriteLine("true || true : " + (true || true));
            Console.WriteLine("true || false : " + (true || false));
            Console.WriteLine("false || true : " + (false || true));
            Console.WriteLine("false || false : " + (false || false));

            int[] irArray1 = new int[] { 3, 5, 1 };//last index is 2 and has 3 elements

            //this below check will throw and unhandled exception and cause software to crash
            //because it checks both side of the logical operation
            //if (irArray1.Length > 4 & irArray1[3] == 4)
            //{
            //    Console.WriteLine("this is impossible to be written");
            //}

            //however this below will work fine because since the first condition is not met
            //the second condition will not be checked and in the second contidion
            //there is an error. the errors, irArray1 doesnt have index 3 because it has 3 elements
            if (irArray1.Length > 4 && irArray1[3] == 4)
            {
                Console.WriteLine("this is impossible to be written");
            }

            Console.WriteLine("3 & 4 = " + (3 & 4));//results 0 as bitwise
                                                    // Console.WriteLine("3 && 4 = " + (3 && 4));//this doesnt work for integers
            Console.WriteLine("3 | 4 = " + (3 | 4));//results 7 as bitwise
                                                    // Console.WriteLine("3 || 4 = " + (3 || 4)); ;//this doesnt work for integers

            //in bitwise 3 is represented as 0011 = 1*2^0 + 1*2^1 + 0*2^2 + 0*2^3
            //in bitwise 4 is represented as 0100 = 0*2^0 + 0*2^1 + 1*2^2 + 0*2^3

            //when you bitwise & (and operation) 0011 and 0100
            // 0011
            //  &
            // 0100
            // 0000
            //when you put the same order of bits into the logical & operation all results 0

            //when you bitwise | (or operation) 0011 and 0100
            // 0011
            //  |
            // 0100
            // 0111
            //when you or operation 1 and 0 it becomes 1
            //so the final result is 0111 = 1*2^0 + 1*2^1 + 1*2^2 + 0*2^3 = 7

            Console.WriteLine("3 ^ 4 : " + (3 ^ 4));
            //this will be bitwise xor
            //when you bitwise ^ (xor operation) 0011 and 0100
            // 0011
            //  ^
            // 0100
            // 0111
            //this would result 7
            //if you presst ctrl + k and then ctrl + d buttons it automatically formats 
            Console.WriteLine("3 ^ 3 : " + (3 ^ 3));//this would be 0
            Console.WriteLine("3 & 3 : " + (3 & 3));//this would be 3
            Console.WriteLine("3 | 3 : " + (3 | 3));//this would be 3


            Console.WriteLine("true | null : " + (true | null));
            Console.WriteLine("false | null : " + (false | null));
            Console.WriteLine("null | true : " + (null | true));
            Console.WriteLine("null | false : " + (null | false));

            Console.WriteLine("true & null : " + (true & null));
            Console.WriteLine("false & null : " + (false & null));
            Console.WriteLine("null & true : " + (null & true));
            Console.WriteLine("null & false : " + (null & false));

            Console.WriteLine("true ^ null : " + (true ^ null));
            Console.WriteLine("false ^ null : " + (false ^ null));
            Console.WriteLine("null ^ true : " + (null ^ true));
            Console.WriteLine("null ^ false : " + (null ^ false));

            Console.WriteLine("when console writeline parses null value it prints as empty character. empty character is no equal to space character: ");

            if("" == " ")//first one is empty character , second one is space character
            {

            }
        }

        static void firstPartofLecture()
        {
            int[] irSingleDimensional = new int[] { 32, 12, 677, 213, 521 };
            //the capacity of this array is now 5 and can not be increased or decreased without re-initilization
            irSingleDimensional[3] = 100;//this will change number 213 to 100 since index start from 0

            //what if I want to increase capacity of this array?
            int[] irTempArray = new int[irSingleDimensional.Length];
            Array.Copy(irSingleDimensional, irTempArray, irSingleDimensional.Length);

            irSingleDimensional = new int[100];
            Array.Copy(irTempArray, irSingleDimensional, irTempArray.Length);

            // Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Red;
            int[,,,,] ir5DimensionalArray = new int[3, 5, 10, 20, 50];
            //how many different values that this array can hold at maximum?
            //3 * 5 * 10 * 20 * 50 = 150,000

            Console.CursorVisible = true;
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WriteLine($"color : red - ir5DimensionalArray can hold {ir5DimensionalArray.Length.ToString("N0")}");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"color : green - lenght of first dimension of ir5DimensionalArray {ir5DimensionalArray.GetLength(0).ToString("N0")}");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine($"color : Magenta - lenght of third dimension of ir5DimensionalArray {ir5DimensionalArray.GetLength(2).ToString("N0")}");

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("type a key and hit enter to make window size size 100 rows and 20 columns");

            Console.ReadLine();

            Console.WindowHeight = 20;
            Console.WindowWidth = 100;

            Console.WriteLine("type a key and hit enter to make window size of console smaller");

            Console.ReadLine();

            Console.WindowHeight = 10;
            Console.WindowWidth = 10;

            Console.WriteLine("Hello World!");
        }
    }
}

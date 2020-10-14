using System;

namespace lecture_1
{
    class Program
    {
        //operators list https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/  - single line comment

        /*special keywords list : https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/
        
        multi line comment
        
        special characters list : https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/

       String Escape Sequences  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/

        */
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("i am providing string data type");
            bool myBoolValue = true;
            Console.WriteLine("i am providing bool value: " + myBoolValue);
            char myChar = 'A';
            Console.WriteLine("i am providing a character value: " + myChar);

            decimal myDecimal = 412.3445546135678989023468707801231235656876978071234135475685612312312312M;
            Console.WriteLine("my decimal 412.3445546135678989023468707801231235656876978071234135475685612312312312 printed as " + myDecimal);

            double myDouble = 412.3445546135678989023468707801231235656876978071234135475685612312312312;
            Console.WriteLine("my double 412.3445546135678989023468707801231235656876978071234135475685612312312312 printed as " + myDouble);


            float myFloat = 412.3445546135678989023468707801231235656876978071234135475685612312312312F;
            Console.WriteLine("my float 412.3445546135678989023468707801231235656876978071234135475685612312312312 printed as " + myFloat);

            Console.WriteLine();
            Console.WriteLine("max value of double {double.MaxValue}");
            Console.WriteLine($"max value of double {double.MaxValue}");
            Console.WriteLine($"max value of float {float.MaxValue}");
            Console.WriteLine($"max value of decimal {decimal.MaxValue}");

            Console.WriteLine($"max value of double without scientific notation {double.MaxValue.ToString("0." + new string('#', 339))}");

            Console.WriteLine($"max value of integer {int.MaxValue}");
            Console.WriteLine(3251);//it automatically understands that it is an integer value
            Console.WriteLine(3251.543);//it automatically understands that it is a double value

            Console.Clear();
            Console.WriteLine("Console.Clear(); clears the consoled and the console cleared");

            Console.Write("this line will continue.");
            Console.Write(" this will be in the same line.");
            Console.Write("\n");
            Console.Write("this will be in a new line.");

            Console.Clear();
            Console.WriteLine("my teach said that \"study hard at the home\" ");
            Console.WriteLine("string that has backslash \\ ");
            Console.WriteLine("no horizontal tab: value 1 value 2 value 3 ");
            Console.WriteLine("horizontal tab: value 1\tvalue 2\tvalue 3\t ");
            Console.WriteLine("vertical tab: value 1\vvalue 2\vvalue 3\v ");

            string mybaseString = "my school number is {0} , my graduation score is {1}";
            Console.WriteLine("base string\t" + mybaseString);

            string myFormattedString = string.Format(mybaseString, 250, 98);
            Console.WriteLine("formatted string\t" + myFormattedString);

            //this below line throws and error because it has lesser arguments than the format has
            //string myOneValueFormat = string.Format(mybaseString, 250);

            string myFormattedString_v2 = string.Format(mybaseString, 250, 98, 54, 12345, 6712, 123);

            Console.WriteLine("formatted string v2\t" + myFormattedString_v2);

            Console.WriteLine("my school number is {0}, my graduation score is {1}, my graduation year is {2}", 250, 98, 2009);

            Console.Clear();

            sbyte my_sbyte = 123; // -128 to 127 // Signed 8-bit integer = 1 byte in memory
            byte my_byte = 214; // 0 to 255 // Unsigned 8-bit integer = 1 byte in memory

            short my_short = 3241; // -32,768 to 32,767	Signed 16-bit integer = 2 bytes in memory
            //Int16 = short

            ushort my_ushort = 3241; // 0 to 65,535	Unsigned 16-bit integer = 2 bytes in memory
            // UInt16 = ushort

            int my_int = 325341; //-2,147,483,648 to 2,147,483,647    Signed 32 - bit integer = 4 bytes in memory

            //Int32 = int

            uint my_uint = 325341; //0 to 4,294,967,295 Unsigned 32 - bit integer = 4 bytes in memory

            //UInt32 = uint

            long my_long = 45643532432; // -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 Signed 64 - bit integer = 8 bytes in memory

            //Int64 = long

            ulong my_ulong = 5465745436575; // 0 to 18,446,744,073,709,551,615 Unsigned 64 - bit integer = 8 bytes in memory

            byte number1 = 1;

            // each bit can be either 0 or 1
            // because computers are made of transistors and each transistor can 
            // in base 2 there are 2 numbers : 0, or 1
            // in base 3 there are 3 numbers : 0, 1, or 2
            // in base 4 there are 4 numbers : 0, 1, 2, or 3
            // in base 10 (default base) there are 10 numbers : 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            // 1 byte is equal to 8 bits
            // 1 kbyte is equal to 1024 bytes
            // 1 mbyte is equal to 1024 kbytes
            // 1 gbyte is equal to 1024 mbytes
            // more information is here https://www.computerhope.com/issues/chspace.htm
            // 1 is equal to in base 2 = 1 * 2^0 = 00000001 = 8 bits = 1 byte
            // 2 is equal to in base 2 = 1 * 2^1 = 00000010
            // 34 is equal in base 2 = 2^5 +2^1  = 00100010
            // 00100010 is actually equals to = 
            // (0 * 2^0) + (1 * 2^1) + (0 * 2^2) + (0 * 2^3) + (0 * 2^4) + (1 * 2^5)
            // + (0 * 2^6) + (0 * 2^7)

            // maximum 8 bits number is = 1111 1111 = 
            // (1 * 2^0) + (1 * 2^1) + (1 * 2^2) + (1 * 2^3) + (1 * 2^4) + (1 * 2^5)
            // + (1 * 2^6) + (1 * 2^7) = 1 + 2 + 4 + 8 + 16 + 32 + 64 + 128 = 255
            // First bit (the leftmost) indicates the sign,
            // 1 = negative, 0 = positive.
            // in signed mode 1111 1111 = -127
            //  in signed mode 0111 1111 = 127

            //so 4 gbyte ram memory is equal to = 4 * 1024 mbytes = 4 * 1024 * 1024 kbytes = 4 * 1024 * 1024 * 1024 bytes = 4 * 1024 * 1024 * 1024 * 8 bits

            Int64 numberofBytesin4GB = 4L * 1024L * 1024L * 1024L * 8L;

            Console.WriteLine("4 gbytes in bits = " + numberofBytesin4GB);

            ulong bigNumber = ulong.MaxValue;
            Console.WriteLine($"ulong {bigNumber} written as like this in base 2 : " + Convert.ToString((long)bigNumber, 2)+" - lenght: "+ Convert.ToString((long)bigNumber, 2).Length);

            Int16 variable1 = Int16.MaxValue;
            Console.WriteLine($"Int16 {variable1} written as like this in base 2 : " + Convert.ToString((short)variable1, 2) + " - lenght: " + Convert.ToString((short)variable1, 2).Length);

            Int32 variable2 = Int32.MaxValue;
            Console.WriteLine($"Int32 {variable2} written as like this in base 2 : " + Convert.ToString((int)variable2, 2) + " - lenght: " + Convert.ToString((int)variable2, 2).Length);

            long bigNumberv2 = long.MaxValue;
            Console.WriteLine($"singed long {bigNumberv2} written as like this in base 2 : " + Convert.ToString((long)bigNumberv2, 2) + " - lenght: " + Convert.ToString((long)bigNumberv2, 2).Length);

            //what is the representation of base 10 number 12 in base 5?
            //available numbers are 0 1 2 3 4 
            //2 + 10 = 0022 = 0*5^3 + 0*5^2 + 2*5^1 + 2*5^0 = 0 + 0 + 10 + 2
        }
    }
}

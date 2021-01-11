using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lecture_14
{
    public static class static_classes
    {
        private static readonly List<string> listNotAllowedCharactersInUserName = new List<string>
        {
            "\\","/","*",":","?","\"","<",">","|"
        };

        public static bool CheckUserNameValidty(this string srUsername)
        {
            //LinQ code
            if (listNotAllowedCharactersInUserName.Where(pr => srUsername.Contains(pr)).Count() > 0)
                return false;

            //above code achieves the same thing as below approach
            foreach (var vrPerString in listNotAllowedCharactersInUserName)
            {
                if (srUsername.Contains(vrPerString))
                {
                    return false;
                }
            }

            return true;
        }

        public static string composeUserfilePath(this string srUserName)
        {
            return srUserName + ".txt";
        }

        public static string formatUserLog(int irLineNumber, string srDateTimeText, string srUserInput)
        {
            return $"{irLineNumber}) {srDateTimeText}\t\t{srUserInput}";
        }


        public static double NextDouble(this Random RandGenerator, double MinValue, double MaxValue)
        {
            return RandGenerator.NextDouble() * (MaxValue - MinValue) + MinValue;
        }


    }
}

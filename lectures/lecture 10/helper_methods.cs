using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lecture_10
{
    public static class helper_methods
    {
        private static string srUsernameAllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZŞĞÖÇÜİ _";

        private static int irMinLenghtUserName = 3;//allow only 3 characters lenght username
        private static int irMaxLenghtUserName = 20;//allow only 20 characters lenght username

        private static List<char> lstAllowedCharacters = new List<char>();

        private static List<char> lstAllowedCharactersDefaultBehaviour = new List<char>();

        private static List<char> lstInvariantCultureDifference = new List<char>();

        static helper_methods()//this is the default constructor of static class
        {
            foreach (var vrPerChar in srUsernameAllowedCharacters.ToCharArray())
            {
                lstAllowedCharacters.Add(vrPerChar);
            }

            //in Turkish culture if you conver I into lower case it becomes ı. However, if you convert it into lower case, it becomes i in English culture

            foreach (var vrPerChar in srUsernameAllowedCharacters.ToLower(new System.Globalization.CultureInfo(
                "tr-TR")))//the .net implictly converts my list into a character array
            {
                lstAllowedCharacters.Add(vrPerChar);
            }

            foreach (var vrPerChar in srUsernameAllowedCharacters.ToUpper(new System.Globalization.CultureInfo(
         "tr-TR")))//the .net implictly converts my list into a character array
            {
                lstAllowedCharacters.Add(vrPerChar);
            }

            lstAllowedCharacters = lstAllowedCharacters.Distinct().ToList();//this will remove duplicate elements from the list by using LinQ extension method


            //when you dont specify culture, it will use the culture info of the operation system. in my case it will be en-us culture which is the culture of my windows

            foreach (var vrPerChar in srUsernameAllowedCharacters.ToLower())
            {
                lstAllowedCharactersDefaultBehaviour.Add(vrPerChar);
            }

            //try invariant with en-us culture

            foreach (var vrPerChar in srUsernameAllowedCharacters.ToLowerInvariant())
            {
                lstInvariantCultureDifference.Add(vrPerChar);
            }

        }

        public class actionResult
        {
            public bool blResult = true;
            public string srResultMessage = "NA";
        }

        public static actionResult checkIfUserNameValid(string srUserName)
        {
            actionResult checkResult = new actionResult();

            if (srUserName.Length < irMinLenghtUserName)
            {
                checkResult.blResult = false;
                checkResult.srResultMessage = $"Your username can not be less than {irMinLenghtUserName} characters lenght";
            }

            if (srUserName.Length > irMaxLenghtUserName)
            {
                checkResult.blResult = false;
                checkResult.srResultMessage = $"Your username can not be bigger than {irMaxLenghtUserName} characters lenght";
            }

            foreach (var vrUserNameChar in srUserName)
            {
                if (lstAllowedCharacters.Contains(vrUserNameChar) == false)
                {
                    checkResult.blResult = false;
                    checkResult.srResultMessage = $"Your username can not contain character “{vrUserNameChar}”";
                }
            }

            return checkResult;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Net.Mail;
using System.IO;
using System.Security.Cryptography;

namespace lecture_10
{
    public static class helper_methods
    {

        public static char crUserInfoSeperatorCharacter = ';';

        public static string srUsersFileName = "users.txt";

        private static List<char> lstSpecialCharacterList = new List<char> {
            '@', '#', '$', '%', '&', '*', '!', ';', '?' };

        private static string srUsernameAllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZŞĞÖÇÜİ _";

        private static int irMinLenghtUserName = 3;//allow only 3 characters lenght username
        private static int irMaxLenghtUserName = 20;//allow only 20 characters lenght username

        private static int irMinPasswordLenght = 8;

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

        public static string normalizeUserName(this string srUserName)
        {
            //we make user names case invariant
            //we make user names accent invariant
            //we ensure that no space character in the begining or in the ending
            return srUserName.ToUpper(new CultureInfo("en-US")).RemoveDiacritics().ToLower(new CultureInfo("en-US")).Trim();
        }

        static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public class actionResult
        {
            public bool blResult = true;
            public string srResultMessage = "NA";
        }

        public static actionResult checkIfUserNameValid(string srUserName, string srEmailCheck)
        {
            //we need to normalize during login check and during checking against if that username exists in our user database
            //if we register the username with normalization, then the upper case or lower case of that username or the accent of that username would be lost
            //so if you want users to keep their username styling accent you use normalization only at checking 

            //srUserName = srUserName.normalizeUserName();
            //srUserName = normalizeUserName(srUserName); same as the above but to be use as above, we have to covert that username to method extension

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

            if (File.Exists(srUsersFileName))
            {
                //structure of users txt username;hashed_password;email
                foreach (var vrPerLine in File.ReadLines(srUsersFileName))
                {
                    
                    List<string> lstSplittedStrings = vrPerLine.Split(crUserInfoSeperatorCharacter).ToList();//tolist is linq extension / split is string extension

                    string srRegisteredUserName = lstSplittedStrings[0];
                    string srRegisteredEmail = lstSplittedStrings[2];

                    var vrFileSavedUserName = srRegisteredUserName.normalizeUserName();
                    var vrNormalizedSelectedUserName = srUserName.normalizeUserName();

                    if (vrFileSavedUserName == vrNormalizedSelectedUserName)
                    {
                        checkResult.blResult = false;
                        checkResult.srResultMessage = $"Your selected username is not available. Please pick another username";
                        break;
                    }

                    if (srEmailCheck == srRegisteredEmail)
                    {
                        checkResult.blResult = false;
                        checkResult.srResultMessage = $"Your selected email is already registered. Please check your email";
                        break;
                    }
                }

            }

            return checkResult;
        }


        public static actionResult checkIfPasswordIsValid(string srPw1, string srPwRepeat)
        {
            actionResult checkResult = new actionResult();

            if (srPw1 != srPwRepeat)
            {
                checkResult.blResult = false;
                checkResult.srResultMessage = $"Your entered passwords are not matching. Please re-enter your password.";
            }

            if (srPw1.Length < irMinPasswordLenght && checkResult.blResult == true)
            {
                checkResult.blResult = false;
                checkResult.srResultMessage = $"Your password has to be minimum 8 characters";
            }

            bool blContainsDigit = false, blContainsLetter = false, blContainsUpperCase = false, blContainsLowerCase = false, blContainsSpecialCharacter = false;

            foreach (char vrPerChar in srPw1.ToCharArray())
            {
                if (char.IsDigit(vrPerChar))
                    blContainsDigit = true;
                if (char.IsLetter(vrPerChar))
                    blContainsLetter = true;
                if (char.IsUpper(vrPerChar))
                    blContainsUpperCase = true;
                if (char.IsLower(vrPerChar))
                    blContainsLowerCase = true;
                if (lstSpecialCharacterList.Contains(vrPerChar))
                    blContainsSpecialCharacter = true;
            }

            if (!blContainsDigit && checkResult.blResult == true)//! is negation operator and it reverses boolean result. so it becomes equal to if (blContainsDigit==false)
            {
                checkResult.blResult = false;
                checkResult.srResultMessage = $"Your password has to contain a numeric character";
            }

            if (!blContainsLetter && checkResult.blResult == true)
            {
                checkResult.blResult = false;
                checkResult.srResultMessage = $"Your password has to contain a letter";
            }

            if (!blContainsUpperCase && checkResult.blResult == true)
            {
                checkResult.blResult = false;
                checkResult.srResultMessage = $"Your password has to contain an upper case character";
            }

            if (!blContainsLowerCase && checkResult.blResult == true)
            {
                checkResult.blResult = false;
                checkResult.srResultMessage = $"Your password has to contain a lower case character";
            }

            if (!blContainsSpecialCharacter && checkResult.blResult == true)
            {
                checkResult.blResult = false;
                checkResult.srResultMessage = $"Your password has to contain a special character. Use any of these characters at least 1 time: {string.Join(" ", lstSpecialCharacterList)}";
            }

            return checkResult;
        }

        public static bool IsValidEmail(this string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);
                return true;
            }
            catch
            {
                return false;
            }
        }

       public static string ComputeSha256Hash(this string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

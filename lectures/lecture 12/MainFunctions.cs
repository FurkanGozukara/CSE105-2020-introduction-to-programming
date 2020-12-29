using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Windows;

namespace lecture_10
{
    public static class MainFunctions
    {

        public static Tuple<bool, string> tryToRegister(MainWindow mainWindowInstance)
        {
            var vrResult = helper_methods.checkIfUserNameValid(mainWindowInstance.txtUserName_Register.Text, mainWindowInstance.txtEmail.Text);

            if (vrResult.blResult == false)
            {
                return new Tuple<bool, string>(vrResult.blResult, vrResult.srResultMessage);
            }

            vrResult = helper_methods.checkIfPasswordIsValid(mainWindowInstance.txtPassword1_register.Password.ToString(),//converting password box to text .Password
                mainWindowInstance.txtPassword2_register.Password.ToString());

            if (vrResult.blResult == false)
            {
                return new Tuple<bool, string>(vrResult.blResult, vrResult.srResultMessage);
            }

            if (!mainWindowInstance.txtEmail.Text.IsValidEmail())
            {
                vrResult.blResult = false;
                vrResult.srResultMessage = "Your entered email is not a valid email address. Please check your email!";
            }

            if (vrResult.blResult == true)
            {
                File.AppendAllText(helper_methods.srUsersFileName, 
                        generateUserInfoFormat(
                            mainWindowInstance.txtUserName_Register.Text,
                            mainWindowInstance.txtPassword1_register.Password.ToString(),
                            mainWindowInstance.txtEmail.Text
                        )
                    );
            }


            return new Tuple<bool, string>(vrResult.blResult, vrResult.srResultMessage);
        }

        private static string generateUserInfoFormat(string srUsername, string srPassword, string srEmail)
        {
            return srUsername + helper_methods.crUserInfoSeperatorCharacter +
                srPassword.ComputeSha256Hash() + helper_methods.crUserInfoSeperatorCharacter +
                srEmail + Environment.NewLine;//you can use \r\n for new line as well
        }

        public static void tryLogin(MainWindow mainWindowInstance)
        {
            //i have to convert user entered values into the same format i have used when i register the user
            string srUserEnteredUsername = mainWindowInstance.txtUserName_Login.Text;
            string srUserEnteredPassword = mainWindowInstance.passwordBoxLogin.Password.ToString().ComputeSha256Hash();

            foreach (var vrPerLine in File.ReadLines(helper_methods.srUsersFileName))
            {
                List<string> lstLineDetails = vrPerLine.Split(helper_methods.crUserInfoSeperatorCharacter).ToList();
                if(lstLineDetails[0]== srUserEnteredUsername && srUserEnteredPassword== lstLineDetails[1])
                {
                    helper_methods.doLogin(srUserEnteredUsername);
                    return;
                }
            }

            mainWindowInstance.displayMessage("Login Error! The username and the password you have entered does not match any records in the system");
        }


    }
}

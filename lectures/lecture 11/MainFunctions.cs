using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
                File.AppendAllText(helper_methods.srUsersFileName, generateUserInfoFormat(mainWindowInstance.txtUserName_Register.Text,
                    mainWindowInstance.txtPassword1_register.Password.ToString(),
                    mainWindowInstance.txtEmail.Text));
            }


            return new Tuple<bool, string>(vrResult.blResult, vrResult.srResultMessage);
        }

        private static string generateUserInfoFormat(string srUsername, string srPassword, string srEmail)
        {
            return srUsername + helper_methods.crUserInfoSeperatorCharacter +
                srPassword.ComputeSha256Hash() + helper_methods.crUserInfoSeperatorCharacter +
                srEmail + Environment.NewLine;//you can use \r\n for new line as well
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace lecture_10
{
   public static class static_variables
    {
        public static string srColumnWidthPixels = "150";
        public static int irColumnWidthPixels = 150;
        public static int irRowHeightPixels = 60;

        static static_variables()
        {
            string srThisWillBe = "called during initilization of the main window immediately";
        }
    }
}

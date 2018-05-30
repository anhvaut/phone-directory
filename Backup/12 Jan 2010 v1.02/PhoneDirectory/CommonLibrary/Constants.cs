using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    public class Constants
    {
        public static string HOME_PHONE = "   Home:";
        public static string MOBILE_PHONE = "   Mobile:";
        public static string BUSINESS_PHONE = "   Business:";
        public static string BUSINESS_FAX = "   Fax:";
        public static string EMAIL = "   Email:";
        public static string ADDRESS = "   Address:";

        //public static string CONGIF_FILE = "PhoneDirectory.exe.config";

        public static bool IsNotContain(string value)
        {
            if ((value.IndexOf(HOME_PHONE) == -1)
               && (value.IndexOf(MOBILE_PHONE) == -1)
               && (value.IndexOf(BUSINESS_PHONE) == -1)
               && (value.IndexOf(BUSINESS_FAX) == -1)
               && (value.IndexOf(EMAIL) == -1)
               && (value.IndexOf(ADDRESS) == -1)) return true;

            return false;
        }

        public static bool IsContain(string value)
        {
            if (value.Contains(HOME_PHONE)
               || value.Contains(MOBILE_PHONE)
               || value.Contains(BUSINESS_PHONE)
               || value.Contains(BUSINESS_FAX)
               || value.Contains(EMAIL)
               || value.Contains(ADDRESS)) return true;

            return false;
        }

        public static string GetConfigFilePath()
        {
            string appPath = CommonLibrary.ApplicationStartUp.GetAppPath();
            appPath = appPath.Equals("") ? "PhoneDirectory.exe.config" : appPath + ".config";

            return appPath;
        }

        public static string GetApplicationPath()
        {
            string appPath = CommonLibrary.ApplicationStartUp.GetAppPath();
            if (!appPath.Equals(""))
            {
                int i=appPath.IndexOf("PhoneDirectory.exe");
                appPath = appPath.Substring(0, i);
            }

            return appPath;

        }

    }
}

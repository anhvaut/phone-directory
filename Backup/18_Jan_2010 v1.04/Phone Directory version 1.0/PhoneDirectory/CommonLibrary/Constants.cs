using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

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
        private static CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(CommonLibrary.Constants.GetConfigFilePath());

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

        public static string GetADDomain()
        {

            return GetDomain(appConfig.GetValue("DomainName"));
        }

        private static string GetDomain(string domainName)
        {
            if (domainName.IndexOf("LDAP://") == -1) domainName = "LDAP://" + domainName;

            return domainName;
        }


        public static string GetObjectDomain()
        {
            //Domain in format:e.g. DC=Wollundra, DC=local
            string domainName = appConfig.GetValue("DomainName");
            if (domainName.IndexOf("LDAP://") != -1) domainName = domainName.Replace("LDAP://", "");
            if (domainName.IndexOf(".") !=-1)
            {
                string[] a = domainName.Split('.');
                string tmp = "DC=" + a[0];
                
                for (int i = 1; i < a.Length; i++)
                {
                    tmp += ",DC=" + a[i];
                }
                domainName = tmp;
            }

            return domainName;
        }

        public static bool IsValidDomainName(string domainName)
        {
            bool ck = true;

            try
            {
                DirectoryEntry entry = new DirectoryEntry();
                entry.Path = GetDomain(domainName);

                DirectorySearcher _DirectorySearcher = new DirectorySearcher(entry);

                _DirectorySearcher.Filter = "(SAMAccountName=*)";
                _DirectorySearcher.SearchScope = SearchScope.Subtree;
                _DirectorySearcher.FindOne();
                

            }
            catch (Exception ex)
            {
                ck = false;
            }

            return ck;
            
        }

        public static string GetProductVersion()
        {
            string version = appConfig.GetValue("ProductVersion");
            version = version.Replace(".","");
            return version;
        }

        public static string GetProductCode()
        {
            return appConfig.GetValue("ProductCode");
        }

        public static bool IsDebugMode()
        {
            return appConfig.GetValue("DebugMode").Equals("yes");
        }

        public static bool IsActiveDirectory()
        {
            return appConfig.GetValue("ActiveDirectory").Equals("yes");
        }

        public static bool IsOutlook()
        {
            return appConfig.GetValue("Outlook").Equals("yes");
        }

        public static bool IsOutlookExpress()
        {
            return appConfig.GetValue("OutlookExpress").Equals("yes");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;

namespace CommonLibrary
{
    public class ApplicationStartUp
    {
        public static void Save(string applicationPath)
        {

            //Cannot write in Local Machine, otherwise it is have problem

             RegistryKey rkAppCurrentUser = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
             rkAppCurrentUser.SetValue("PhoneDirectory", applicationPath);
            
        }

        public static void Delete()
        {
           //Cannot write in Local Machine, otherwise it is have problem

            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rkApp.DeleteValue("PhoneDirectory", false);
        }

        public static string GetAppPath()
        {
            string st = "";
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (rkApp.GetValue("PhoneDirectory") != null)
            {
                st = rkApp.GetValue("PhoneDirectory").ToString();
                if (!File.Exists(st))
                {
                    st = "";
                    Delete();
                }
            }

            return st;
        }
    }
}

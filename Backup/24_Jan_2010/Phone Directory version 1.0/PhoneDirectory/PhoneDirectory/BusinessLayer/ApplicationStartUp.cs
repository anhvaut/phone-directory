﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace PhoneDirectory.BusinessLayer
{
    public class ApplicationStartUp
    {
        public static void Save(string applicationPath)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rkApp.SetValue("PhoneDirectory", applicationPath);
            
        }

        public static void Delete()
        {
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
            }

            return st;
        }
    }
}

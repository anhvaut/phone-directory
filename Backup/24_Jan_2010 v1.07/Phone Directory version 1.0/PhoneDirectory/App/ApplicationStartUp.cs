
/**************************************************************************\
* Telephone Directory v1.00                                                *
* http://www.wollundra.com.au  ,http://www.wollundra.com                   *
* Copyright (C) 2009-2010 by Wollundra Pty Ltd                             *
* Development Team : Tran The Vu                                           *
*                    John Fergus                                           *
*                    Shawns Richards                                       *
* ------------------------------------------------------------------------ *
*  The copyright of the Source code and its documentation is owned by      * 
* WOLLUNDRA Pty Ltd A.C.N 075 477 048. The unauthorised reproduction       *
* or distribution of this source code will result in criminal penalties.   *                                                     *
\**************************************************************************/

using Microsoft.Win32;
using System.IO;

namespace Wollundra.App
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

        public static bool IsExistRunKey()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            return (rkApp.GetValue("PhoneDirectory") != null);
            
        }
    }
}

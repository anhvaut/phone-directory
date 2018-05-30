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

using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using Wollundra.App;


namespace Wollundra.PhoneDirectory.BusinessLayer
{
    public class PersonalProfile
    {
        private static string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal).ToString();
        private static string profile = "profile";

        public static void SaveQuickSearchWindowSize(int width, int height)
        {
            string profilePath = personalFolder + "/" + profile;
            try
             {
               
                    
                    StreamWriter sw = new StreamWriter(profilePath);
                    sw.WriteLine(width + "," + height);
                    sw.Flush();
                    sw.Close();
               
            }
            catch (Exception ex)
            {
                if (Constants.IsDebugMode())
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static double GetQuickSearchWindowHeight()
        {
            double height = 0;

            string profilePath = personalFolder + "/" + profile;
            try
            {
                if (File.Exists(profilePath))
                {
                    StreamReader tr = new StreamReader(profilePath);
                    string st = "";
                    if ((st = tr.ReadLine()) != null)
                    {
                        string[] a = st.Split(',');
                        if (a.Length > 0)
                        {
                            height = double.Parse(a[1].Trim());
                        }
                    }
                    tr.Close();
                }
            }
            catch (Exception ex)
            {
                if (Constants.IsDebugMode())
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return height;

        }

        public static double GetQuickSearchWindowWidth()
        {
            double width = 0;

            string profilePath = personalFolder + "/" + profile;
            try
            {
                if (File.Exists(profilePath))
                {
                    StreamReader tr = new StreamReader(profilePath);
                    string st = "";
                    if ((st = tr.ReadLine()) != null)
                    {
                        string[] a = st.Split(',');
                        if (a.Length > 0)
                        {
                            width = double.Parse(a[0].Trim());
                        }
                    }
                    tr.Close();
                }
            }
            catch (Exception ex)
            {
                if (Constants.IsDebugMode())
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return width;
        }
    }
}

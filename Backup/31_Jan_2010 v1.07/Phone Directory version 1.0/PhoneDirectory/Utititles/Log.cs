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
using System.Collections.Generic;

using System.Text;
using System.IO;


namespace Wollundra.Utilities
{
    public class Log
    {
        private static string sLogFormat;
        private static string sLogFolder = "";
        private static string sPathName = "\\Log";

        public static void Create(string error)
        {
            try
            {
                CreateLogFile();
                WriteLog(error);
            }
            catch (Exception ex)
            {

            }
        }

        private static void CreateLogFile()
        {
            sLogFolder += Wollundra.App.Constants.GetApplicationPath() + "Logs";
            sPathName = sLogFolder + sPathName;
            //sLogFormat used to create log files format :

            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message

            sLogFormat = DateTime.Now.ToString("dd-MMM-yyyy");
            sLogFormat += " " + DateTime.Now.ToLongTimeString().ToString();
            sLogFormat += ", From " + System.Environment.MachineName + " ==> ";
            
            //this variable used to create log filename format "

            //for example filename : LogYYYYMMDD

            //string sYear = DateTime.Now.Year.ToString();
            //string sMonth = DateTime.Now.Month.ToString();
            //string sDay = DateTime.Now.Day.ToString();
            
            sPathName += "  " + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt";
            if (!System.IO.Directory.Exists(sLogFolder))
            {
                System.IO.Directory.CreateDirectory(sLogFolder);
            }
        }

        /**
         * write message to file
         */
        public static void WriteLog(string command)
        {
            StreamWriter sw = new StreamWriter(sPathName, true);
            sw.WriteLine(sLogFormat + command);
            sw.Flush();
            sw.Close();
        }

    }
}

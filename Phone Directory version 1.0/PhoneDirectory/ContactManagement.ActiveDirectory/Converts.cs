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
using System.IO;
using System.Collections;

namespace Wollundra.ContactManagement.ActiveDirectory
{
    public class Converts
    {
        public void CSV2LDIF(string csvFile, string ldifFile)
        {

            ArrayList arrayList = new ArrayList();

            StreamReader tr = new StreamReader(csvFile);
            string[] header = null;
            string tmpHeader = "";
            if ((tmpHeader = tr.ReadLine()) != null)
            {
                header = tmpHeader.Split(',');
            }

            string st = "";
            while ((st = tr.ReadLine()) != null)
            {
                try
                {
                    string[] b = st.Split('"');

                    if (b.Length >= 3)
                    {

                        string[] a = b[2].Substring(1).Split(',');



                        if (a.Length > 1 && !a[1].Equals("") && !header[2].Equals("mail"))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: " + header[2]);
                            arrayList.Add(header[2] + ": " + a[1]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }


                        if (a.Length > 2 && !a[2].Equals("") && !header[3].Equals("mail"))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: " + header[3]);
                            arrayList.Add(header[3] + ": " + a[2]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }


                        if (a.Length > 3 && !a[3].Equals("") && !header[4].Equals("mail"))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: " + header[4]);
                            arrayList.Add(header[4] + ": " + a[3]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }
                        if (a.Length > 4 && !a[4].Equals("") && !header[5].Equals("mail"))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: " + header[5]);
                            arrayList.Add(header[5] + ": " + a[4]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }
                        if (a.Length > 5 && !a[5].Equals("") && !header[6].Equals("mail"))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: " + header[6]);
                            arrayList.Add(header[6] + ": " + a[5]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }
                        if (a.Length >= 6 && !a[6].Equals("") && !header[7].Equals("mail"))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: " + header[7]);
                            arrayList.Add(header[7] + ": " + a[6]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }
                        if (a.Length >= 7 && !a[7].Equals("") && !header[8].Equals("mail"))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: " + header[8]);
                            arrayList.Add(header[8] + ": " + a[7]);
                            arrayList.Add("-");
                            arrayList.Add("");

                        }

                    }

                }
                catch (Exception ex)
                {
                }

            }

            tr.Close();

            if (File.Exists(ldifFile)) File.Delete(ldifFile);
            StreamWriter sw = new StreamWriter(ldifFile, true);
            foreach (var a in arrayList)
            {

                sw.WriteLine(a.ToString());
            }
            sw.Flush();
            sw.Close();

        }
    }
}

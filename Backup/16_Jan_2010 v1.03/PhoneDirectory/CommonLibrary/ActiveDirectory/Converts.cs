using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace CommonLibrary.ActiveDirectory
{
    public class Converts
    {
        public void CSV2LDIF(string csvFile,string ldifFile)
        {
            ArrayList arrayList = new ArrayList();

            StreamReader tr = new StreamReader(csvFile);
            string st = "";
            while ((st = tr.ReadLine()) != null)
            {
                string[] b = st.Split('"');
                
                if (b.Length >= 3)
                {
                    
                    string[] a = b[2].Substring(1).Split(',');

                    if (a.Length > 6 && !a[0].Equals("")   )
                    {
                        if (!a[1].Equals(""))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: telephoneNumber");
                            arrayList.Add("telephoneNumber: " + a[1]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }

                        if (!a[2].Equals(""))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: mail");
                            arrayList.Add("mail: " + a[2]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }

                        if (!a[3].Equals(""))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: homePhone");
                            arrayList.Add("homePhone: " + a[3]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }
                        if (!a[4].Equals(""))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: mobile");
                            arrayList.Add("mobile: " + a[4]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }
                        if (!a[5].Equals(""))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: facsimileTelephoneNumber");
                            arrayList.Add("facsimileTelephoneNumber: " + a[5]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }
                        if (!a[6].Equals(""))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: homePostalAddress");
                            arrayList.Add("homePostalAddress: " + a[6]);
                            arrayList.Add("-");
                            arrayList.Add("");
                        }
                        if (!a[7].Equals(""))
                        {
                            arrayList.Add("dn:" + b[1]);
                            arrayList.Add("changetype: modify");
                            arrayList.Add("replace: ipPhone");
                            arrayList.Add("ipPhone: " + a[7]);
                            arrayList.Add("-");
                            arrayList.Add("");

                        }
                    }
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

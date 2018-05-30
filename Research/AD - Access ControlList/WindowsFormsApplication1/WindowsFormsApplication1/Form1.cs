using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.DirectoryServices;
using System.Security.Principal;
using System.Security.AccessControl;
using ActiveDs;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            DirectoryEntry entry = new DirectoryEntry();
            entry.Path = "LDAP://WOLLUNDRA";

            DirectorySearcher _DirectorySearcher = new DirectorySearcher(entry);

            _DirectorySearcher.Filter = "(objectCategory=person)";
            _DirectorySearcher.SearchScope = SearchScope.Subtree;

           
          
            SearchResultCollection allUsers = _DirectorySearcher.FindAll();
            

            string outputFile = "C:/dsacls.bat";
            if (File.Exists(outputFile)) File.Delete(outputFile);
            foreach (SearchResult result in allUsers)
            {
                if (result.Properties["displayName"].Count > 0 &&
                    !result.Properties["displayName"][0].ToString().Contains("CN=")
                    && !result.Properties["displayName"][0].ToString().Contains("System"))
                {

                    if (result.Properties["sAMAccountName"].Count > 0)
                    {
                          string User =  result.Properties["sAMAccountName"][0].ToString().Trim();
                         //listBox1.Items.Add(User);
                         //System.Diagnostics.Process.Start(@"C:\dsacls.bat", DomainName + " " + User + " telephoneNumber");
                         //System.Diagnostics.Process.Start(@"C:\dsacls.bat", DomainName + " " + User + " facsimileTelephoneNumber");
                         //System.Diagnostics.Process.Start(@"C:\dsacls.bat", DomainName + " " + User + " Mobile");
                         //System.Diagnostics.Process.Start(@"C:\dsacls.bat", DomainName + " " + User + " homePostalAddress");
                         //System.Diagnostics.Process.Start(@"C:\dsacls.bat", DomainName + " " + User + " homePhone");
                         //System.Diagnostics.Process.Start(@"C:\dsacls.bat", DomainName + " " + User + " mail");
                         //System.Diagnostics.Process.Start(@"C:\dsacls.bat", DomainName + " " + User + " ipPhone");
                        

                        StreamWriter sw = new StreamWriter(outputFile, true);
                        sw.WriteLine(@"C:\dsacls.exe DC=WOLLUNDRA,DC=local /I:S /G WOLLUNDRA\"+ User+ ":RPWP;telephoneNumber;user");
                        sw.WriteLine(@"C:\dsacls.exe DC=WOLLUNDRA,DC=local /I:S /G WOLLUNDRA\" + User + ":RPWP;facsimileTelephoneNumber;user");
                        sw.WriteLine(@"C:\dsacls.exe DC=WOLLUNDRA,DC=local /I:S /G WOLLUNDRA\" + User + ":RPWP;mobile;user");
                        sw.WriteLine(@"C:\dsacls.exe DC=WOLLUNDRA,DC=local /I:S /G WOLLUNDRA\" + User + ":RPWP;homePostalAddress;user");
                        sw.WriteLine(@"C:\dsacls.exe DC=WOLLUNDRA,DC=local /I:S /G WOLLUNDRA\" + User + ":RPWP;mail;user");
                        sw.WriteLine(@"C:\dsacls.exe DC=WOLLUNDRA,DC=local /I:S /G WOLLUNDRA\" + User + ":RPWP;ipPhone;user");
                        sw.Flush();
                        sw.Close();

                    }
                    
                }
            }

            StreamWriter sw1 = new StreamWriter(outputFile, true);
            sw1.WriteLine("Pause");
            sw1.Flush();
            sw1.Close();

            System.Diagnostics.Process.Start(@"C:\dsacls.bat");
            //string DomainName = "WOLLUNDRA";
            //string User = DomainName + @"\testUser";
           
               
               



                
           // p.WaitForExit(60000);
            //DirectoryInfo di = new DirectoryInfo("C:/abc/def");
            //di.Create();
           
           //NKTWABLib.NKTWAB NKT = new NKTWABLib.NKTWAB();
           // NKTWABLib.Folder rootFolder= NKT.RootFolder;

            //listBox1.Items.Add(rootFolder.Folders.Count);

            ////NKTWABLib.Contacts item = new NKTWABLib.Contacts();

            ////ComctlLib.ListItem lvItem = new ComctlLib.ListItem();
            //NKTWABLib.ContactContainer contCont = (NKTWABLib.ContactContainer)NKT.get_Item(rootFolder.Folders.get_Item(1).EntryID);
            ////ComctlLib.Node tvItem = new ComctlLib.Node();

            //for (int i = 1; i <= contCont.Contacts.Count;i++ )
            //{
            //    NKTWABLib.Contact item = contCont.Contacts.get_Item(i);
            //    listBox1.Items.Add(item.Name);
            //}

            //MessageBox.Show("" + contCont.Contacts.Count);


            //System.Diagnostics.Process.Start("mailto:email@add ress?subject=mysubject");
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //NKTWABLib.NKTWAB NKT = new NKTWABLib.NKTWAB();
            //NKTWABLib.Folder rootFolder = NKT.RootFolder;

            //listBox1.Items.Add(rootFolder.Folders.get_Item(1));
            //MessageBox.Show(rootFolder.Folders.get_Item(1).EntryID);
            //MessageBox.Show(rootFolder.Folders.get_Item(1).Name);
        }


        //public string GetEntryID(ref string key)
        //{
        //    short endPos; 
    		
        //    endPos = key.IndexOf("&");
        //    if (endPos == -1)
        //        endPos = key.Length;

    		
        //    endPos = endPos - 1;
    		
        //    GetEntryID = Mid(key, 2, endPos);
        //}

    }
}

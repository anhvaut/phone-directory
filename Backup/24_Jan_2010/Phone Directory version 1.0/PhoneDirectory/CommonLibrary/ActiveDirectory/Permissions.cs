using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.IO;

namespace CommonLibrary.ActiveDirectory
{
    public class Permissions
    {
        private string _DomainName;
        private string _ToolsPath;
        private DirectorySearcher _DirectorySearcher;


        //DC=WOLLUNDRA,DC=Local
        public Permissions(string _DomainName, string _ToolsPath)
        {
            this._DomainName = _DomainName;
            this._ToolsPath = _ToolsPath;
           

            DirectoryEntry entry = new DirectoryEntry();
            entry.Path = "LDAP://" + _DomainName;

            _DirectorySearcher = new DirectorySearcher(entry);
        }

        public void SetPermissionsForAllUser()
        {
            SetPermissions("(SAMAccountName=*)");
        }
        public void SetPermissionsForUser(string User)
        {
            SetPermissions("(SAMAccountName=" + User + ")");
        }

        private void SetPermissions(string filter)
        {
            _DirectorySearcher.Filter = filter;
            _DirectorySearcher.SearchScope = SearchScope.Subtree;
            SearchResultCollection allUsers = _DirectorySearcher.FindAll();

            string outputFile = "Tools/dsacls.bat";
            if (File.Exists(outputFile)) File.Delete(outputFile);
            StreamWriter sw = null;
            sw = new StreamWriter(outputFile, true);
            sw.WriteLine("cd Tools");
            sw.Flush();
            sw.Close();
            
            foreach (SearchResult result in allUsers)
            {
                if (result.Properties["displayName"].Count > 0 &&
                    !result.Properties["displayName"][0].ToString().Contains("CN=")
                    && !result.Properties["displayName"][0].ToString().Contains("System"))
                {

                    if (result.Properties["sAMAccountName"].Count > 0)
                    {
                        string User = result.Properties["sAMAccountName"][0].ToString().Trim();
                     
                        sw = new StreamWriter(outputFile, true);
                        sw.WriteLine("dsacls.exe " + _DomainName + @" /I:S /G " + User + ":RPWP;telephoneNumber;user");
                        sw.WriteLine("dsacls.exe " + _DomainName + @" /I:S /G " + User + ":RPWP;facsimileTelephoneNumber;user");
                        sw.WriteLine("dsacls.exe " + _DomainName + @" /I:S /G " + User + ":RPWP;mobile;user");
                        sw.WriteLine("dsacls.exe " + _DomainName + @" /I:S /G " + User + ":RPWP;homePostalAddress;user");
                        sw.WriteLine("dsacls.exe " + _DomainName + @" /I:S /G " + User + ":RPWP;mail;user");
                        sw.WriteLine("dsacls.exe " + _DomainName + @" /I:S /G " + User + ":RPWP;ipPhone;user");
                        sw.Flush();
                        sw.Close();

                    }

                }
            }
             

            sw = new StreamWriter(outputFile, true);
            sw.WriteLine("Pause");
            sw.Flush();
            sw.Close();

            System.Diagnostics.Process.Start(_ToolsPath +"/dsacls.bat");
        }
    }
}

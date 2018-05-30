/**
 *  Vu The Tran
 *  21/11/2009
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ActiveDs;
using System.DirectoryServices;

namespace CommonLibrary.ActiveDirectory
{
    public class ContactManagement
    {
        private DirectorySearcher _DirectorySearcher;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_EntryPath">"LDAP://DomainName"</param>
        public ContactManagement(string _EntryPath)
        {
            DirectoryEntry entry = new DirectoryEntry();
            entry.Path = _EntryPath;

            _DirectorySearcher = new DirectorySearcher(entry);
        }

        /// <summary>
        /// Retrieve all user
        /// </summary>
        /// <param name="filter"> (&(objectCategory=person)(objectClass=user)(sAMAccountName=*)) </param>
        /// <returns> List of User</returns>
        public Dictionary<string, Model.Contact> RetrieveAllContact(string filter)
        {
            Dictionary<string, Model.Contact> dictionary = new Dictionary<string, Model.Contact>();
            _DirectorySearcher.Filter = filter;
            _DirectorySearcher.PropertiesToLoad.Add("displayName");
            _DirectorySearcher.PropertiesToLoad.Add("telephoneNumber");
            _DirectorySearcher.PropertiesToLoad.Add("Mobile");


            SearchResultCollection allUsers = _DirectorySearcher.FindAll();

            foreach (SearchResult result in allUsers)
            {
                if (result.Properties["displayName"].Count > 0 && 
                    !result.Properties["displayName"][0].ToString().Contains("CN=")
                    && !result.Properties["displayName"][0].ToString().Contains("System"))
                {
                    Model.Contact contact = new CommonLibrary.Model.Contact();
                    contact.FullName =  result.Properties["displayName"][0].ToString();
                    contact.HomePhone = result.Properties["telephoneNumber"].Count ==0? "" : result.Properties["telephoneNumber"][0].ToString();
                    contact.MobilePhone= result.Properties["Mobile"].Count ==0? "" : result.Properties["Mobile"][0].ToString();
                    
                    if(!dictionary.ContainsKey(contact.FullName))
                        dictionary.Add(contact.FullName, contact);
                }
            }

            return dictionary;
        }


    }
}

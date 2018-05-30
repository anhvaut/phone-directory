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


using System.Collections.Generic;
using System.DirectoryServices;
using Wollundra.ContactManagement.Model;

namespace Wollundra.ContactManagement.ActiveDirectory
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
            _DirectorySearcher.PropertiesToLoad.Add("facsimileTelephoneNumber");
            _DirectorySearcher.PropertiesToLoad.Add("homePhone");
            _DirectorySearcher.PropertiesToLoad.Add("homePostalAddress");
            _DirectorySearcher.PropertiesToLoad.Add("mail");
            _DirectorySearcher.PropertiesToLoad.Add("ipPhone");
          
           


            SearchResultCollection allUsers = _DirectorySearcher.FindAll();

            foreach (SearchResult result in allUsers)
            {
                if (result.Properties["displayName"].Count > 0 && 
                    !result.Properties["displayName"][0].ToString().Contains("CN=")
                    && !result.Properties["displayName"][0].ToString().Contains("System"))
                {
                    Model.Contact contact = new Model.Contact();
                    contact.FullName =  result.Properties["displayName"][0].ToString();
                    contact.BusinessPhone = result.Properties["telephoneNumber"].Count ==0? "" : result.Properties["telephoneNumber"][0].ToString();
                    contact.BusinessFax = result.Properties["facsimileTelephoneNumber"].Count == 0 ? "" : result.Properties["facsimileTelephoneNumber"][0].ToString();
                    contact.MobilePhone= result.Properties["Mobile"].Count ==0? "" : result.Properties["Mobile"][0].ToString();
                    contact.Address = result.Properties["homePostalAddress"].Count == 0 ? "" : result.Properties["homePostalAddress"][0].ToString();
                    contact.HomePhone = result.Properties["homePhone"].Count == 0 ? "" : result.Properties["homePhone"][0].ToString();
                    contact.Email = result.Properties["mail"].Count == 0 ? "" : result.Properties["mail"][0].ToString();
                    contact.IPPhone = result.Properties["ipPhone"].Count == 0 ? "" : result.Properties["ipPhone"][0].ToString();

                   
                        if (!dictionary.ContainsKey(contact.FullName))
                        {
                            dictionary.Add(contact.FullName, contact);
                        }
                    
                }
            }

            return dictionary;
        }

        public Model.Contact GetUserProfile(string username)
        {
           //Dictionary<string, Model.Contact> user=RetrieveAllContact("(sAMAccountName="+username+")",true);

          // return user[username];
            Model.Contact contact = new Model.Contact();

            _DirectorySearcher.Filter = "(SAMAccountName="+username+")";
            _DirectorySearcher.SearchScope = SearchScope.Subtree;
            SearchResult result = _DirectorySearcher.FindOne();
            if (result != null)
            {
                contact.FullName = result.Properties["displayName"][0].ToString();
                contact.BusinessPhone = result.Properties["telephoneNumber"].Count == 0 ? "" : result.Properties["telephoneNumber"][0].ToString();
                contact.BusinessFax = result.Properties["facsimileTelephoneNumber"].Count == 0 ? "" : result.Properties["facsimileTelephoneNumber"][0].ToString();
                contact.MobilePhone = result.Properties["Mobile"].Count == 0 ? "" : result.Properties["Mobile"][0].ToString();
                contact.Address = result.Properties["homePostalAddress"].Count == 0 ? "" : result.Properties["homePostalAddress"][0].ToString();
                contact.HomePhone = result.Properties["homePhone"].Count == 0 ? "" : result.Properties["homePhone"][0].ToString();
                contact.Email = result.Properties["mail"].Count == 0 ? "" : result.Properties["mail"][0].ToString();
                contact.IPPhone = result.Properties["ipPhone"].Count == 0 ? "" : result.Properties["ipPhone"][0].ToString();

            }

            return contact;

        }

        public void UpdateUserProfile(Model.Contact contact)
        {
            _DirectorySearcher.Filter = "(SAMAccountName=" + contact.Username + ")";
            _DirectorySearcher.SearchScope = SearchScope.Subtree;
            SearchResult result = _DirectorySearcher.FindOne();
            DirectoryEntry d = new DirectoryEntry();
            d.Path = result.Path;
           
            d.Properties["telephoneNumber"].Value = contact.BusinessPhone.Equals("")? null : contact.BusinessPhone;
            d.CommitChanges();
 
            d.Properties["facsimileTelephoneNumber"].Value = contact.BusinessFax.Equals("")? null : contact.BusinessFax;
            d.CommitChanges();
           
            d.Properties["Mobile"].Value = contact.MobilePhone.Equals("")? null : contact.MobilePhone;
            d.CommitChanges();
           
            d.Properties["homePostalAddress"].Value = contact.Address.Equals("") ? null : contact.Address;
            d.CommitChanges();
            
            d.Properties["homePhone"].Value = contact.HomePhone.Equals("")? null : contact.HomePhone;
            d.CommitChanges();

            d.Properties["ipPhone"].Value = contact.IPPhone.Equals("") ? null : contact.IPPhone;
            d.CommitChanges();

            //d.Properties["mail"].Value = contact.Email.Equals("") ? null : contact.Email;
            //d.CommitChanges();
        }

    }
}

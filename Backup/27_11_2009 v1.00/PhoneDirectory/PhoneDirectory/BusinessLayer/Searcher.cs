/**
 * Vu Tran
 * 22/11/2009
 */
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary.Model;

namespace PhoneDirectory.BusinessLayer
{
    public class Searcher
    {
        private Dictionary<string, Contact> _contacts = null;

        public Searcher()
        {
            _contacts = new Dictionary<string, Contact>();
        }

        /// <summary>
        /// Search all the contacts
        /// </summary>
        public Dictionary<string, Contact> SearchAll()
        {
            CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(Constants.CONGIF_FILE);

            //Outlook contact
            if (appConfig.GetValue("Outlook").Equals("yes"))
            {
                try
                {
                    _contacts = CommonLibrary.OutlookContact.ContactManagement.RetreiveAllContact();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Outlook not available " + ex.Message);
                }
            }


            if (appConfig.GetValue("ActiveDirectory").Equals("yes"))
            {
                //Active Directory Contact
                string domainName = appConfig.GetValue("DomainName");
                try
                {
                    CommonLibrary.ActiveDirectory.ContactManagement contactManagement = new CommonLibrary.ActiveDirectory.ContactManagement(domainName);
                    Dictionary<string, Contact> activeDirectoryContacts = contactManagement.RetrieveAllContact("(objectCategory=person)");

                    foreach (var k in activeDirectoryContacts)
                    {
                        if (_contacts.ContainsKey(k.Key))
                        {
                            _contacts.Add(k.Key + " (AD)", k.Value);
                        }
                        else
                        {
                            _contacts.Add(k.Key, k.Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wrong Domain Name  " + domainName);
                }
            }

            return _contacts;
        }

        public Dictionary<string, Contact> Contacts
        {
            get { return _contacts; }
            set { _contacts = value; }
        }
    }
}

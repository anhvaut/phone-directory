/**
 * Vu Tran
 * 22/11/2009
 */
using System;
using System.Windows.Forms;
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
                _contacts = CommonLibrary.OutlookContact.ContactManagement.RetreiveAllContact();
            }


            if (appConfig.GetValue("ActiveDirectory").Equals("yes"))
            {
                //Active Directory Contact
                string domainName = appConfig.GetValue("DomainName");
                try
                {
                    CommonLibrary.ActiveDirectory.ContactManagement contactManagement = new CommonLibrary.ActiveDirectory.ContactManagement(domainName);
                    Dictionary<string, Contact> activeDirectoryContacts = contactManagement.RetrieveAllContact("(&(objectCategory=person)(objectClass=user)(sAMAccountName=*))");

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
                    MessageBox.Show(ex.Message);
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

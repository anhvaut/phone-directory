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
using CommonLibrary;
using System.ComponentModel;


namespace PhoneDirectory.BusinessLayer
{
    public class Searcher
    {
        private Dictionary<string, Contact> _contacts = null;
        private BackgroundWorker backgroundWorker;

        public Searcher(BackgroundWorker backgroundWorker)
        {
            this.backgroundWorker = backgroundWorker;
            _contacts = new Dictionary<string, Contact>();
        }

        /// <summary>
        /// Search all the contacts
        /// </summary>
        public void SearchAll()
        {
            CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(CommonLibrary.Constants.GetConfigFilePath());


            if (CommonLibrary.Constants.IsActiveDirectory())
            {
                //Active Directory Contact

                string domainName = CommonLibrary.Constants.GetADDomain();
                

                try
                {
                    CommonLibrary.ActiveDirectory.ContactManagement contactManagement = new CommonLibrary.ActiveDirectory.ContactManagement(domainName);
                    Dictionary<string, Contact> activeDirectoryContacts = contactManagement.RetrieveAllContact("(objectCategory=person)");

                    foreach (var k in activeDirectoryContacts)
                    {
                        string key = k.Key;
                        if (_contacts.ContainsKey(k.Key))
                        {
                            key = HandleDuplicateContact(k.Key, k.Value);
                        }

                        if (key != null)
                        {
                            _contacts.Add(key, k.Value);
                            backgroundWorker.ReportProgress(1, key);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (CommonLibrary.Constants.IsDebugMode())
                    {
                        MessageBox.Show("Check Domain Name  " + domainName + ";" + ex.Message);
                    }

                    CommonLibrary.Utilities.Log.Create("Check Domain Name  " + domainName + ";" + ex.Message);
                }
            }

            //Outlook contact
            if (CommonLibrary.Constants.IsOutlook())
            {
                try
                {
                    bool accessEmail = false;
                    if (appConfig.GetValue("Email").Equals("yes")) accessEmail = true;

                    Dictionary<string, Contact> tmp_contacts = CommonLibrary.OutlookContact.ContactManagement.RetreiveAllContact(accessEmail);
                    foreach (var c in tmp_contacts)
                    {
                     
                        string key = c.Key;
                        if (_contacts.ContainsKey(c.Key))
                        {
                            key = HandleDuplicateContact(c.Key, c.Value);
                        }

                        if (key != null)
                        {
                            _contacts.Add(key, c.Value);
                            backgroundWorker.ReportProgress(1, key);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (CommonLibrary.Constants.IsDebugMode())
                    {
                        MessageBox.Show("Outlook:" + ex.Message);
                    }
                    CommonLibrary.Utilities.Log.Create("Outlook:" + ex.Message);
                }
            }

            //Outlook Express
            if (CommonLibrary.Constants.IsOutlookExpress())
            {

                try
                {

                    Dictionary<string, Contact> tmp_contacts = CommonLibrary.OutlookExpress.ContactManagement.RetreiveAllContact();
                    foreach (var c in tmp_contacts)
                    {

                        string key = c.Key;
                        if (_contacts.ContainsKey(c.Key))
                        {
                            key = HandleDuplicateContact(c.Key, c.Value);
                        }

                        if (key != null)
                        {
                            _contacts.Add(key, c.Value);
                            backgroundWorker.ReportProgress(1, key);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (CommonLibrary.Constants.IsDebugMode())
                    {
                        MessageBox.Show("Outlook Express;" + ex.Message);
                    }
                    CommonLibrary.Utilities.Log.Create("Outlook Express;" + ex.Message);
                }

            }
            //return _contacts;
        }

        private string HandleDuplicateContact(string key, Contact c)
        {
            int i = 0;
            for (; i <10; i++)
            {
                if (!_contacts.ContainsKey(key + " (" + i + ")"))
                {          
                       i++;
                       return key + " (" + i + ")";
                 }
            }

            return null;

        }

        public Dictionary<string, Contact> Contacts
        {
            get { return _contacts; }
            set { _contacts = value; }
        }
    }
}

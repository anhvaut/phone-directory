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
using System.Windows;
using System.Collections.Generic;
using Wollundra.ContactManagement.Model;
using Wollundra.ContactManagement.ActiveDirectory;
using Wollundra.ContactManagement.Outlook;
using Wollundra.ContactManagement.OutlookExpress;

using System.ComponentModel;
using Wollundra.App;
using Wollundra.Utilities;


namespace Wollundra.PhoneDirectory.BusinessLayer
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
            AppConfig appConfig = new AppConfig(Constants.GetConfigFilePath());


            if (Constants.IsActiveDirectory())
            {
                //Active Directory Contact

                string domainName = Constants.GetADDomain();
                

                try
                {
                    ContactManagement.ActiveDirectory.ContactManagement contactManagement = new ContactManagement.ActiveDirectory.ContactManagement(domainName);
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
                    if (Constants.IsDebugMode())
                    {
                        MessageBox.Show("Check Domain Name  " + domainName + ";" + ex.Message);
                    }

                    Utilities.Log.Create("Check Domain Name  " + domainName + ";" + ex.Message);
                }
            }

            //Outlook contact
            if (Constants.IsOutlook())
            {
                try
                {
                    bool accessEmail = false;
                    if (appConfig.GetValue("Email").Equals("yes")) accessEmail = true;

                    Dictionary<string, Contact> tmp_contacts = ContactManagement.Outlook.ContactManagement.RetreiveAllContact(accessEmail);
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
                    if (Constants.IsDebugMode())
                    {
                        MessageBox.Show("Outlook:" + ex.Message);
                    }
                    Utilities.Log.Create("Outlook:" + ex.Message);
                }
            }

            //Outlook Express
            if (Constants.IsOutlookExpress())
            {

                try
                {

                    Dictionary<string, Contact> tmp_contacts = ContactManagement.OutlookExpress.ContactManagement.RetreiveAllContact();
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
                    if (Constants.IsDebugMode())
                    {
                        MessageBox.Show("Outlook Express;" + ex.Message);
                    }
                    Utilities.Log.Create("Outlook Express;" + ex.Message);
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

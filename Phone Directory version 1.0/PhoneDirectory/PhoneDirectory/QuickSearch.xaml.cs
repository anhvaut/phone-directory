using System;
using System.Collections.Generic;
using System.Linq;
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

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

using Wollundra.ContactManagement.Model;
using Wollundra.App;


namespace Wollundra.PhoneDirectory
{
    /// <summary>
    /// Interaction logic for QuickSearch.xaml
    /// </summary>
    public partial class QuickSearch : Window
    {
        private System.ComponentModel.BackgroundWorker backgroundWorker = new System.ComponentModel.BackgroundWorker();
        private Dictionary<string, Contact> contacts = null;
        private Wollundra.PhoneDirectory.BusinessLayer.Searcher searcher = null;
        private int oldSelectedIndex = -1;
        private bool formStart = true;
        private bool quickSearchHide = false;
        //Thread t;

        public QuickSearch()
        {
           
            InitializeComponent();


            searcher = new PhoneDirectory.BusinessLayer.Searcher(backgroundWorker);
            contacts = new Dictionary<string, Contact>();

            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);

            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.WorkerReportsProgress = true;

           

            
        }

        private void btnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            quickSearchHide = true;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            formStart = false;
            AppConfig appConfig = new AppConfig(Constants.GetConfigFilePath());
            lbOrganisationName.Text = appConfig.GetValue("OrganisationName");
            if(appConfig.GetValue("DefaultLogo").Equals("no"))
            {
                try
                {
                    Uri imageUri = new Uri(appConfig.GetValue("OrganisationLogo"));
                    BitmapImage bi = new BitmapImage(new Uri(appConfig.GetValue("OrganisationLogo"), UriKind.RelativeOrAbsolute));
                    imgLogo.Source = bi;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Path of Logo");
                    Utilities.Log.Create("Invalid Path of Logo" + ex.Message);
                }
            }

           

            //this.Opacity = 1;
            try
            {
                string hexColor = appConfig.GetValue("Background");
                if (!hexColor.Equals(""))
                {
                    this.Background = BusinessLayer.Convert.HexColor2Brush(hexColor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Background value");
                Utilities.Log.Create("Invalid Background value" + ex.Message);

            }

            double width = BusinessLayer.PersonalProfile.GetQuickSearchWindowWidth();
            double height = BusinessLayer.PersonalProfile.GetQuickSearchWindowHeight();

            if (width != 0) this.Width = width;
            if (height != 0) this.Height = height;

            this.Top = System.Windows.SystemParameters.PrimaryScreenHeight - this.Height - 50;
            this.Left = System.Windows.SystemParameters.PrimaryScreenWidth - this.Width;

            txtName.Focus();

        }

        #region BackgroundWorker
        /// <summary> 
        /// Runs on secondary thread. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        /// <remarks></remarks> 
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Search through all contact and get result 
            //e.Result = this.SomeLongRunningMethodWPF();
            searcher.SearchAll();
            

            // Cancel if cancel button was clicked. 
            if (this.backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        /// <summary> 
        /// Method is called everytime backgroundWorker.ReportProgress is called which triggers ProgressChanged event. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        /// <remarks></remarks> 
        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // Update UI with % completed. 
            // e.ProgressPercentage.ToString() + "% processed.";
            contacts = searcher.Contacts;
            lbName.Items.Add(e.UserState.ToString());
            
            lbNumberOfContacts.Text = contacts.Count + " contacts";
        }

        /// <summary> 
        /// Called when DoWork has completed. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        /// <remarks></remarks> 
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Back on primary thread, can access ui controls

            if (e.Cancelled)
            {
                //"Process Cancelled.";
            }
            else
            {
                //"Processing completed. " + (string)e.Result + " rows processed.";
            }

            //this.myStoryboard.Stop(this.lastStackPanel); 

           
        }

        public void RunBackgroundWorker()
        {
            this.backgroundWorker.RunWorkerAsync();
        }

        public void RefreshContactList()
        {
            lbName.Items.Clear();
            searcher.Contacts = new Dictionary<string, Contact>();
            RunBackgroundWorker();
            
        }
        #endregion

       

        private void ViewData()
        {

            if (lbName.SelectedIndex != -1 && Constants.IsNotContain(lbName.SelectedItem.ToString()))
            {
                RemoveDetailsView();



                Contact contact = contacts[lbName.SelectedItem.ToString().Trim()];

                AppConfig appConfig = new AppConfig(Constants.GetConfigFilePath());

                Brush itemColor = new SolidColorBrush(Color.FromRgb(235, 235, 235));

                int itemIndex = lbName.SelectedIndex + 1;

                if (appConfig.GetValue("BusinessPhone").Equals("yes"))
                {
                    string business = Constants.BUSINESS_PHONE + " " + contact.BusinessPhone;
                    contacts.Add(business, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = business;
                    lbName.Items.Insert(itemIndex++, lbi);
                }

                if (appConfig.GetValue("HomePhone").Equals("yes"))
                {
                    string home = Constants.HOME_PHONE + " " + contact.HomePhone;
                    contacts.Add(home, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = home;
                    lbName.Items.Insert(itemIndex++, lbi);

                }

                if (appConfig.GetValue("MobilePhone").Equals("yes"))
                {
                    string mobile = Constants.MOBILE_PHONE + " " + contact.MobilePhone;
                    contacts.Add(mobile, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = mobile;
                    lbName.Items.Insert(itemIndex++, lbi);
                }



                if (appConfig.GetValue("BusinessFax").Equals("yes"))
                {
                    string businessfax = Constants.BUSINESS_FAX + " " + contact.BusinessFax;
                    contacts.Add(businessfax, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = businessfax;
                    lbName.Items.Insert(itemIndex++, lbi);
                }

                if (appConfig.GetValue("Email").Equals("yes"))
                {
                    string email = Constants.EMAIL + " " + contact.Email;
                    contacts.Add(email, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = email;
                    lbName.Items.Insert(itemIndex++, lbi);
                }

                if (appConfig.GetValue("Address").Equals("yes"))
                {
                    string address = Constants.ADDRESS + " " + contact.Address;
                    contacts.Add(address, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = address;
                    lbName.Items.Insert(itemIndex++, lbi);
                }

                oldSelectedIndex = lbName.SelectedIndex;
            }
            
        }

       

        private void RemoveDetailsView()
        {
            var x =
                        from u in contacts
                        where Constants.IsContain(u.Key)
                        select u.Key;

            string[] st = x.ToArray();

            for (int k = 0; k < st.Count(); k++)
            {

                contacts.Remove(st[k]);
                lbName.Items.RemoveAt(oldSelectedIndex + 1);
            }
        }

        private void lbName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewData();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            RemoveDetailsView();

            var x =
                   from u in contacts
                   //where u.Key.ToLower().Contains(txtName.Text.ToLower().Trim())
                   where u.Key.ToLower().StartsWith(txtName.Text.ToLower().Trim())
                   select u.Key;

            lbName.Items.Clear();
            foreach (string st in x)
            {
                lbName.Items.Add(st);
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (lbName.Items.Count > 0)
                {
                    txtName.Text = lbName.Items[0].ToString();
                    lbName.SelectedIndex = 0;
                    txtName.SelectionStart = txtName.Text.Length;
                }
                
            }
            if (e.Key == Key.Space)
            {
                //MessageBox.Show("ok");
                //txtName.Text = lbName.Items[0].ToString().Split(' ').ElementAt(0).ToString();
                
            }

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //this.Opacity = 1;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            //this.Opacity = 0.7;
        }

        private void lbName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(lbName.SelectedItem.ToString().Contains(Constants.EMAIL))
            {
                string email = lbName.SelectedItem.ToString();
               
                /*
                System.Threading.Thread thread = new System.Threading.Thread(
                new System.Threading.ThreadStart(
                    delegate()
                    {
                        try
                        {
                            int index = email.IndexOf(Constants.EMAIL);
                            email = email.Substring(index + Constants.EMAIL.Length, email.Length - index - Constants.EMAIL.Length);

                            CommonLibrary.OutlookContact.ContactManagement contactManagement = new CommonLibrary.OutlookContact.ContactManagement();       
                            contactManagement.ComposeMessage(email);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                    }
                ));

                thread.Start();
                */

                try
                {
                    int index = email.IndexOf(Constants.EMAIL);
                    email = email.Substring(index + Constants.EMAIL.Length, email.Length - index - Constants.EMAIL.Length);
                    System.Diagnostics.Process.Start("mailto:" + email);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    Utilities.Log.Create(ex.Message);
                }

                
                this.Hide();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
          
            if (!formStart)
            {

                BusinessLayer.PersonalProfile.SaveQuickSearchWindowSize((int)this.Width, (int)this.Height);
            }

        }

        private void imgLogo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AboutUs _AboutUs = new AboutUs();
            _AboutUs.Show();
        }

        public bool QuickSearchHide
        {
            get { return quickSearchHide; }
            set { quickSearchHide = true; }
        }
        
    }
}

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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

using System.IO;
using Wollundra.KeyboardHookLib;
using Wollundra.ProductLib;
using Wollundra.App;



namespace Wollundra.PhoneDirectory
{
    /// <summary>
    /// Interaction logic for MainGUI.xaml
    /// </summary>
    public partial class MainGUI : Window
    {

        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAboutUs;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        //private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuEditMyProfile;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNewContact;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private QuickSearch _QuickSearch = null;

        private KeyboardHookLib.KeyboardHook hook = new KeyboardHookLib.KeyboardHook();
        private bool hookKeyPressed = false;

        public MainGUI()
        {
            
            InitializeComponent();

            try
            {
                //Run the thread to load all contacts
                _QuickSearch = new QuickSearch();
                _QuickSearch.RunBackgroundWorker();
                _QuickSearch.Top = System.Windows.SystemParameters.PrimaryScreenHeight - _QuickSearch.Height - 50;
                _QuickSearch.Left = System.Windows.SystemParameters.PrimaryScreenWidth - _QuickSearch.Width;

                //Check Start up
                try
                {
                    if (Constants.IsRunAsWindowsService() && !ApplicationStartUp.IsExistRunKey())
                    {
                        ApplicationStartUp.Save(Environment.CurrentDirectory + @"\PhoneDirectory.exe");
                    }
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(ex.Message);
                }

                //register event for shortkey

                // register the event that is fired after the key press.
                hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
                // register the control + alt + F12 combination as hot key.

                //Register Control + Alt + P for host key
                hook.RegisterHotKey(KeyboardHookLib.ModifierKeys.Control | KeyboardHookLib.ModifierKeys.Alt, Keys.P);
               


                //Setup icon and menu

                NotifyMenu = new System.Windows.Forms.ContextMenuStrip();
                mnuAboutUs = new System.Windows.Forms.ToolStripMenuItem();
                mnuExit = new System.Windows.Forms.ToolStripMenuItem();
                //mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
                mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
                mnuEditMyProfile = new System.Windows.Forms.ToolStripMenuItem();
                mnuAddNewContact = new System.Windows.Forms.ToolStripMenuItem();
                mnuEditMyProfile.Click += new EventHandler(mnuEditMyProfile_Click);
                mnuRefresh.Click += new EventHandler(mnuRefresh_Click);
                mnuAddNewContact.Click += new EventHandler(mnuAddNewContact_Click);
                mnuAboutUs.Click += new EventHandler(mnuAboutUs_Click);

                // 
                // mnuAboutUs
                // 
                mnuAboutUs.Name = "mnuAboutUs";
                mnuAboutUs.Size = new System.Drawing.Size(152, 22);
                mnuAboutUs.Text = "About Us";

                // 
                // mnuExit
                // 
                mnuExit.Name = "mnuExit";
                mnuExit.Size = new System.Drawing.Size(152, 22);
                mnuExit.Text = "Exit";
                mnuExit.Click += new EventHandler(mnuExit_Click);


                // 
                // mnuRefresh
                // 
                mnuRefresh.Name = "mnuRefresh";
                mnuRefresh.Size = new System.Drawing.Size(152, 22);
                mnuRefresh.Text = "Refresh";

                // 
                // mnuOptions
                // 
                mnuEditMyProfile.Name = "mnuEditMyProfile";
                mnuEditMyProfile.Size = new System.Drawing.Size(152, 22);
                mnuEditMyProfile.Text = "Edit My Profile";

                // 
                // mnuAddNewContact
                // 
                mnuAddNewContact.Name = "mnuAddNewContact";
                mnuAddNewContact.Size = new System.Drawing.Size(152, 22);
                mnuAddNewContact.Text = "Add New Contact";

                // 
                // NotifyMenu
                // 
                NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mnuAboutUs,
            mnuAddNewContact,
            mnuEditMyProfile,
            mnuRefresh,
            mnuExit});
                NotifyMenu.Name = "NotifyMenu";
                NotifyMenu.Size = new System.Drawing.Size(153, 92);


                // NotifyIcon
                m_notifyIcon = new System.Windows.Forms.NotifyIcon();
                m_notifyIcon.ContextMenuStrip = NotifyMenu;
                m_notifyIcon.BalloonTipText = "The app has been minimised. Click the tray icon to show.";
                m_notifyIcon.BalloonTipTitle = "Telephone Directory";
                m_notifyIcon.Text = "Telephone Directory";
                m_notifyIcon.Icon = new System.Drawing.Icon(Constants.GetApplicationPath() + @"Icons\Icon.ico");
                m_notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(m_notifyIcon_MouseClick);
                ShowTrayIcon(true);

                //Copy compulsory library for outllok to run
                //try
                //{
                //    CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(CommonLibrary.Constants.GetConfigFilePath());


                //    if (CommonLibrary.Constants.IsOutlookExpress())
                //    {
                //        DirectoryInfo di = new DirectoryInfo("C:/Program files/NKTWab/bin");
                //        if (!di.Exists)
                //        {
                //            di.Create();
                //            File.Copy(Constants.GetApplicationPath() + "nktwab.dll", @"C:\Program files\NKTWab\bin\nktwab.dll");

                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    //System.Windows.Forms.MessageBox.Show(ex.Message);
                //    CommonLibrary.Utilities.Log.Create(ex.Message);
                //}


                //Checking the License
                int i = ProductLib.Licensing.LicenseHandler.IsProductActivated();
                if (i == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Telephone Directory;Your product has not activated yet!");
                    Close();
                }
                if (i == 1)
                {
                    System.Windows.Forms.MessageBox.Show("Telephone Directory;Your product key is expired!");
                    Close();
                }

                
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        void mnuRefresh_Click(object sender, EventArgs e)
        {
            if (_QuickSearch != null) _QuickSearch.RefreshContactList();
            //_QuickSearch = null;
            //throw new NotImplementedException();
        }

        void mnuAboutUs_Click(object sender, EventArgs e)
        {
            AboutUs _AboutUs = new AboutUs();
            _AboutUs.Show();
            //throw new NotImplementedException();
           
        }

        void mnuAddNewContact_Click(object sender, EventArgs e)
        {
            AddNewContact _AddNewContact = new AddNewContact();
            _AddNewContact.Show();
            
        }

        void mnuEditMyProfile_Click(object sender, EventArgs e)
        {
            EditProfile _EditProfile = new EditProfile();
            _EditProfile.Show();
            
        }

        void mnuExit_Click(object sender, EventArgs e)
        {
            if (_QuickSearch != null) _QuickSearch.Close();
            this.Close();
            //throw new NotImplementedException();
        }

       

        void m_notifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DisplayQuickSearch();
                
            }
           
        }

        private void DisplayQuickSearch()
        {
            try
            {

                if (_QuickSearch == null)
                {
                    _QuickSearch = new QuickSearch();
                    _QuickSearch.RunBackgroundWorker();

                    _QuickSearch.Top = System.Windows.SystemParameters.PrimaryScreenHeight - _QuickSearch.Height - 50;
                    _QuickSearch.Left = System.Windows.SystemParameters.PrimaryScreenWidth - _QuickSearch.Width;
                    _QuickSearch.Show();

                    hookKeyPressed = true;

                }
                else
                {
                   
                    _QuickSearch.Show();
                   
                    //_QuickSearch.QuickSearchHide = false;
                    hookKeyPressed = true;

                }
            }
            catch (Exception ex)
            {
                _QuickSearch = new QuickSearch();
                _QuickSearch.RunBackgroundWorker();
                _QuickSearch.Top = System.Windows.SystemParameters.PrimaryScreenHeight - _QuickSearch.Height - 50;
                _QuickSearch.Left = System.Windows.SystemParameters.PrimaryScreenWidth - _QuickSearch.Width;
                _QuickSearch.Show();
            }
        }

        void ShowTrayIcon(bool show)
        {
            if (m_notifyIcon != null)
                m_notifyIcon.Visible = show;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_notifyIcon.Dispose();
            m_notifyIcon = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }


        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {


            if (hookKeyPressed )
            {
                _QuickSearch.Hide();
                hookKeyPressed = false;
            }
            else
            {
                DisplayQuickSearch();
                _QuickSearch.Activate();
            }
            
        }
    }
}

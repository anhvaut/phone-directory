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

namespace PhoneDirectory
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
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuEditMyProfile;

        public MainGUI()
        {
            
            InitializeComponent();

            try
            {
                CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(BusinessLayer.Constants.CONGIF_FILE);
                
                if (appConfig.GetValue("FirstRun").Equals("yes"))
                {
                    Options _Options = new Options();
                    _Options.Show();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("MainGUI:" + ex.Message);
            }

            NotifyMenu = new System.Windows.Forms.ContextMenuStrip();
            mnuAboutUs = new System.Windows.Forms.ToolStripMenuItem();
            mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            mnuEditMyProfile = new System.Windows.Forms.ToolStripMenuItem();
            mnuEditMyProfile.Click += new EventHandler(mnuEditMyProfile_Click);
            mnuOptions.Click += new EventHandler(mnuOptions_Click);

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
            // mnuOptions
            // 
            mnuOptions.Name = "mnuOptions";
            mnuOptions.Size = new System.Drawing.Size(152, 22);
            mnuOptions.Text = "Options";

            // 
            // mnuOptions
            // 
            mnuEditMyProfile.Name = "mnuEditMyProfile";
            mnuEditMyProfile.Size = new System.Drawing.Size(152, 22);
            mnuEditMyProfile.Text = "Edit My Profile";

            // 
            // NotifyMenu
            // 
            NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mnuOptions,
            mnuEditMyProfile,
            mnuAboutUs,
            mnuExit});
            NotifyMenu.Name = "NotifyMenu";
            NotifyMenu.Size = new System.Drawing.Size(153, 92);



            // NotifyIcon
            m_notifyIcon = new System.Windows.Forms.NotifyIcon();
            m_notifyIcon.ContextMenuStrip = NotifyMenu;
            m_notifyIcon.BalloonTipText = "The app has been minimised. Click the tray icon to show.";
            m_notifyIcon.BalloonTipTitle = "The App";
            m_notifyIcon.Text = "The App";
            m_notifyIcon.Icon = new System.Drawing.Icon(@"Icons\Icon.ico");
            m_notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(m_notifyIcon_MouseClick);
            ShowTrayIcon(true);
        }

        void mnuEditMyProfile_Click(object sender, EventArgs e)
        {
            EditProfile _EditProfile = new EditProfile();
            _EditProfile.Show();
            //throw new NotImplementedException();
        }

        void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
            //throw new NotImplementedException();
        }

        void mnuOptions_Click(object sender, EventArgs e)
        {
            Options _Options = new Options();
            _Options.Show();
        }

        void m_notifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                QuickSearch _QuickSearch = new QuickSearch();
                _QuickSearch.Show();
               

                _QuickSearch.Top = System.Windows.SystemParameters.PrimaryScreenHeight - _QuickSearch.Height - 50;
                _QuickSearch.Left = System.Windows.SystemParameters.PrimaryScreenWidth - _QuickSearch.Width;
                
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
    }
}

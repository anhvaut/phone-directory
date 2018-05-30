//21/11/2009
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiveDs;
using System.DirectoryServices;
using CommonLibrary.ActiveDirectory;

namespace PhoneDirectory
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
           
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {
         
          
        }

        private void lbOrganisationName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               
                QuickSearchForm quickSearchForm = new QuickSearchForm();
                quickSearchForm.Show();
                quickSearchForm.Location = new Point(Screen.PrimaryScreen.Bounds.Right - quickSearchForm.Width , Screen.PrimaryScreen.Bounds.Bottom - quickSearchForm.Height - 50);
                
            }
        }

        private void MainGUI_Paint(object sender, PaintEventArgs e)
        {
            this.Hide();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuOptions_Click(object sender, EventArgs e)
        {
            OptionsForm optionForms = new OptionsForm();
            optionForms.Show();
        }

        private void mnuAboutUs_Click(object sender, EventArgs e)
        {
            AboutUsForm aboutUs = new AboutUsForm();
            aboutUs.Show();
        }
    }
}

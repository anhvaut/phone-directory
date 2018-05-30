using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhoneDirectory
{
    public partial class OptionsForm : Form
    {
        CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(BusinessLayer.Constants.CONGIF_FILE);
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            

            if(appConfig.GetValue("ActiveDirectory").Equals("yes"))
            {
                ckActiveDirectory.Checked = true;
            }
            if (appConfig.GetValue("Outlook").Equals("yes"))
            {
                ckOutlook.Checked = true;
            }

            if (appConfig.GetValue("HomePhone").Equals("yes"))
            {
                ckHomePhone.Checked = true;
            }

            if (appConfig.GetValue("MobilePhone").Equals("yes"))
            {
                ckMobilePhone.Checked = true;
            }

            if (appConfig.GetValue("BusinessPhone").Equals("yes"))
            {
                ckBusinessPhone.Checked = true;
            }

            if (appConfig.GetValue("BusinessFax").Equals("yes"))
            {
                ckBusinessFax.Checked = true;
            }

            if (appConfig.GetValue("Address").Equals("yes"))
            {
                ckAddress.Checked = true;
            }

            if (appConfig.GetValue("Email").Equals("yes"))
            {
                ckEmail.Checked = true;
            }

            if (appConfig.GetValue("WindowsService").Equals("yes"))
            {
                 ckWindowService.Checked = true;
            }

            txtDomain.Text = appConfig.GetValue("DomainName");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (ckActiveDirectory.Checked)
            {
                appConfig.SaveValue("ActiveDirectory", "yes");
            }
            else
            {
                appConfig.SaveValue("ActiveDirectory", "no");
            }

            if (ckOutlook.Checked)
            {
                appConfig.SaveValue("Outlook", "yes");
            }
            else
            {
                appConfig.SaveValue("Outlook", "no");
            }

            if (ckHomePhone.Checked)
            {
                appConfig.SaveValue("HomePhone", "yes");
            }
            else
            {
                appConfig.SaveValue("HomePhone", "no");
            }

            if (ckMobilePhone.Checked)
            {
                appConfig.SaveValue("MobilePhone", "yes");
            }
            else
            {
                appConfig.SaveValue("MobilePhone", "no");
            }

            if (ckBusinessPhone.Checked)
            {
                appConfig.SaveValue("BusinessPhone", "yes");
            }
            else
            {
                appConfig.SaveValue("BusinessPhone", "no");
            }

            if (ckBusinessFax.Checked)
            {
                appConfig.SaveValue("BusinessFax", "yes");
            }
            else
            {
                appConfig.SaveValue("BusinessFax", "no");
            }

            if (ckAddress.Checked)
            {
                appConfig.SaveValue("Address", "yes");
            }
            else
            {
                appConfig.SaveValue("Address", "no");
            }

            if (ckEmail.Checked)
            {
                appConfig.SaveValue("Email", "yes");
            }
            else
            {
                appConfig.SaveValue("Email", "no");
            }

            if (ckWindowService.Checked)
            {
                appConfig.SaveValue("WindowsService", "yes");
                BusinessLayer.ApplicationStartUp.Save(Application.ExecutablePath.ToString());
            }
            else
            {
                appConfig.SaveValue("WindowsService", "no");
                BusinessLayer.ApplicationStartUp.Delete();
            }

            appConfig.SaveValue("DomainName", txtDomain.Text.Trim());
            
            this.Close();
        }
    }
}

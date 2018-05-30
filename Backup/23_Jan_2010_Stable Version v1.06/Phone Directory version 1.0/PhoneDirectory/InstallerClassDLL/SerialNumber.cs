using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstallerClassDLL
{
    public partial class SerialNumber : Form
    {
        public SerialNumber(string eventName, System.Configuration.Install.InstallContext context , System.Collections.IDictionary savedState)
        {
            InitializeComponent();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CommonLibrary.Licensing.LicenseHandler.ActiveProductKey(txtProductKey.Text.ToUpper());
            this.DialogResult = DialogResult.OK;
            
        }

        private void txtProductKey_TextChanged(object sender, EventArgs e)
        {
            if (txtProductKey.Text.Trim().Length == 29)
            {
                if (CommonLibrary.Licensing.LicenseHandler.ValidProductKey(txtProductKey.Text.ToUpper()) != null)
                {
                    btnOK.Enabled = true;
                    imgPass.Visible = true;
                    imgFail.Visible = false;
                }
                else
                {
                    imgPass.Visible = false;
                    imgFail.Visible = true;
                    btnOK.Enabled = false;
                }
            }
            else
            {
               
                btnOK.Enabled = false;
            }
        }
    }
}

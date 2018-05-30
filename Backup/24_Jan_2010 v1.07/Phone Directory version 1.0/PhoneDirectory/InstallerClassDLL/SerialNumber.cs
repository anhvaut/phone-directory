using System;
using System.Collections.Generic;
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

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wollundra.ProductLib.Licensing;

namespace Wollundra.InstallerClassDLL
{
    public partial class SerialNumber : Form
    {
        public SerialNumber(string eventName, System.Configuration.Install.InstallContext context , System.Collections.IDictionary savedState)
        {
            InitializeComponent();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ProductLib.Licensing.LicenseHandler.ActiveProductKey(txtProductKey.Text.ToUpper());
            this.DialogResult = DialogResult.OK;
            
        }

        private void txtProductKey_TextChanged(object sender, EventArgs e)
        {
            if (txtProductKey.Text.Trim().Length == 29)
            {
                if (ProductLib.Licensing.LicenseHandler.ValidProductKey(txtProductKey.Text.ToUpper()) != null)
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

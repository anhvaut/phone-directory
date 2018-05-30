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

using Wollundra.App;
using Wollundra.ContactManagement;

namespace Wollundra.PhoneDirectory
{
    /// <summary>
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {

        ContactManagement.ActiveDirectory.ContactManagement contactManagement = null;
        ContactManagement.Model.Contact contact = null;
        public EditProfile()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();

                int i = username.IndexOf(@"\");
                if (i != -1)
                {
                    username = username.Substring(i + 1, username.Length - i - 1);
                }
                txtUsername.Text = username;

                AppConfig appConfig = new AppConfig(Constants.GetConfigFilePath());
                contactManagement = new ContactManagement.ActiveDirectory.ContactManagement(Constants.GetADDomain());
                contact = contactManagement.GetUserProfile(username);
                contact.Username = username;

                txtHomePhone.Text = contact.HomePhone;
                txtMobilePhone.Text = contact.MobilePhone;
                txtBusinessPhone.Text = contact.BusinessPhone;
                txtBusinessFax.Text = contact.BusinessFax;
                txtEmail.Text = contact.Email;
                txtAddress.Text = contact.Address;
                txtIPPhone.Text = contact.IPPhone;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contact.HomePhone = txtHomePhone.Text.Trim();
                contact.MobilePhone = txtMobilePhone.Text.Trim();
                contact.BusinessPhone = txtBusinessPhone.Text.Trim();
                contact.BusinessFax = txtBusinessFax.Text.Trim();
                contact.Email = txtEmail.Text.Trim();
                contact.Address = txtAddress.Text.Trim();
                contact.IPPhone = txtIPPhone.Text.Trim();

                contactManagement.UpdateUserProfile(contact);

                MessageBox.Show("Update successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

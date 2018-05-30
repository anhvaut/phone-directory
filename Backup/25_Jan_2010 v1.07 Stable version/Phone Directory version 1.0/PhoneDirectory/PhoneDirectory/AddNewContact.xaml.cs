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
using Wollundra.ContactManagement.Model;
using Wollundra.ContactManagement.Outlook;


namespace Wollundra.PhoneDirectory
{
    /// <summary>
    /// Interaction logic for AddNewContact.xaml
    /// </summary>
    public partial class AddNewContact : Window
    {
        public AddNewContact()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!txtFullname.Text.Trim().Equals(""))
                {

                    ContactManagement.Model.Contact contact = new ContactManagement.Model.Contact();
                    ContactManagement.Outlook.ContactManagement contactManagment = new ContactManagement.Outlook.ContactManagement();

                    contact.FullName = txtFullname.Text;
                    contact.HomePhone = txtHomePhone.Text;
                    contact.MobilePhone = txtMobilePhone.Text;
                    contact.BusinessPhone = txtBusinessPhone.Text;
                    contact.BusinessFax = txtBusinessFax.Text;
                    contact.Address = txtAddress.Text;
                    contact.Email = txtEmail.Text;

                    contactManagment.AddNewContact(contact);

                    // this.Close();

                    MessageBox.Show("Save Successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to save.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

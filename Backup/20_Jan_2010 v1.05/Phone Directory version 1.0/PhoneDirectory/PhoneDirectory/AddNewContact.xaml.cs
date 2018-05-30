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


namespace PhoneDirectory
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
                    CommonLibrary.Model.Contact contact = new CommonLibrary.Model.Contact();
                    CommonLibrary.OutlookContact.ContactManagement contactManagment = new CommonLibrary.OutlookContact.ContactManagement();

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

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
using CommonLibrary;

namespace PhoneDirectory
{
    /// <summary>
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {
        CommonLibrary.ActiveDirectory.ContactManagement contactManagement = null;
        CommonLibrary.Model.Contact contact = null;
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

                CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(Constants.GetConfigFilePath());
                contactManagement = new CommonLibrary.ActiveDirectory.ContactManagement(CommonLibrary.Constants.GetADDomain());
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

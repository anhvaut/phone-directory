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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneDirectory.UCOptions
{
    /// <summary>
    /// Interaction logic for SearchApplications.xaml
    /// </summary>
    public partial class SearchApplications : UserControl
    {

        CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(BusinessLayer.Constants.GetConfigFilePath());

        public SearchApplications()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (appConfig.GetValue("ActiveDirectory").Equals("yes"))
            {
                ckAcctiveDirectory.IsChecked = true;
            }
            if (appConfig.GetValue("Outlook").Equals("yes"))
            {
                ckOutlook.IsChecked = true;
            }

            txtDomainName.Text = appConfig.GetValue("DomainName");


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ckAcctiveDirectory.IsChecked.Value)
                {
                    appConfig.SaveValue("ActiveDirectory", "yes");
                }
                else
                {
                    appConfig.SaveValue("ActiveDirectory", "no");
                }

                if (ckOutlook.IsChecked.Value)
                {
                    appConfig.SaveValue("Outlook", "yes");
                }
                else
                {
                    appConfig.SaveValue("Outlook", "no");
                }

                appConfig.SaveValue("DomainName", txtDomainName.Text.Trim());

                MessageBox.Show("Save Successful!");
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Options - Search Application " + ex.Message);
            }
        }

        private void ckAcctiveDirectory_Checked(object sender, RoutedEventArgs e)
        {
            txtDomainName.IsEnabled = true;
        }

        private void ckAcctiveDirectory_Unchecked(object sender, RoutedEventArgs e)
        {
            txtDomainName.IsEnabled = false;
        }
    }
}

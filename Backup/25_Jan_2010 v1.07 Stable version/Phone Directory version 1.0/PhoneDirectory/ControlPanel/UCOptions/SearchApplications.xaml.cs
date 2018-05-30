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
using Wollundra.App;
using Wollundra.Utilities;




namespace Wollundra.ControlPanel.UCOptions
{
    /// <summary>
    /// Interaction logic for SearchApplications.xaml
    /// </summary>
    public partial class SearchApplications : UserControl
    {

        Wollundra.App.AppConfig appConfig = new Wollundra.App.AppConfig(Wollundra.App.Constants.GetConfigFilePath());

        public SearchApplications()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (appConfig.GetValue("ActiveDirectory").Equals("yes"))
                {
                    ckAcctiveDirectory.IsChecked = true;
                }
                else
                {
                    txtDomainName.IsEnabled = false;

                }

                if (appConfig.GetValue("Outlook").Equals("yes"))
                {
                    ckOutlook.IsChecked = true;
                }
                if (appConfig.GetValue("OutlookExpress").Equals("yes"))
                {
                    ckOutlookExpress.IsChecked = true;
                }

                txtDomainName.Text = appConfig.GetValue("DomainName");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        

        private void btnCheckDomain_Click(object sender, RoutedEventArgs e)
        {
            if (Wollundra.App.Constants.IsValidDomainName(txtDomainName.Text))
            {
                
                
                imgCheck.Visibility = Visibility.Visible;
                imgFail.Visibility = Visibility.Hidden;
                lbDomainStatus.Visibility = Visibility.Visible;
                lbDomainStatus.Text = "OK";
                appConfig.SaveValue("DomainName", txtDomainName.Text.Trim());

            }
            else
            {
                imgCheck.Visibility = Visibility.Hidden;
                imgFail.Visibility = Visibility.Visible;
                lbDomainStatus.Visibility = Visibility.Visible;
                lbDomainStatus.Text = "Fail";
            }
        }

        private void ckAcctiveDirectory_Checked(object sender, RoutedEventArgs e)
        {
            txtDomainName.IsEnabled = true;
            
            appConfig.SaveValue("ActiveDirectory", "yes");
            

        }

        private void ckAcctiveDirectory_Unchecked(object sender, RoutedEventArgs e)
        {
            txtDomainName.IsEnabled = false;
           
            appConfig.SaveValue("ActiveDirectory", "no");
            

        }

        private void ckOutlook_Checked(object sender, RoutedEventArgs e)
        {
             try
             {
                 appConfig.SaveValue("Outlook", "yes");
               
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Options - Search Application " + ex.Message);
                 Utilities.Log.Create("Options - Search Application " + ex.Message);
             }
        }

        private void ckOutlook_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
               
               appConfig.SaveValue("Outlook", "no");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - Search Application " + ex.Message);
                Utilities.Log.Create("Options - Search Application " + ex.Message);
            }
        }

        private void ckOutlookExpress_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                
               appConfig.SaveValue("OutlookExpress", "yes");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - Search Application " + ex.Message);
                Utilities.Log.Create("Options - Search Application " + ex.Message);
            }

        }

        private void ckOutlookExpress_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
               
                appConfig.SaveValue("OutlookExpress", "no");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - Search Application " + ex.Message);
                Utilities.Log.Create("Options - Search Application " + ex.Message);
            }

        }

       
    }
}

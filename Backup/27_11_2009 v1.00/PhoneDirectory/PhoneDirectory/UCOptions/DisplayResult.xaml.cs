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
    /// Interaction logic for DisplayResult.xaml
    /// </summary>
    public partial class DisplayResult : UserControl
    {
        CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(BusinessLayer.Constants.CONGIF_FILE);
        public DisplayResult()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (appConfig.GetValue("HomePhone").Equals("yes"))
            {
                ckHomePhone.IsChecked = true;
            }

            if (appConfig.GetValue("MobilePhone").Equals("yes"))
            {
                ckMobilePhone.IsChecked = true;
            }

            if (appConfig.GetValue("BusinessPhone").Equals("yes"))
            {
                ckBusinessPhone.IsChecked = true;
            }

            if (appConfig.GetValue("BusinessFax").Equals("yes"))
            {
                ckBusinessFax.IsChecked = true;
            }

            if (appConfig.GetValue("Address").Equals("yes"))
            {
                ckAddress.IsChecked = true;
            }

            if (appConfig.GetValue("Email").Equals("yes"))
            {
                ckEmail.IsChecked = true;
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ckHomePhone.IsChecked.Value)
                {
                    appConfig.SaveValue("HomePhone", "yes");
                }
                else
                {
                    appConfig.SaveValue("HomePhone", "no");
                }

                if (ckMobilePhone.IsChecked.Value)
                {
                    appConfig.SaveValue("MobilePhone", "yes");
                }
                else
                {
                    appConfig.SaveValue("MobilePhone", "no");
                }

                if (ckBusinessPhone.IsChecked.Value)
                {
                    appConfig.SaveValue("BusinessPhone", "yes");
                }
                else
                {
                    appConfig.SaveValue("BusinessPhone", "no");
                }

                if (ckBusinessFax.IsChecked.Value)
                {
                    appConfig.SaveValue("BusinessFax", "yes");
                }
                else
                {
                    appConfig.SaveValue("BusinessFax", "no");
                }

                if (ckAddress.IsChecked.Value)
                {
                    appConfig.SaveValue("Address", "yes");
                }
                else
                {
                    appConfig.SaveValue("Address", "no");
                }

                if (ckEmail.IsChecked.Value)
                {
                    appConfig.SaveValue("Email", "yes");
                }
                else
                {
                    appConfig.SaveValue("Email", "no");
                }

                MessageBox.Show("Save Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
            }
        }
    }
}

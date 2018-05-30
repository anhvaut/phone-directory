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
using CommonLibrary.Licensing;

namespace ControlPanel.UCOptions
{
    /// <summary>
    /// Interaction logic for ProductLicense.xaml
    /// </summary>
    public partial class ProductLicense : UserControl
    {
        public ProductLicense()
        {
            InitializeComponent();
        }

        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                License license = LicenseHandler.ValidProductKey(txtProductKey.Text.Trim().ToUpper());
                if ( license != null)
                {
                    lbLicensingStatus.Visibility = Visibility.Visible;
                    lbExpireDate.Visibility = Visibility.Visible;
                    lbLicenseType.Visibility = Visibility.Visible;

                    lbLicensingStatus.Text = "Your Product is activated";
                    lbExpireDate.Text = "Expire Date: " + license.ExpireDate;
                    lbLicenseType.Text = "License Type: " + license.LicenseType.ToUpper();
                }
                else
                {
                    MessageBox.Show("Invalid Product Key");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
             try
             {
                 License license = LicenseHandler.GetProductKey();
                 if (license != null)
                 {
                     lbLicensingStatus.Visibility = Visibility.Visible;
                     lbExpireDate.Visibility = Visibility.Visible;
                     lbLicenseType.Visibility = Visibility.Visible;

                     lbLicensingStatus.Text = "Your Product is activated";
                     lbExpireDate.Text = "Expire Date: " + license.ExpireDate;
                     lbLicenseType.Text = "License Type: " + license.LicenseType.ToUpper();
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }

        private void txtProductKey_TextChanged(object sender, TextChangedEventArgs e)
        {
                      

            try
            {
                //Convert to Upper case
                txtProductKey.Text = txtProductKey.Text.ToUpper();

                ////Add -
                //string st = txtProductKey.Text;
                //if (st.Length > 5 && !st[5].Equals('-'))
                //{
                //    MessageBox.Show(txtProductKey.Text[5].ToString());
                //    txtProductKey.Text = txtProductKey.Text.Replace(st[5].ToString(), "-");
                    
                //}

                //Move cursor at the end of text
                txtProductKey.SelectionStart = txtProductKey.Text.Length;
                txtProductKey.SelectionLength = 0;


                if (txtProductKey.Text.Trim().Length == 29)
                {
                    License license = LicenseHandler.ValidProductKey(txtProductKey.Text.Trim().ToUpper());
                    if (license != null)
                    {
                        imgValid.Visibility = Visibility.Visible;
                        imgFail.Visibility = Visibility.Hidden;
                        btnActivate.IsEnabled = true;
                    }
                    else
                    {
                        imgValid.Visibility = Visibility.Hidden;
                        imgFail.Visibility = Visibility.Visible;
                        btnActivate.IsEnabled = false;
                    }


                }
                else
                {
                    imgValid.Visibility = Visibility.Hidden;
                    imgFail.Visibility = Visibility.Hidden;
                    btnActivate.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

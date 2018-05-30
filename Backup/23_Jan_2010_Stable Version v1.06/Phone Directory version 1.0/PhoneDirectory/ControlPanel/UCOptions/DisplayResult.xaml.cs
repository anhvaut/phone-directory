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

namespace ControlPanel.UCOptions
{
    /// <summary>
    /// Interaction logic for DisplayResult.xaml
    /// </summary>
    public partial class DisplayResult : UserControl
    {
        CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(CommonLibrary.Constants.GetConfigFilePath());
        public DisplayResult()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        

        private void ckHomePhone_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                
                appConfig.SaveValue("HomePhone", "yes");
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }

        }

        private void ckHomePhone_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                
                appConfig.SaveValue("HomePhone", "no");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }
        }

        private void ckMobilePhone_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

                appConfig.SaveValue("MobilePhone", "yes");
             

            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }
        }

        private void ckMobilePhone_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {

             
              appConfig.SaveValue("MobilePhone", "no");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }
        }

        private void ckBusinessPhone_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
               
                 appConfig.SaveValue("BusinessPhone", "yes");
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }
        }

        private void ckBusinessPhone_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {

               appConfig.SaveValue("BusinessPhone", "no");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }
        }

        private void ckBusinessFax_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
 
                 appConfig.SaveValue("BusinessFax", "yes");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }
        }

        private void ckBusinessFax_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {

                appConfig.SaveValue("BusinessFax", "no");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }
        }

        private void ckEmail_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

                appConfig.SaveValue("Email", "yes");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }
        }

        private void ckEmail_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {

                appConfig.SaveValue("Email", "no");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }
        }

        private void ckAddress_Checked(object sender, RoutedEventArgs e)
        {
            
            try
            {

                appConfig.SaveValue("Address", "yes");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }
        }

        private void ckAddress_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {

                appConfig.SaveValue("Address", "no");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - DisplayResult " + ex.Message);
                CommonLibrary.Utilities.Log.Create("Options - DisplayResult " + ex.Message);
            }
        }

       
      
    }
}

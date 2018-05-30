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
    /// Interaction logic for GeneralSettings.xaml
    /// </summary>
    public partial class GeneralSettings : UserControl
    {
        CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(BusinessLayer.Constants.CONGIF_FILE);

        public GeneralSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try{
                if (ckWindowService.IsChecked.Value)
                {
                    //MessageBox.Show(Environment.CurrentDirectory + "/PhoneDirectory.exe");
                    appConfig.SaveValue("WindowsService", "yes");
                    BusinessLayer.ApplicationStartUp.Save( Environment.CurrentDirectory + @"\PhoneDirectory.exe");
                }
                else
                {
                    appConfig.SaveValue("WindowsService", "no");
                    BusinessLayer.ApplicationStartUp.Delete();
                }

                MessageBox.Show("Save Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - General Settings " + ex.Message);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (appConfig.GetValue("WindowsService").Equals("yes"))
            {
                ckWindowService.IsChecked = true;
            }

        }
    }
}

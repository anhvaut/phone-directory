﻿using System;
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
using Wollundra.Utilities;
using Wollundra.App;

namespace Wollundra.ControlPanel.UCOptions
{
    /// <summary>
    /// Interaction logic for GeneralSettings.xaml
    /// </summary>
    public partial class GeneralSettings : UserControl
    {
        Wollundra.App.AppConfig appConfig = new Wollundra.App.AppConfig(Constants.GetConfigFilePath());

        public GeneralSettings()
        {
            InitializeComponent();
        }

       
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (appConfig.GetValue("WindowsService").Equals("yes"))
                {
                    ckWindowService.IsChecked = true;
                }

                if (appConfig.GetValue("DebugMode").Equals("yes"))
                {
                    ckDebugMode.IsChecked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ckWindowService_Checked(object sender, RoutedEventArgs e)
        {
            try{
                appConfig.SaveValue("WindowsService", "yes");
                ApplicationStartUp.Save(Environment.CurrentDirectory + @"\PhoneDirectory.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - General Settings " + ex.Message);
                Utilities.Log.Create("Options - General Settings " + ex.Message);
            }
        }

        private void ckWindowService_Unchecked(object sender, RoutedEventArgs e)
        {
            
            try
            {
                appConfig.SaveValue("WindowsService", "no");
                ApplicationStartUp.Delete();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - General Settings " + ex.Message);
                Utilities.Log.Create("Options - General Settings " + ex.Message);
            }
        }

        private void ckDebugMode_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                appConfig.SaveValue("DebugMode", "yes");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - General Settings " + ex.Message);
               Utilities.Log.Create("Options - General Settings " + ex.Message);
            }
        }

        private void ckDebugMode_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                appConfig.SaveValue("DebugMode", "no");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - General Settings " + ex.Message);
                Utilities.Log.Create("Options - General Settings " + ex.Message);
            }
        }

       

       
    }
}

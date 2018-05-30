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
using System.Windows.Shapes;

namespace ControlPanel
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        public Options()
        {
            InitializeComponent();
           
        }

        private void itLookAndFeel_Click(object sender, RoutedEventArgs e)
        {
            SPContainer.Children.Clear();
            UCOptions.LookandFeel LookandFeel=new UCOptions.LookandFeel();
            SPContainer.Children.Add(LookandFeel);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            SPContainer.Children.Clear();
            UCOptions.LookandFeel _LookandFeel = new UCOptions.LookandFeel();
            SPContainer.Children.Add(_LookandFeel);
              
        }

        private void itSearchApplications_Click(object sender, RoutedEventArgs e)
        {
            SPContainer.Children.Clear();
            UCOptions.SearchApplications _SearchApplication= new UCOptions.SearchApplications();
            SPContainer.Children.Add(_SearchApplication);
        }

        private void itDisplayResult_Click(object sender, RoutedEventArgs e)
        {
            SPContainer.Children.Clear();
            UCOptions.DisplayResult _DisplayResult = new UCOptions.DisplayResult();
            SPContainer.Children.Add(_DisplayResult);
        }

        private void itGeneralSettings_Click(object sender, RoutedEventArgs e)
        {
            SPContainer.Children.Clear();
            UCOptions.GeneralSettings _GeneralSettings = new UCOptions.GeneralSettings();
            SPContainer.Children.Add(_GeneralSettings);
        }

        private void itBackupandRestore_Click(object sender, RoutedEventArgs e)
        {
            SPContainer.Children.Clear();
            UCOptions.BackupandRestore _BackupandRestore = new UCOptions.BackupandRestore();
            SPContainer.Children.Add(_BackupandRestore);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

       
    }
}

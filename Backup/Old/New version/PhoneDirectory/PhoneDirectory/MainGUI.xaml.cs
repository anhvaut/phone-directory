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
    /// Interaction logic for MainGUI.xaml
    /// </summary>
    public partial class MainGUI : Window
    {
        public MainGUI()
        {
            
            InitializeComponent();

            try
            {
                CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(BusinessLayer.Constants.CONGIF_FILE);
                
                if (appConfig.GetValue("FirstRun").Equals("yes"))
                {
                    Options _Options = new Options();
                    _Options.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MainGUI:" + ex.Message);
            }
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mnuOption_Click(object sender, RoutedEventArgs e)
        {
            Options _Options = new Options();
            _Options.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}

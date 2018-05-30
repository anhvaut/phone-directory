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
using WPFColorPickerLib;
using Wollundra.App;

namespace Wollundra.ControlPanel.UCOptions
{
    /// <summary>
    /// Interaction logic for LookandFeel.xaml
    /// </summary>
    public partial class LookandFeel : UserControl
    {
        Wollundra.App.AppConfig appConfig = new Wollundra.App.AppConfig(Constants.GetConfigFilePath());

        public LookandFeel()
        {
            InitializeComponent();
        }

        private void btnEditColor_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = SelectColorDialog();
            if (solidColorBrush != null)
            {
                currentColor.Fill = solidColorBrush;

                try
                {
                    string hexColor = solidColorBrush.ToString();
                    appConfig.SaveValue("Background", hexColor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Options - Look And Feel " + ex.Message);
                    Utilities.Log.Create("Options - Look And Feel " + ex.Message);
                }
            }
        }


        /// <summary>
        /// Show the color dialog
        /// </summary>
        /// <returns> color: solidcolorbrush </returns>
        private SolidColorBrush SelectColorDialog()
        {
            SolidColorBrush solidColorBrush = null;
            ColorDialog colorDialog = new ColorDialog();
           
            if ((bool)colorDialog.ShowDialog())
            {
                solidColorBrush = new SolidColorBrush(colorDialog.SelectedColor);

            }
            return solidColorBrush;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            txtOrganisationName.Text = appConfig.GetValue("OrganisationName");
            txtOrganisationLogo.Text = appConfig.GetValue("OrganisationLogo");
            if (appConfig.GetValue("DefaultLogo").Equals("yes"))
            {
                ckDefaultLogo.IsChecked = true;
                button2.IsEnabled = false;
            }

            try
            {
                string strBackground = appConfig.GetValue("Background");
                if (!strBackground.Equals(""))
                {
                    currentColor.Fill = Convert.HexColor2Brush(strBackground);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Background value");
                Utilities.Log.Create("Invalid Background value; " + ex.Message);
            }
           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                appConfig.SaveValue("OrganisationName", txtOrganisationName.Text.Trim());

                btnSave.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Options - Look And Feel " + ex.Message);
                Utilities.Log.Create("Options - Look And Feel " + ex.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.InitialDirectory = "C:\\";
            dlg.Filter = "Images files (*.png,*.gif,*.jpg,*.bmp)|*.png;*.gif;*.jpg;*.bmp|All Files|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFileName = dlg.FileName;
                txtOrganisationLogo.Text = selectedFileName;

                appConfig.SaveValue("OrganisationLogo", txtOrganisationLogo.Text.Trim());
                
            }
        }

        private void ckDefaultLogo_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                appConfig.SaveValue("DefaultLogo", "yes");
                txtOrganisationLogo.IsEnabled = false;
                button2.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ckDefaultLogo_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                txtOrganisationLogo.IsEnabled = true;
                button2.IsEnabled = true;
                appConfig.SaveValue("DefaultLogo", "no");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtOrganisationName_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSave.IsEnabled = true;
        }
    }
}

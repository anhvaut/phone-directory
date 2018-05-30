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

namespace PhoneDirectory.UCOptions
{
    /// <summary>
    /// Interaction logic for LookandFeel.xaml
    /// </summary>
    public partial class LookandFeel : UserControl
    {
        CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(BusinessLayer.Constants.CONGIF_FILE);

        public LookandFeel()
        {
            InitializeComponent();
        }

        private void btnEditColor_Click(object sender, RoutedEventArgs e)
        {
            currentColor.Fill = SelectColorDialog();
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
           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            appConfig.SaveValue("OrganisationName", txtOrganisationName.Text.Trim());
            appConfig.SaveValue("OrganisationLogo", txtOrganisationLogo.Text.Trim());

            MessageBox.Show("Save Successful!");
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
                
            }
        }
    }
}

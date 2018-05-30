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

namespace Wollundra.ControlPanel.Parameters
{
    /// <summary>
    /// Interaction logic for ExportParameters.xaml
    /// </summary>
    public partial class ExportParameters : Window
    {
        public ExportParameters()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public string GetFilePath()
        {
            return txtFilePath.Text;
        }

        public void SetFilePath(string st)
        {
            txtFilePath.Text = st;
        }

        public string GetServerName()
        {
            return txtServerName.Text;
        }

        public void SetServerName(string serverName)
        {
            txtServerName.Text = serverName;
        }

        public void SetDisplayText(string st)
        {
            lbFilePath.Text = st;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.InitialDirectory = "C:\\";
            dlg.Filter = "Files (*.csv)|*.csv|All Files|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFilePath.Text = dlg.FileName;
            }
        }
    }
}

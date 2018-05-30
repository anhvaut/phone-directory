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
using System.IO;

namespace ControlPanel.UCOptions
{
    /// <summary>
    /// Interaction logic for BackupandRestore.xaml
    /// </summary>
    public partial class BackupandRestore : UserControl
    {
        CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(CommonLibrary.Constants.GetConfigFilePath());

        public BackupandRestore()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!appConfig.GetValue("ActiveDirectory").Equals("yes"))
            {
                btnPermissionsAllUser.IsEnabled = false;
                btnPermissions.IsEnabled = false;
                btnExport.IsEnabled = false;
                btnImport.IsEnabled = false;
            }

        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.InitialDirectory = "C:\\";
            dlg.Filter = "Backup files (*.config)|*.config|All Files|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFileName = dlg.FileName;

                File.Delete(CommonLibrary.Constants.GetConfigFilePath());
                File.Copy(selectedFileName, CommonLibrary.Constants.GetConfigFilePath());
                MessageBox.Show("Restore successful!");
            }

        }

        private void btnBackup_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.InitialDirectory = "C:\\";
            dlg.Filter = "Backup files (*.config)|*.config|All Files|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFileName = dlg.FileName;
                if (selectedFileName.IndexOf(".config") == -1) selectedFileName += ".config";

                File.Copy(CommonLibrary.Constants.GetConfigFilePath(),selectedFileName);
                MessageBox.Show("Backup successful!");
            }
        }

        private void btnPermissionsAllUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string domainName = CommonLibrary.Constants.GetObjectDomain();
                string toolsPath=Environment.CurrentDirectory +"/Tools";
                CommonLibrary.ActiveDirectory.Permissions p = new CommonLibrary.ActiveDirectory.Permissions(domainName,toolsPath);
                p.SetPermissionsForAllUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CommonLibrary.Utilities.Log.Create("Permission All Users:" + ex.Message);
            }
        }

        

        private void btnPermissions_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Parameters.UserIDRequired _UserIDRequired = new ControlPanel.Parameters.UserIDRequired();
                _UserIDRequired.ShowDialog();

                string userID = _UserIDRequired.GetUserID();

                if(!userID.Equals(""))
                {

                    string domainName = CommonLibrary.Constants.GetObjectDomain();
                    string toolsPath = Environment.CurrentDirectory + "/Tools";
                    CommonLibrary.ActiveDirectory.Permissions p = new CommonLibrary.ActiveDirectory.Permissions(domainName, toolsPath);
                    p.SetPermissionsForUser(userID);
                }
                _UserIDRequired.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CommonLibrary.Utilities.Log.Create("Permission:" + ex.Message);
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Parameters.ImportandExportParamters _Parameters = new ControlPanel.Parameters.ImportandExportParamters();
            _Parameters.SetDisplayText("Export contacts to *.csv file");
            _Parameters.SetFilePath("C:/export.csv");
            _Parameters.SetServerName(appConfig.GetValue("ServerName"));
            _Parameters.ShowDialog();
            
            string serverName = _Parameters.GetServerName();
            string File = _Parameters.GetFilePath();

            if (!serverName.Equals(""))
            {

                string toolsPath = Environment.CurrentDirectory + "/Tools";
                System.Diagnostics.Process.Start(toolsPath + "/export.bat", " " + File + " " + serverName);
                appConfig.SaveValue("ServerName", serverName);
            }

            _Parameters.Close();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                

                Parameters.ImportandExportParamters _Parameters = new ControlPanel.Parameters.ImportandExportParamters();
                _Parameters.SetDisplayText("Import contacts from *.csv file");
                _Parameters.SetServerName(appConfig.GetValue("ServerName"));
                _Parameters.ShowDialog();

                string serverName = _Parameters.GetServerName();
                string File = _Parameters.GetFilePath();

                if (!serverName.Equals(""))
                {
                    CommonLibrary.ActiveDirectory.Converts convert = new CommonLibrary.ActiveDirectory.Converts();
                    convert.CSV2LDIF(File, "Tools/tmp.ldf");

                    string toolsPath = Environment.CurrentDirectory + "/Tools";
                    System.Diagnostics.Process.Start(toolsPath + "/import.bat", " tmp.ldf " + serverName);

                    appConfig.SaveValue("ServerName",serverName);
                }
                _Parameters.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CommonLibrary.Utilities.Log.Create("Import Contacts" + ex.Message);
            }
        }

        
    }
}

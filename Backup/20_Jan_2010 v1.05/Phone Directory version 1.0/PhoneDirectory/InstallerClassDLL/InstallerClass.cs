using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

//For Control Panel
using System.Windows;



namespace InstallerClassDLL
{
    [RunInstaller(true)]
    public partial class InstallerClass : Installer
    {
        public InstallerClass()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            stateSaver.Add("TargetDir", Context.Parameters["assemblypath"].ToString().Replace("InstallerClassDLL.dll","")); 

            SerialNumber _SerialNumber = new SerialNumber("Install", Context, stateSaver);
            DialogResult dr = _SerialNumber.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                _SerialNumber.Dispose();
                throw new InstallException("Installation is cancelled!");
            }
            else
            {
                _SerialNumber.Dispose();
            }

            
            
        }

        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);

            // let's launch the application
            //Process.Start(@savedState["TargetDir"].ToString() + "ControlPanel.exe"); 

            
        }


    }
}

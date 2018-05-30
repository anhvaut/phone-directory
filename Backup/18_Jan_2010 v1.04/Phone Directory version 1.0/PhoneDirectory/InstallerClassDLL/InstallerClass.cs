using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Diagnostics;
using System.IO;


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

            //SerialNumber f = new SerialNumber("Install", Context, stateSaver);
            //f.ShowDialog();
            //f.Dispose();
            //base.Rollback(stateSaver);
            
        }

        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);

            // let's launch the application
            //Process.Start(@savedState["TargetDir"].ToString() + "ControlPanel.exe"); 

            
        }


    }
}

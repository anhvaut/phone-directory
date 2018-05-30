
/**************************************************************************\
* Telephone Directory v1.00                                                *
* http://www.wollundra.com.au  ,http://www.wollundra.com                   *
* Copyright (C) 2009-2010 by Wollundra Pty Ltd                             *
* Development Team : Tran The Vu                                           *
*                    John Fergus                                           *
*                    Shawns Richards                                       *
* ------------------------------------------------------------------------ *
*  The copyright of the Source code and its documentation is owned by      * 
* WOLLUNDRA Pty Ltd A.C.N 075 477 048. The unauthorised reproduction       *
* or distribution of this source code will result in criminal penalties.   *                                                     *
\**************************************************************************/

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



namespace Wollundra.InstallerClassDLL
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

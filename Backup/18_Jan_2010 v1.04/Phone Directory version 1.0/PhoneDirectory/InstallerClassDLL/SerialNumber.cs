using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstallerClassDLL
{
    public partial class SerialNumber : Form
    {
        public SerialNumber(string eventName, System.Configuration.Install.InstallContext context , System.Collections.IDictionary savedState)
        {
            InitializeComponent();
        }
    }
}

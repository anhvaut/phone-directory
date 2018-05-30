using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LicenseKey;

namespace LicenseLayout
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateKey gkey;
            //gkey = new GenerateKey();
            //gkey.LicenseTemplate = "xxxxxxxx-xxxx-xxxxxxxx-xxxx";
            //gkey.MaxTokens = 0;
            //gkey.UseBase10 = true;
            //gkey.UseBytes = true;
            //gkey.CreateKey();

            gkey = new GenerateKey();
            gkey.LicenseTemplate = "vvvvvvvvppppxxxxxxxx-wwwwxxxxxxxxxxxxxxxx-ssssssssxxxxxxxxxxxx-xxxxxxxxxxxxcccccccc-xxxxxxxxxxxxxxxxrrrr";
            gkey.MaxTokens = 5;
            gkey.ChecksumAlgorithm = Checksum.ChecksumType.Type1;
            gkey.AddToken(0, "v", LicenseKey.GenerateKey.TokenTypes.NUMBER, "34");
            gkey.AddToken(1, "p", LicenseKey.GenerateKey.TokenTypes.NUMBER, "6");
            gkey.AddToken(2, "w", LicenseKey.GenerateKey.TokenTypes.NUMBER, "8");
            gkey.AddToken(3, "s", LicenseKey.GenerateKey.TokenTypes.CHARACTER, "ab");
            gkey.AddToken(4, "r", LicenseKey.GenerateKey.TokenTypes.NUMBER, "3");
            gkey.UseBase10 = false;
            gkey.UseBytes = false;
            gkey.CreateKey();

       
            MessageBox.Show(gkey.GetLicenseKey());
        }
    }
}

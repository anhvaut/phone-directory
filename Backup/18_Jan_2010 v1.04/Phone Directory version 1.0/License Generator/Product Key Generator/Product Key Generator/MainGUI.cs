using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Product_Key_Generator
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {


            InitProductList();
            InitVersionList();
            InitTypeList();


        }


        private void InitProductList()
        {
            ComboBoxItem item = new ComboBoxItem();
            item.DisplayMember = "Telephone Directory";
            item.ValueMember = "TD";

            ArrayList productList = new ArrayList();
            productList.Add(item);

            cbProduct.DataSource = productList;
            cbProduct.DisplayMember = "DisplayMember";
            cbProduct.ValueMember = "ValueMember";
        }

        private void InitVersionList()
        {
            ComboBoxItem item = new ComboBoxItem();
            item.DisplayMember = "1.0.0.0";
            item.ValueMember = "1000";

            ArrayList versionList = new ArrayList();
            versionList.Add(item);

            cbVersion.DataSource = versionList;
            cbVersion.DisplayMember = "DisplayMember";
            cbVersion.ValueMember = "ValueMember";
        }

        private void InitTypeList()
        {
           
            ArrayList typeList = new ArrayList();

            ComboBoxItem item = new ComboBoxItem();
            item.DisplayMember = "Enterprise License";
            item.ValueMember = ProductLib.LicenseType.ENTERPRISE;
            typeList.Add(item);

            item = new ComboBoxItem();
            item.DisplayMember = "Volumn License";
            item.ValueMember = ProductLib.LicenseType.VOLUMN;
            typeList.Add(item);

            item = new ComboBoxItem();
            item.DisplayMember = "Evaluation license";
            item.ValueMember = ProductLib.LicenseType.EVALUATION;
            typeList.Add(item);

            item = new ComboBoxItem();
            item.DisplayMember = "Personal License";
            item.ValueMember = ProductLib.LicenseType.PERSONAL;
            typeList.Add(item);

            item = new ComboBoxItem();
            item.DisplayMember = "Trial License";
            item.ValueMember = ProductLib.LicenseType.TRIAL;
            typeList.Add(item);

            

            cbType.DataSource = typeList;
            cbType.DisplayMember = "DisplayMember";
            cbType.ValueMember = "ValueMember";
        }



        private void btnGenerate_Click(object sender, EventArgs e)
        {
            

            KeyGenerator keyGenerator = new KeyGenerator();
            keyGenerator.Version = cbVersion.SelectedValue.ToString();
            keyGenerator.ProductCode = cbProduct.SelectedValue.ToString();
            keyGenerator.Type = cbType.SelectedValue.ToString();
            keyGenerator.Volumn = nudVolumn.Value.ToString();
            keyGenerator.ExpireDate = dpExpireDate.Value.ToString("dd/MM/yyyy");
            keyGenerator.GenerateKey();

            //MessageBox.Show(keyGenerator.ExpireDate);
            txtProductKey.Text = keyGenerator.ProductKey;

            
            
            ProductLib.ProductKeyHandler productKeyHandler = new ProductLib.ProductKeyHandler(keyGenerator.ProductKey,"TD","1000");
            if (productKeyHandler.IsValidProductKey())
            {
                lbLicenseType.Text = productKeyHandler.GetLicenseType();
               lbExpireDate.Text = productKeyHandler.GetExpireDate();
            }

            //MessageBox.Show("" + productKeyHandler.ProductKey.IndexOf("TD"));
        }

       
    }
}

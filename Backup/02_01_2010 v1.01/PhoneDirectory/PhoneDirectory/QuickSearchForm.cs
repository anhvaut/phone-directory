/**
 * Vu The Tran
 * 21/11/09
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary.Model;
using CommonLibrary.OutlookContact;

namespace PhoneDirectory
{
    public partial class QuickSearchForm : Form
    {
        Dictionary<string, Contact> contacts=null;
        BusinessLayer.Searcher searcher=null;
        public QuickSearchForm()
        {
            InitializeComponent();
            searcher = new PhoneDirectory.BusinessLayer.Searcher();
        }

        private void QuickSearchForm_Load(object sender, EventArgs e)
        {

           
            contacts = searcher.SearchAll();
           
            var x = from u in contacts select u.Key;
            lbName.Items.AddRange(x.ToArray());
        }

        

        private void QuickSearchForm_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.7;
        }

        private void QuickSearchForm_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
            var x = 
                    from u in contacts
                    where u.Key.ToLower().StartsWith(txtName.Text.ToLower().Trim())
                    select u.Key;
            
            lbName.Items.Clear();
            lbName.Items.AddRange(x.ToArray());
        }

       

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                txtName.Text = lbName.Text;
                
                ViewData();
            }
        }

       
        private void lbName_Click(object sender, EventArgs e)
        {

            ViewData();
        }

        

        private void ViewData()
        {
            
            if (lbName.SelectedIndex!=-1 && BusinessLayer.Constants.IsNotContain(lbName.SelectedItem.ToString()))
            {
                var x =
                        from u in contacts
                        where BusinessLayer.Constants.IsContain(u.Key)
                        select u.Key;

                string[] st = x.ToArray();

                for (int k = 0; k < st.Count(); k++)
                {
                    contacts.Remove(st[k]);
                    lbName.Items.Remove(st[k]);
                }
                                

                int i = lbName.SelectedIndex;
                Contact contact = contacts[lbName.SelectedItem.ToString().Trim()];

                CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(BusinessLayer.Constants.CONGIF_FILE);

                if(appConfig.GetValue("HomePhone").Equals("yes"))
                {
                     string home = BusinessLayer.Constants.HOME_PHONE + " " + contact.HomePhone;
                     contacts.Add(home, contact);
                     lbName.Items.Insert(i + 1, home);
                }

                if (appConfig.GetValue("MobilePhone").Equals("yes"))
                {
                    string mobile = BusinessLayer.Constants.MOBILE_PHONE + " " + contact.MobilePhone;
                    contacts.Add(mobile, contact);
                    lbName.Items.Insert(i + 2, mobile);
                }

                if (appConfig.GetValue("BusinessPhone").Equals("yes"))
                {
                    string business = BusinessLayer.Constants.BUSINESS_PHONE + " " + contact.BusinessPhone;
                    contacts.Add(business, contact);
                    lbName.Items.Insert(i + 3, business);
                }

                if (appConfig.GetValue("BusinessFax").Equals("yes"))
                {
                    string businessfax = BusinessLayer.Constants.BUSINESS_FAX + " " + contact.BusinessFax;
                    contacts.Add(businessfax, contact);
                    lbName.Items.Insert(i + 4, businessfax);
                }

                if (appConfig.GetValue("Email").Equals("yes"))
                {
                    string email = BusinessLayer.Constants.EMAIL + " " + contact.Email;
                    contacts.Add(email, contact);
                    lbName.Items.Insert(i + 5, email);
                }

                if (appConfig.GetValue("Address").Equals("yes"))
                {
                    string address = BusinessLayer.Constants.ADDRESS + " " + contact.Address;
                    contacts.Add(address, contact);
                    lbName.Items.Insert(i + 6, address);
                }
                
               
               
                //lbName.SelectedIndex = i;
                
                
            }
        }

        private void lbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ViewData();
            }
        }

      
    }
}




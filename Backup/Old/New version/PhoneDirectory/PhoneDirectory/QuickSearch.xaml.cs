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
using CommonLibrary.Model;

namespace PhoneDirectory
{
    /// <summary>
    /// Interaction logic for QuickSearch.xaml
    /// </summary>
    public partial class QuickSearch : Window
    {
        Dictionary<string, Contact> contacts = null;
        BusinessLayer.Searcher searcher = null;
        int oldSelectedIndex = -1;

        public QuickSearch()
        {
           
            InitializeComponent();
            searcher = new PhoneDirectory.BusinessLayer.Searcher();
        }

        private void btnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(BusinessLayer.Constants.CONGIF_FILE);
            lbOrganisationName.Text = appConfig.GetValue("OrganisationName");
            try
            {
                Uri imageUri = new Uri(appConfig.GetValue("OrganisationLogo"));
                BitmapImage bi = new BitmapImage(new Uri(appConfig.GetValue("OrganisationLogo"), UriKind.RelativeOrAbsolute));
                imgLogo.Source = bi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Path of Logo");
            }
           
          
           
            contacts = searcher.SearchAll();

            var x = from u in contacts select u.Key;
            foreach (string st in x)
            {
                lbName.Items.Add(st);
            }
        }

        private void ViewData()
        {

            if (lbName.SelectedIndex != -1 && BusinessLayer.Constants.IsNotContain(lbName.SelectedItem.ToString()))
            {
                RemoveDetailsView();


               
                Contact contact = contacts[lbName.SelectedItem.ToString().Trim()];

                CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(BusinessLayer.Constants.CONGIF_FILE);

                Brush itemColor = new SolidColorBrush(Color.FromRgb(235, 235, 235));

                int itemIndex = lbName.SelectedIndex + 1;
                if (appConfig.GetValue("HomePhone").Equals("yes"))
                {
                    string home = BusinessLayer.Constants.HOME_PHONE + " " + contact.HomePhone;
                    contacts.Add(home, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = home;
                    lbName.Items.Insert(itemIndex++, lbi);
                   
                }

                if (appConfig.GetValue("MobilePhone").Equals("yes"))
                {
                    string mobile = BusinessLayer.Constants.MOBILE_PHONE + " " + contact.MobilePhone;
                    contacts.Add(mobile, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = mobile;
                    lbName.Items.Insert(itemIndex++, lbi);
                }

                if (appConfig.GetValue("BusinessPhone").Equals("yes"))
                {
                    string business = BusinessLayer.Constants.BUSINESS_PHONE + " " + contact.BusinessPhone;
                    contacts.Add(business, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = business;
                    lbName.Items.Insert(itemIndex++, lbi);
                }

                if (appConfig.GetValue("BusinessFax").Equals("yes"))
                {
                    string businessfax = BusinessLayer.Constants.BUSINESS_FAX + " " + contact.BusinessFax;
                    contacts.Add(businessfax, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = businessfax;
                    lbName.Items.Insert(itemIndex++, lbi);
                }

                if (appConfig.GetValue("Email").Equals("yes"))
                {
                    string email = BusinessLayer.Constants.EMAIL + " " + contact.Email;
                    contacts.Add(email, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = email;
                    lbName.Items.Insert(itemIndex++, lbi);
                }

                if (appConfig.GetValue("Address").Equals("yes"))
                {
                    string address = BusinessLayer.Constants.ADDRESS + " " + contact.Address;
                    contacts.Add(address, contact);
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.FontWeight = FontWeights.Bold;
                    lbi.Background = itemColor;
                    lbi.Content = address;
                    lbName.Items.Insert(itemIndex++, lbi);
                }

                oldSelectedIndex = lbName.SelectedIndex;
            }
        }

        private void RemoveDetailsView()
        {
            var x =
                        from u in contacts
                        where BusinessLayer.Constants.IsContain(u.Key)
                        select u.Key;

            string[] st = x.ToArray();

            for (int k = 0; k < st.Count(); k++)
            {

                contacts.Remove(st[k]);
                lbName.Items.RemoveAt(oldSelectedIndex + 1);
            }
        }

        private void lbName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewData();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            RemoveDetailsView();

            var x =
                   from u in contacts
                   where u.Key.ToLower().Contains(txtName.Text.ToLower().Trim())
                   select u.Key;

            lbName.Items.Clear();
            foreach (string st in x)
            {
                lbName.Items.Add(st);
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtName.Text = lbName.Items[0].ToString();
                lbName.SelectedIndex = 0;
            }
            if (e.Key == Key.Down)
            {
                
                
            }

        }
    }
}

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

namespace ControlPanel.Parameters
{
    /// <summary>
    /// Interaction logic for UserIDRequired.xaml
    /// </summary>
    public partial class UserIDRequired : Window
    {
        public UserIDRequired()
        {
            InitializeComponent();
        }

        public string GetUserID()
        {
            return txtUserID.Text;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}

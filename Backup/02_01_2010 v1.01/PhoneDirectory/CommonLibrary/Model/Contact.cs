/**
 * 21/11/09
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary.Model
{
    public class Contact
    {
        private string _fullname;
        private string _email;
        private string _address;
        private string _businessphone;
        private string _homephone;
        private string _mobilephone;
        private string _businessfax;

        public string FullName
        {
            set { _fullname = value; }
            get { return _fullname; }
        }

        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }

        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }

        public string BusinessPhone
        {
            set { _businessphone = value; }
            get { return _businessphone; }
        }

        public string HomePhone
        {
            set { _homephone = value; }
            get { return _homephone; }
        }

        public string MobilePhone
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }

        public string BusinessFax
        {
            set { _businessfax = value; }
            get { return _businessfax; }
        }
    }
}

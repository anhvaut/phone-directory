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


namespace Wollundra.ContactManagement.Model
{
    public class Contact
    {
        private string _username;
        private string _fullname;
        private string _email;
        private string _address;
        private string _businessphone;
        private string _homephone;
        private string _mobilephone;
        private string _businessfax;
        private string _ipPhone;

        public string Username
        {
            set { _username = value; }
            get { return _username; }
        }

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

        public string IPPhone
        {
            set { _ipPhone = value; }
            get { return _ipPhone; }
        }
    }
}

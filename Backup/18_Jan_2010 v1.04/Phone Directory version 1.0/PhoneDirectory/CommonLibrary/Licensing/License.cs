using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary.Licensing
{
    public class License
    {
        private string licensetype;
        private string expiredate;

        public string LicenseType
        {
            get { return licensetype; }
            set { licensetype = value; }
        }

        public string ExpireDate
        {
            get { return expiredate; }
            set { expiredate = value; }
        }
    }
}

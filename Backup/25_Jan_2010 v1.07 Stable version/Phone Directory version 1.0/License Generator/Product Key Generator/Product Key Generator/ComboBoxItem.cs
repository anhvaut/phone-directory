using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wollundra.Product_Key_Generator
{
    public class ComboBoxItem
    {
        private string displaymember = "";
        private string valuemember = "";

        public string DisplayMember
        {
            get { return displaymember;}
            set { displaymember = value; }
        }

        public string ValueMember
        {
            get { return valuemember; }
            set { valuemember = value; }
        }

    }
}

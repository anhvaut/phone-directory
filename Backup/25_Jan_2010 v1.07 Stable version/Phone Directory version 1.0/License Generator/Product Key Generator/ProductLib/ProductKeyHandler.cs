
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

namespace Wollundra.ProductLib
{
    public class ProductKeyHandler
    {
        private string characters = "UBCREPGHIXZLMNOFQDSTAVWJYK7169452083";
        private string productKey;
        private string productCode;
        private string version;


        public ProductKeyHandler(string productKey,string productCode, string version)
        {
            this.productKey = productKey;
            this.productCode = productCode;
            this.version = version;
            if (productKey.Length ==29)
            {
                Decode();
            }
        }

        public bool IsValidProductKey()
        {
            if (productKey.Length ==29 && productKey.IndexOf(version) == 0 && productKey.IndexOf(productCode) == 8)
            {
                return true;
            }
            return false;
        }

        public string GetExpireDate()
        {
            string[] a = productKey.Split('-');
            string year = a[4].Substring(0, a[4].Length - 1);
            string day = a[3].Substring(0, 2);
            string month = a[3].Substring(2, 2);

            return day + "/" + month + "/" + year ;
        }

        public string GetLicenseType()
        {
            string[] a = productKey.Split('-');

            string licenseType = a[1].Substring(0,1);
            if (licenseType.Equals(LicenseType.ENTERPRISE)) return "enterprise";
            else if (licenseType.Equals(LicenseType.EVALUATION)) return "evaluation";
            else if (licenseType.Equals(LicenseType.PERSONAL)) return "personal";
            else if (licenseType.Equals(LicenseType.VOLUMN)) return "volume";
            else if (licenseType.Equals(LicenseType.TRIAL)) return "trial";

            return "";
        }

        private void Decode()
        {
            //Crete encode key from product key
            string encodeKey = productKey[4].ToString() + productKey[7].ToString() + productKey[10].ToString() + productKey[16].ToString() + productKey[22].ToString() + productKey[28].ToString();
            int j = 0;

            string st = "";

            for (int i = 0; i < productKey.Length; i++)
            {


                if (i >= 0 && i < 4)
                {
                    //Encrypt the version
                    st += Sub2Characters(productKey[i].ToString(), encodeKey[j].ToString());
                    j++;
                }
                else if (i == 6)
                {
                    //Type of license
                    st += Sub2Characters(productKey[i].ToString(), encodeKey[j].ToString());
                    j++;
                }
                else if (i == 8)
                {
                    //Product Code
                    for (int k = 0; k < 2; k++)
                    {
                        st += Sub2Characters(productKey[k + i].ToString(), encodeKey[j].ToString());
                        j++;
                        if (j >= encodeKey.Length) j = 0;

                    }

                    i++;
                }
                else if (i == 12 || i == 18 || i == 24)
                {
                    //Volumn 
                    for (int k = 0; k < 4; k++)
                    {
                        st += Sub2Characters(productKey[k + i].ToString(), encodeKey[j].ToString());
                        j++;
                        if (j >= encodeKey.Length) j = 0;
                    }

                    i += 3;


                }

                else
                {
                    st += productKey[i].ToString();
                }

                if (j >= encodeKey.Length) j = 0;
            }

            productKey = st;


        }

        /// <summary>
        /// Get index in characters
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private int GetIndexByCharacter(string c)
        {

            for (int i = 0; i < characters.Length; i++)
            {
                if (c.Equals(characters[i].ToString()))
                {
                    return i;
                }
            }

            return 0;
        }

        private string Sub2Characters(string c1, string c2)
        {
            int z = GetIndexByCharacter(c1);
            int y = GetIndexByCharacter(c2);
            int x = z - y;
            if (x <= 0) x += 35;

            return characters[x].ToString();
        }


        private string ProductKey
        {
            get { return productKey; }
        }
    }
}

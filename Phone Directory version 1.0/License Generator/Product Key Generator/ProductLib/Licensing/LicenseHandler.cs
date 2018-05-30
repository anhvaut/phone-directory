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

using System;
using System.Collections.Generic;
using System.IO;
using Wollundra.Encoding;


namespace Wollundra.ProductLib.Licensing
{
    public class LicenseHandler
    {
        private static string productCode = "TD";
        private static string version = "1000";
        public static License ValidProductKey(string productKey)
        {

           
            ProductKeyHandler productKeyHandler = new ProductKeyHandler(productKey, productCode, version);

            if (productKeyHandler.IsValidProductKey())
            {
                License license = new License();
                license.ExpireDate = productKeyHandler.GetExpireDate();
                license.LicenseType = productKeyHandler.GetLicenseType();

                return license;
            }

            return null;
        }

        public static void ActiveProductKey(string productKey)
        {
            StreamWriter sw = new StreamWriter(Environment.SystemDirectory.ToString() + "/tdhash");
            sw.WriteLine(Encrypter.Encrypt(productKey));
            sw.Flush();
            sw.Close();
        }

        public static License GetProductKey()
        {
            if (File.Exists(Environment.SystemDirectory.ToString() + "/tdhash"))
            {
                              
                 StreamReader tr = new StreamReader(Environment.SystemDirectory.ToString() + "/tdhash");
                 string productKey = "";
                 if ((productKey = tr.ReadLine()) != null)
                 {
                     productKey = Decrypter.Decrypt(productKey);
                     ProductKeyHandler productKeyHandler = new ProductKeyHandler(productKey, productCode, version);

                     if (productKeyHandler.IsValidProductKey())
                     {
                         License license = new License();
                         license.ExpireDate = productKeyHandler.GetExpireDate();
                         license.LicenseType = productKeyHandler.GetLicenseType();
                         tr.Close();

                         return license;
                     }
                 }

                 tr.Close();
            }
            return null;
        }

        public static int IsProductActivated()
        {
            License license = GetProductKey();
            if (license == null) return 0; // not register yet

            string[] dayArray = license.ExpireDate.Split('/');

            DateTime expireDate = new DateTime(Int32.Parse(dayArray[2]),Int32.Parse(dayArray[1]),Int32.Parse(dayArray[0]));

            if (expireDate.CompareTo(DateTime.Now) < 0) return 1; //Expire
            

            return -1;
        }
    }
}

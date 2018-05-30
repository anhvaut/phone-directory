using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductLib;
using Microsoft.Win32;
using System.IO;


namespace CommonLibrary.Licensing
{
    public class LicenseHandler
    {
        public static License ValidProductKey(string productKey)
        {
           
            ProductKeyHandler productKeyHandler = new ProductKeyHandler(productKey, Constants.GetProductCode(), Constants.GetProductVersion());

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
            sw.WriteLine(Encode.Encrypter.Encrypt(productKey));
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
                     productKey = Encode.Decrypter.Decrypt(productKey);
                     ProductKeyHandler productKeyHandler = new ProductKeyHandler(productKey, Constants.GetProductCode(), Constants.GetProductVersion());

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

using System;
using System.Text;
using System.Security.Cryptography;

namespace CommonLibrary.Encode
{
    public class HexMD5
    {
        /// <summary>
        /// Encode string in MD5 code
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encode(string str)
        {

            StringBuilder sb = new StringBuilder();
            System.Text.ASCIIEncoding enc = new ASCIIEncoding();
            byte[] b = enc.GetBytes(str);


            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(b);

            // Build the final string by converting each byte
            // into hex and appending it to a StringBuilder

            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x2"));
            }


            // And return it
            return sb.ToString();
        }
    }
}

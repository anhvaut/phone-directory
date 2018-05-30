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

using System.Text;
using System.Security.Cryptography;

namespace Wollundra.Encoding
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

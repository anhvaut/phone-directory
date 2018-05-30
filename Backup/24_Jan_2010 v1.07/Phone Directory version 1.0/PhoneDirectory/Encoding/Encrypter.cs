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


namespace Wollundra.Encoding
{
    public class Encrypter
    {
        public Encrypter()
        {

        }

        public static string Encrypt(string text)
        {


            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            byte[] textBytes = encoding.GetBytes(text + HexMD5.Encode(KeyPairs.KEY_PAIR_1));
            byte[] keyBytes = encoding.GetBytes(HexMD5.Encode(KeyPairs.KEY_PAIR_2));

            int length = textBytes.Length > keyBytes.Length ? keyBytes.Length : textBytes.Length;
            for (int i = 0; i < length; i++)
            {
                textBytes[i] += keyBytes[i];
            }


            Base64Encoder base64Encoder = new Base64Encoder(textBytes);
            byte[] encodedBytes = encoding.GetBytes(base64Encoder.GetEncoded());


            return encoding.GetString(encodedBytes);
        }

    }
}

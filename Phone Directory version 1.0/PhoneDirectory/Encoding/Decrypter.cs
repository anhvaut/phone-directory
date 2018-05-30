
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
    public class Decrypter
    {
        public static string Decrypt(string text)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(HexMD5.Encode(KeyPairs.KEY_PAIR_2));

            byte[] encodedTextBytes = encoding.GetBytes(text);
            Base64Decoder base64Decoder = new Base64Decoder(encoding.GetChars(encodedTextBytes));
            byte[] decodedBytes = base64Decoder.GetDecoded();



            int length = decodedBytes.Length > keyBytes.Length ? keyBytes.Length : decodedBytes.Length;
            for (int i = 0; i < length; i++)
            {
                decodedBytes[i] -= keyBytes[i];
            }

            string decodedText = encoding.GetString(decodedBytes);

            return decodedText.Substring(0, decodedText.Length - HexMD5.Encode(KeyPairs.KEY_PAIR_1).Length);

        }
    }
}

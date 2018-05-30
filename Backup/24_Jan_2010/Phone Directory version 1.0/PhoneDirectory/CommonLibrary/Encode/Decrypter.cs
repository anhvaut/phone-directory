using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace CommonLibrary.Encode
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

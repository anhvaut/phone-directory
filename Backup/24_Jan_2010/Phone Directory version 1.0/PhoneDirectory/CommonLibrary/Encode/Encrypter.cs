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

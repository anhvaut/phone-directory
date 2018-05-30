using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wollundra.Product_Key_Generator
{
    public class KeyGenerator
    {
        
        private string characters = "UBCREPGHIXZLMNOFQDSTAVWJYK7169452083";

        private string version;
        private string productCode;
        private string type;
        private string volumn;
        private string expiredate;

        private string productKey;

        /// <summary>
        /// Constructor
        /// </summary>
        public KeyGenerator()
        {

        }

        public void GenerateKey()
        {
            string previousCharacter = "";

            Random r = new Random();

            productKey = version;

            for (int i = 4; i <= 25; i++)
            {
                if (i == 5 || i == 10 || i == 15 || i == 20)
                {
                    productKey += "-";
                }

                if (i == 5)
                {
                    //add license type
                    productKey += type;
                    previousCharacter = type;
                }
                else if(i==7 )
                {
                    //add product code
                    productKey += productCode;
                    i++;
                }
                else if (i == 10)
                {
                    //add volumn , number of copies
                    string prefix = "";
                    int nVolumn = Int32.Parse(volumn);
                    if (nVolumn < 10)
                    {
                        prefix = "VOL";
                    }
                    else if (nVolumn < 100)
                    {
                        prefix = "VO";
                    }
                    else if (nVolumn < 1000)
                    {
                        prefix = "V";
                    }

                    productKey += prefix + volumn;
                    
                    i += 3;
                }
                else if (i == 15)
                {
                    //day and month expire
                    string[] a = expiredate.Split('/');
                    productKey += a[0];//add day
                    productKey += a[1];//add month

                    i += 3;
                }
                else if (i == 20)
                {
                    //day and month expire
                    string[] a = expiredate.Split('/');
                    productKey += a[2];//add year
                    i += 4;
                }
                else
                {

                    string randomCharacter = GetCharacterByIndex(r.Next(35));
                    while (randomCharacter.Equals(previousCharacter))
                    {
                        randomCharacter = GetCharacterByIndex(r.Next(35));
                    }
                    productKey += randomCharacter;

                    previousCharacter = randomCharacter;
                }
            }

            Encode();
        }

        private void Encode()
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
                    st += Add2Characters(productKey[i].ToString(), encodeKey[j].ToString());
                    j++;
                }
                else if (i == 6)
                {
                    //Type of license
                    st += Add2Characters(productKey[i].ToString(), encodeKey[j].ToString());
                    j++;
                }
                else if (i == 8)
                {
                    //Product Code
                    for (int k = 0; k < 2; k++)
                    {
                        st += Add2Characters(productKey[k + i].ToString(), encodeKey[j].ToString());
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
                        st += Add2Characters(productKey[k + i].ToString(), encodeKey[j].ToString());
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


        private string GetCharacterByIndex(int i)
        {
            return characters[i].ToString();
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

        /// <summary>
        /// Add 2 characters to create new character
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        private string Add2Characters(string c1, string c2)
        {
            return characters[(GetIndexByCharacter(c1) + GetIndexByCharacter(c2)) % 35].ToString();
        }

        /// <summary>
        /// Set and Get Properties
        /// </summary>
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Volumn
        {
            get { return volumn; }
            set { volumn = value; }
        }

        public string ExpireDate
        {
            get { return expiredate; }
            set { expiredate = value; }
        }

        public string ProductKey
        {
            get { return productKey; }
        }
    }
}

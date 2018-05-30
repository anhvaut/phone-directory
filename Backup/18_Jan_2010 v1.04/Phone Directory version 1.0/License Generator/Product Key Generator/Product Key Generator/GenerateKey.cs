using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product_Key_Generator
{
    public class GenerateKey
    {
        //35 characters
        private string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private string productKey = "";
        private string version = "";
        

       
        public GenerateKey()
        {
            string version = "2001";
            string previousCharacter = "";

            Random r = new Random();

            productKey = version;

            for (int i = 4; i <= 25; i++)
            {
                if (i == 5 || i == 10 || i == 15 || i == 20)
                {
                    productKey += "-";
                }

                string randomCharacter = GetCharacterByIndex(r.Next(35));
                while (randomCharacter.Equals(previousCharacter))
                {
                    randomCharacter = GetCharacterByIndex(r.Next(35));
                }
                productKey += randomCharacter;

                previousCharacter = randomCharacter;
            }

           

           // Encode();

        }


       

        public string GetProductKey()
        {
            return productKey;
        }

        public void Encode()
        {
            //Crete encode key from product key
            string encodeKey = productKey[4].ToString() + productKey[10].ToString() + productKey[16].ToString() + productKey[22].ToString() + productKey[28].ToString();
            int j = 0;

            string st = "";

            for (int i = 0; i < productKey.Length; i++)
            {
              

                if (i >=0 && i<4)
                {
                    //Encrypt the version
                    st += Add2Characters(productKey[i].ToString(), encodeKey[j].ToString());
                    j++;
                }
                else
                {
                    st += productKey[i].ToString();
                }

                if (j >= encodeKey.Length) j = 0;
            }

            productKey = st;
        }

        public void Decode()
        {
            //Crete encode key from product key
            string encodeKey = productKey[4].ToString() + productKey[10].ToString() + productKey[16].ToString() + productKey[22].ToString() + productKey[28].ToString();
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
                else
                {
                    st += productKey[i].ToString();
                }

                if (j >= encodeKey.Length) j = 0;
            }

            productKey = st;


        }
        public string GetCharacterByIndex(int i)
        {
            return characters[i].ToString();
        }


        /// <summary>
        /// Get index in characters
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int GetIndexByCharacter(string c)
        {
           
            for (int i = 0; i < characters.Length; i++)
            {
                if(c.Equals(characters[i].ToString()))
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
        public string Add2Characters(string c1, string c2)
        {
            return characters[(GetIndexByCharacter(c1) + GetIndexByCharacter(c2)) % 35].ToString();
        }

        public string Sub2Characters(string c1, string c2)
        {
            int z = GetIndexByCharacter(c1);
            int y = GetIndexByCharacter(c2);
            int x = z - y;
            if (x <= 0) x += 35;
            
            return characters[x].ToString();
        }
    }
}

/**
 * Vu The Tran
 * 22/11/2009
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CommonLibrary
{
    public class AppConfig
    {
        private XmlDocument xdocAppConfig;
        private string configFile;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configFile"> Config Name</param>
        public AppConfig(string configFile)
        {
            this.configFile = configFile;
            xdocAppConfig = new XmlDocument();
            xdocAppConfig.Load(configFile);
            
        }

      
        /// <summary>
        /// Save the value into config file
        /// </summary>
        /// <param name="keyAttribute"> Key</param>
        /// <param name="ValueAttribute"> Value </param>
        public void SaveValue(string keyAttribute, string ValueAttribute)
        {
            this.setXMLAttribute(keyAttribute, ValueAttribute);
            xdocAppConfig.Save(configFile);
        }

        public string GetValue(string keyAttribute)
        {
            return getXMLAttribute(keyAttribute);
        }


        private void setXMLAttribute(string keyAttribute, string valueAttribute)
        {
            foreach (XmlNode xnode in xdocAppConfig.SelectNodes("//appSettings/add"))
            {
                for (int i = 0; i < xnode.Attributes.Count; i++)
                {
                    if (xnode.Attributes[i].Value.Equals(keyAttribute))
                    {
                        xnode.Attributes[i + 1].Value = valueAttribute;
                        break;
                    }
                }
            }
        }

        private string getXMLAttribute(string keyAttribute)
        {
            foreach (XmlNode xnode in xdocAppConfig.SelectNodes("//appSettings/add"))
            {
                for (int i = 0; i < xnode.Attributes.Count; i++)
                {
                    if (xnode.Attributes[i].Value.Equals(keyAttribute))
                    {
                        return xnode.Attributes[i + 1].Value;
                    }
                }
            }
            return null;
        }


    }
}

/**
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


using System.Collections.Generic;
using System.Xml;

namespace Wollundra.App
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

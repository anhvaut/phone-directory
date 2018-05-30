using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneDirectory.BusinessLayer
{
    public class Constants
    {
        private static string GetDomain()
        {
            string domainName = "";
            CommonLibrary.AppConfig appConfig = new CommonLibrary.AppConfig(CommonLibrary.Constants.GetConfigFilePath());                           
            domainName = appConfig.GetValue("DomainName");

            
            return domainName;
        }
    }
}

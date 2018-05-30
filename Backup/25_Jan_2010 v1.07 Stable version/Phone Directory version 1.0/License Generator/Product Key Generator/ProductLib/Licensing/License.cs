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


namespace Wollundra.ProductLib.Licensing
{
    public class License
    {
        private string licensetype;
        private string expiredate;

        public string LicenseType
        {
            get { return licensetype; }
            set { licensetype = value; }
        }

        public string ExpireDate
        {
            get { return expiredate; }
            set { expiredate = value; }
        }
    }
}

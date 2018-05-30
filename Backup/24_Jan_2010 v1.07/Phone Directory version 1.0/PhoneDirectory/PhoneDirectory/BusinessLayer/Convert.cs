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


using System.Windows.Media;


namespace Wollundra.PhoneDirectory.BusinessLayer
{
    public class Convert
    {
        public static Brush HexColor2Brush(string hexColor)
        {
            
            int alpha = int.Parse(hexColor.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
            int red = int.Parse(hexColor.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            int green = int.Parse(hexColor.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
            int blue = int.Parse(hexColor.Substring(7, 2), System.Globalization.NumberStyles.HexNumber);

            return new SolidColorBrush(Color.FromArgb((byte)alpha,(byte)red,(byte)green,(byte)blue));
        }
    }
}

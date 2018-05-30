/**
 * Vu Tran
 * 24/11
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;


namespace Wollundra.ControlPanel
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

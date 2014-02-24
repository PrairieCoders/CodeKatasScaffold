using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
    public class RomanCalculator
    {
        public string Add(string a, string b)
        {
            var num1 = new RomanNumeral(a);
            var num2 = new RomanNumeral(b);

            string result;
            
            if(num1 > num2)
                result = num1.Numeral + num2.Numeral;
            else
                result = num2.Numeral + num1.Numeral;

            if (result.Contains("IIII"))
                result = result.Replace("IIII", "IV");
            if (result.Contains("XXXX"))
                result = result.Replace("XXXX", "XL");
            if (result.Contains("CCCC"))
                result = result.Replace("CCCC", "CD");
            if (result.Contains("VV"))
                result = result.Replace("VV", "X");
            if (result.Contains("LL"))
                result = result.Replace("LL", "C");
            if (result.Contains("DD"))
                result = result.Replace("DD", "M");
            return result;
        }
    }
}

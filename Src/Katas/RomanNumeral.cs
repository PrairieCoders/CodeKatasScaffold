using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
    public class RomanNumeral
    {
        public RomanNumeral(string numeral)
        {
            Numeral = numeral;
        }

        public string Numeral { get; private set; }

        public static bool operator >(RomanNumeral x, RomanNumeral y)
        {
            return GreaterThan(x.Numeral, y.Numeral);
        }

        public static bool operator <(RomanNumeral x, RomanNumeral y)
        {
            throw new NotImplementedException();
        }

        private static bool GreaterThan(string n1, string n2)
        {
            if (n1.Any() && n2.Any())
            {
                if (n1[0] == n2[0])
                {
                    return GreaterThan(n1.Substring(1), n2.Substring(1));
                }
                return Compare(n1[0], n2[0]);
            }
            return n1.Any();
        }

        private static bool Compare(char big, char small)
        {
            switch (big)
            {
                case 'M':
                    return true;
                case 'D':
                    return !small.Equals('M');
                case 'C':
                    return !small.Equals('M') && !small.Equals('D');
                case 'L':
                    return !small.Equals('M') && !small.Equals('D') && !small.Equals('C');
                case 'X':
                    return small.Equals('I') || small.Equals('V') || small.Equals('X');
                case 'V':
                    return !small.Equals('I') || small.Equals('V');
                case 'I':
                    return !small.Equals('I');
                default:
                    return false;
            }
        }
    }
}

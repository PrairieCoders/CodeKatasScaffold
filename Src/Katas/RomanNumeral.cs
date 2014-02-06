using System;

namespace Katas
{
	public class RomanNumeral
	{
		readonly string _numeral;
		readonly int _value;

		public static RomanNumeral I = new RomanNumeral("I", 1);
		public static RomanNumeral V = new RomanNumeral("V", 5);
		public static RomanNumeral X = new RomanNumeral("X", 10);
		public static RomanNumeral L = new RomanNumeral("L", 50);
		public static RomanNumeral C = new RomanNumeral("C", 100);
		public static RomanNumeral D = new RomanNumeral("D", 500);
		public static RomanNumeral M = new RomanNumeral("M", 1000);

		RomanNumeral(string numeral, int value)
		{
			if (numeral.Length != 1)
				throw new ArgumentException("The numeral can only be 1 character long.");

			_numeral = numeral;
			_value = value;
		}

		public string Numeral { get { return _numeral; } }

		public int Value { get { return _value; } }

//		public static explicit operator RomanNumeral(string numeral)
//		{
//			return null;
//		}
	}
}
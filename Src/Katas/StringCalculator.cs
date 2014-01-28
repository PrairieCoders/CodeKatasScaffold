using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas
{
	public class StringCalculator
	{
		public int Add(string inputNumbers)
		{
			if (inputNumbers.Length == 0)
				return 0;

			var parseData = ParseData.CreateFromString(inputNumbers);

			if(parseData.ParsedNumbers.Any(x => x < 0))
				throw new Exception("negatives not allowed");

			return parseData.ParsedNumbers
			              .Sum(s => s);
		}
	}

	public class ParseData
	{
		const string COMMA_DELIMITER = ",";
		const string NEWLINE_DELIMITER = "\n";

		readonly string _numbers;
		readonly string[] _delimiters;

		public ParseData(string numbers, IEnumerable<string> delimiters)
		{
			if (numbers == null) throw new ArgumentNullException("numbers");
			if (delimiters == null) throw new ArgumentNullException("delimiters");

			_numbers = numbers;
			_delimiters = delimiters.ToArray();
		}

		public IEnumerable<int> ParsedNumbers
		{
			get
			{
				return _numbers.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries)
				              .Select(int.Parse);
			}
		}

		public static ParseData CreateFromString(string inputNumbers)
		{
			string finalNumbers;
			var delimiters = new List<string> { COMMA_DELIMITER, NEWLINE_DELIMITER };

			if (inputNumbers.StartsWith("//"))
			{
				var customDelimiter = inputNumbers.Substring(2, 1);
				delimiters.Add(customDelimiter);

				finalNumbers = inputNumbers.Substring(3);
			}
			else
			{
				finalNumbers = inputNumbers;
			}

			return new ParseData(finalNumbers, delimiters);
		}
	}
}
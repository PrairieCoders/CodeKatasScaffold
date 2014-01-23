using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas
{
	public class StringCalculator
	{
		const string COMMA_DELIMITER = ",";
		const string NEWLINE_DELIMITER = "\n";

		public int Add(string numbers)
		{
			if (numbers.Length == 0)
				return 0;

			var delimiters = new List<string> {COMMA_DELIMITER, NEWLINE_DELIMITER};

			if (numbers.StartsWith("//"))
			{
				var customDelimiter = numbers.Substring(2, 1);
				delimiters.Add(customDelimiter);

				numbers = numbers.Substring(3);
			}

			return numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
			              .Sum(s => int.Parse(s));
		}
	}

	public class ParseData
	{
		readonly string _numbers;
		readonly IEnumerable<string> _delimiters;

		public ParseData(string numbers, IEnumerable<string> delimiters)
		{
			if (numbers == null) throw new ArgumentNullException("numbers");
			if (delimiters == null) throw new ArgumentNullException("delimiters");

			_numbers = numbers;
			_delimiters = delimiters;
		}

		public string Numbers { get { return _numbers; } }

		public IEnumerable<string> Delimiters { get { return _delimiters; } }
	}
}
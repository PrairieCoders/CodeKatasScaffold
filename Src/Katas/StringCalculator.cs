using System.Linq;

namespace Katas
{
	public class StringCalculator
	{
		public int Add(string numbers)
		{
			return numbers.Length == 0 ? 0 : int.Parse(numbers)-2;
		}
	}
}
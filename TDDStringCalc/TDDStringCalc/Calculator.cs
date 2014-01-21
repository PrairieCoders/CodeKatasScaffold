using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDDStringCalc
{
    // http://osherove.com/tdd-kata-1/

    public class Calculator
    {
        private readonly IGetCollectionOfIntsFromString _intCollectionGetter;

        public Calculator(IGetCollectionOfIntsFromString intCollectionGetter)
        {
            if (intCollectionGetter == null) throw new ArgumentNullException("intCollectionGetter");
            _intCollectionGetter = intCollectionGetter;
        }

        public int Add(string stringToAdd)
        {
            var intList = _intCollectionGetter.GetInts(stringToAdd);

            return intList.Sum();
        }
    }

    public interface IGetCollectionOfIntsFromString
    {
        IEnumerable<int> GetInts(string intString);
    }

    public class GetIntsFromCommaSeparatedString : IGetCollectionOfIntsFromString
    {
        public IEnumerable<int> GetInts(string intString)
        {
            var stringList = intString.Split(',');

            var intList = new List<int>();

            foreach (var str in stringList)
            {
                int newInt;
                int.TryParse(str, out newInt);
                intList.Add(newInt);
            }

            return intList;
        }
    }

    public class GetIntsFromString : IGetCollectionOfIntsFromString
    {
        public IEnumerable<int> GetInts(string intString)
        {
            const string matchPattern = @"\d+";
            var regex = new Regex(matchPattern);
            var matches = regex.Matches(intString);

            var intList = new List<int>();

            foreach (Match match in matches)
            {
                int newInt;
                int.TryParse(match.Value, out newInt);
                intList.Add(newInt);
            }

            return intList;
        }
    }
}

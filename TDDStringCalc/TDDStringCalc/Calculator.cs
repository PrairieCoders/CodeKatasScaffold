using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
}

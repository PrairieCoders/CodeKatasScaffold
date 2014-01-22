using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
    public class StringCalculator
    {
        private const char DefaultDelimiter = '\n';

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;

            var values = numbers.Split(DefaultDelimiter);

            var newDelimier = CheckForNewDelimiter(values[0]);

            if (newDelimier != DefaultDelimiter)
                values = values[1].Split(newDelimier);

            var sum = 0;
            var negatives = new List<int>();

            foreach (var value in values)
            {
                var num = int.Parse(value);
                if(num < 0)
                    negatives.Add(num);
                else
                    sum += num;
            }

            if (negatives.Any())
                CreateNegativesNotAllowedException(negatives);

            return sum;
        }

        private static char CheckForNewDelimiter(string value)
        {
            if(value.Count() > 2)
                if(value[0] == '/' && value[1] == '/')
                    return value[2];

            return DefaultDelimiter;
        }

        private void CreateNegativesNotAllowedException(IEnumerable<int> negatives)
        {
            var message = "Negatives not allowed: ";
            foreach (var negative in negatives)
            {
                message += negative;
            }

            throw new NegativesNotAllowedException(message);
        }
    }
}

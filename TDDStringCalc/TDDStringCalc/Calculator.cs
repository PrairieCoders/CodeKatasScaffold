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
        public int Add(string stringToAdd)
        {
            int result;

            // Handle empty string
            if (String.IsNullOrEmpty(stringToAdd))
                return 0;
            
            // Handle single int in string
            if(int.TryParse(stringToAdd, out result))
                return result;

            // Handle 2 ints
            var inArray = stringToAdd.Split(',');

            result += int.Parse(inArray[0]);
            result += int.Parse(inArray[1]);

            return result;
        }
    }
}

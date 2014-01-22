using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException()
        {
        }

        public NegativesNotAllowedException(string message)
            :base(message)
        {
        }

        public NegativesNotAllowedException(string message, Exception inner)
            :base(message, inner)
        {
        }
    }
}

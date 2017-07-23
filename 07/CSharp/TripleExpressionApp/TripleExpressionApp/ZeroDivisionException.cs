using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class ZeroDivisionException : Exception
    {
        public ZeroDivisionException()
        {
            throw new Exception("division by zero");
        }
    }
}

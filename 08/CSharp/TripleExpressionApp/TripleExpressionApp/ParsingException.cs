using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class ParsingException : Exception
    {
        public ParsingException()
        {
            throw new Exception("ParsingException");
        }
        public ParsingException(string message)
        {
            throw new Exception(message);
        }
    }
}

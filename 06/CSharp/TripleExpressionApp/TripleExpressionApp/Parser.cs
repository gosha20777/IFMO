using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public interface Parser
    {
        ITripleExpression Parse(String expression);
    }
}

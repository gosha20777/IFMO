using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Add : BinaryOperator
    {
        public Add(ITripleExpression first, ITripleExpression second)
        {
            fOp = first;
            sOp = second;
        }
        
        protected override double Apply(double a, double b)
        {
            return a + b;
        }
    }
}

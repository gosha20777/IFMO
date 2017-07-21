using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Divide : BinaryOperator
    {
        public Divide(ITripleExpression first, ITripleExpression second)
        {
            fOp = first;
            sOp = second;
        }

        override protected double Apply(double a, double b)
        {
            return a / b;
        }
    }
}

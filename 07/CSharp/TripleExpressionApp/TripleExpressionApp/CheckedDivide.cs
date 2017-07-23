using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class CheckedDivide : BinaryOperator
    {
        public CheckedDivide(ITripleExpression first, ITripleExpression second)
        {
            fOp = first;
            sOp = second;
        }

        protected void Check(double a, double b)
        {
            if (a == double.MinValue && b == -1)
            {
                throw new OverflowException();
            }
            if (b == 0)
            {
                throw new ZeroDivisionException();
            }
        }

        override protected double Apply(double a, double b)
        {
            Check(a, b);
            return a / b;
        }
    }
}

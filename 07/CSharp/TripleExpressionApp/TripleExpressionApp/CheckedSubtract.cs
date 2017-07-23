using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class CheckedSubtract : BinaryOperator
    {
        public CheckedSubtract(ITripleExpression first, ITripleExpression second)
        {
            fOp = first;
            sOp = second;
        }

        protected void Check(double a, double b)
        {
            if (b > 0 && a < double.MinValue + b)
            {
                throw new OverflowException();
            }
            if (b < 0 && a > double.MaxValue + b)
            {
                throw new OverflowException();
            }
        }

        override protected double Apply(double a, double b)
        {
            Check(a, b);
            return a - b;
        }
    }
}

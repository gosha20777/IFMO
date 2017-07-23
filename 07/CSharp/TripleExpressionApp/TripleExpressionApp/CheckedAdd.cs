using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class CheckedAdd : BinaryOperator
    {
        public CheckedAdd(ITripleExpression first, ITripleExpression second)
        {
            fOp = first;
            sOp = second;
        }
        
        protected void Check(double a, double b)
        {
            if (a > 0 && b > double.MaxValue - a)
            {
                throw new OverflowException();
            }
            if (a < 0 && b < double.MinValue - a)
            {
                throw new OverflowException();
            }
        }

        protected override double Apply(double a, double b)
        {
            Check(a, b);
            return a + b;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class CheckedMultiply : BinaryOperator
    {
        public CheckedMultiply(ITripleExpression first, ITripleExpression second)
        {
            fOp = first;
            sOp = second;
        }

        protected void Check(double a, double b)
        {
            if (a > b)
            {
                Check(b, a);
            }
            else
            {
                if (a < 0)
                {
                    if (b < 0)
                    {
                        if (a < double.MaxValue / b)
                        {
                            throw new OverflowException();
                        }
                    }
                    else if (b > 0)
                    {
                        if (double.MinValue / b > a)
                        {
                            throw new OverflowException();
                        }
                    }
                }
                else if (a > 0)
                {
                    if (a > double.MaxValue / b)
                    {
                        throw new OverflowException();
                    }
                }
            }
        }

        override protected double Apply(double a, double b)
        {
            Check(a, b);
            return a * b;
        }
    }
}

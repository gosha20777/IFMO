using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    class CheckedSqrt : ITripleExpression
    {
        private ITripleExpression value;

        public CheckedSqrt(ITripleExpression value)
        {
            this.value = value;
        }

        protected void Check(double a)
        {
            if (a < 0)
            {
                throw new ParsingException("sqrt from negative number");
            }
        }

        public double Evaluate(double x, double y, double z)
        {
            double a = value.Evaluate(x, y, z);
            Check(a);
            double l = -1;
            double r = 46341;
            while (r - l > 1)
            {
                double m = (l + r) / 2;
                if (m * m <= a)
                {
                    l = m;
                }
                else
                {
                    r = m;
                }
            }
            return l;
        }
    }
}

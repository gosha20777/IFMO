using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class CheckedAbs : ITripleExpression
    {
        private ITripleExpression value;
        public CheckedAbs(ITripleExpression value)
        {
            this.value = value;
        }

        protected void Check(double a)
        {
            if (a == double.MinValue)
            {
                throw new OverflowException();
            }
        }

        public double Evaluate(double x, double y, double z)
        {
            double val = value.Evaluate(x, y, z);
            Check(val);
            if (val < 0)
            {
                val = -val;
            }
            return val;
        }
    }
}

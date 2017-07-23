using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    class CheckedNegate : ITripleExpression
    {
        private ITripleExpression value;

        public CheckedNegate(ITripleExpression value)
        {
            this.value = value;
        }

        protected void Check(double a)
        {
            if(a <= double.MinValue)
            {
                throw new OverflowException();
            }
        }

        public double Evaluate(double x, double y, double z)
        {
            double a = value.Evaluate(x, y, z);
            Check(a);
            return -a;
        }
    }
}

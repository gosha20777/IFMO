using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    abstract public class BinaryOperator : ITripleExpression
    {
        protected ITripleExpression fOp;
        protected ITripleExpression sOp;

        abstract protected double Apply(double a, double b);
        public double Evaluate(double x, double y, double z)
        {
            return Apply(fOp.Evaluate(x, y, z), sOp.Evaluate(x, y, z));
        }
    }
}

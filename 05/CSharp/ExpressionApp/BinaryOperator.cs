using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionApp
{
    abstract class BinaryOperator : IExpression
    {
        protected IExpression fOp;
        protected IExpression sOp;

        abstract public double Evaluate(double param);
    }
}

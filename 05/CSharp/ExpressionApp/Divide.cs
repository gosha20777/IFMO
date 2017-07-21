using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionApp
{
    class Divide : BinaryOperator
    {
        public Divide(IExpression first, IExpression second)
        {
            fOp = first;
            sOp = second;
        }

        public override double Evaluate(double param)
        {
            return fOp.Evaluate(param) / sOp.Evaluate(param);
        }
    }
}

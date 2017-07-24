using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Divide<T> : BinaryOperator<T>
    {
        public Divide(ITripleExpression<T> first, ITripleExpression<T> second, IOperator<T> op)
        {
            fOp = first;
            sOp = second;
            base.op = op;
        }

        override protected T Apply(T a, T b)
        {
            return op.Divide(a, b);
        }
    }
}

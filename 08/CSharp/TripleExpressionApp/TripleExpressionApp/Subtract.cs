using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Subtract<T> : BinaryOperator<T>
    {
        public Subtract(ITripleExpression<T> first, ITripleExpression<T> second, IOperator<T> op)
        {
            fOp = first;
            sOp = second;
            base.op = op;
        }

        override protected T Apply(T a, T b)
        {
            return op.Subtract(a, b);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Mod<T> : BinaryOperator<T>
    {
        public Mod(ITripleExpression<T> first, ITripleExpression<T> second, IOperator<T> op)
        {
            fOp = first;
            sOp = second;
            base.op = op;
        }

        protected override T Apply(T a, T b)
        {
            return op.Mod(a, b);
        }
    }
}

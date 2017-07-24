using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Add<T> : BinaryOperator<T>
    {
        public Add(ITripleExpression<T> first, ITripleExpression<T> second, IOperator<T> op)
        {
            fOp = first;
            sOp = second;
            base.op = op;
        }
        
        protected override T Apply(T a, T b)
        {
            return op.Add(a, b);
        }
    }
}

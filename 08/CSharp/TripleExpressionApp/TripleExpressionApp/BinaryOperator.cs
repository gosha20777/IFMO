using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    abstract public class BinaryOperator<T> : ITripleExpression <T>
    {
        protected ITripleExpression<T> fOp;
        protected ITripleExpression<T> sOp;
        protected IOperator<T> op;

        public BinaryOperator(ITripleExpression<T> first, ITripleExpression<T> second, IOperator<T> op)
        {
            fOp = first;
            sOp = second;
            this.op = op;
        }
        public BinaryOperator() { }

        abstract protected T Apply(T a, T b);
        public T Evaluate(T x, T y, T z)
        {
            return Apply(fOp.Evaluate(x, y, z), sOp.Evaluate(x, y, z));
        }
    }
}

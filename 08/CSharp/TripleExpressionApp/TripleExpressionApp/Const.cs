using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Const<T> : ITripleExpression<T>
    {
        private T value;
        public Const(T value)
        {
            this.value = value;
        }

        public T Evaluate(T x, T y, T z)
        {
            return value;
        }
    }
}

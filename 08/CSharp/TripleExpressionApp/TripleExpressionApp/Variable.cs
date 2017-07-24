using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Variable<T> : ITripleExpression<T>
    {
        private String name;
        public Variable(String name)
        {
            this.name = name;
        }

        public T Evaluate(T x, T y, T z)
        {
            if (name.Equals("x"))
            {
                return x;
            }
            else if (name.Equals("y"))
            {
                return y;
            }
            else
            {
                return z;
            }
        }
    }
}

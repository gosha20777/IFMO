﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Negate<T> : ITripleExpression<T>
    {
        private ITripleExpression<T> value;
        private IOperator<T> op;
        public Negate(ITripleExpression<T> value, IOperator<T> op)
        {
            this.value = value;
            this.op = op;
        }

        public T Evaluate(T x, T y, T z)
        {
            T a = value.Evaluate(x, y, z);
            return op.Negate(a);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public interface ITripleExpression<T>
    {
        T Evaluate(T x, T y, T z);
    }
}

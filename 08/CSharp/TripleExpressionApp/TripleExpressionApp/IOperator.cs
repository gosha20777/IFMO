using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public interface IOperator<T>
    {
        T Parse(String a);
        T Add(T a, T b);
        T Subtract(T a, T b);
        T Multiply(T a, T b);
        T Divide(T a, T b);
        T Mod(T a, T b);
        T Negate(T a);
        T Abs(T a);
        T Square(T a);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TripleExpressionApp
{
    public class OpBigInteger : IOperator<BigInteger>
    {
        public BigInteger Parse(String a)
        {
            return new BigInteger();
        }

        public BigInteger Add(BigInteger a, BigInteger b)
        {
            return BigInteger.Add(a, b);
        }
        public BigInteger Subtract(BigInteger a, BigInteger b)
        {
            return BigInteger.Subtract(a, b);
        }
        public BigInteger Multiply(BigInteger a, BigInteger b)
        {
            return BigInteger.Multiply(a, b);
        }
        public BigInteger Divide(BigInteger a, BigInteger b)
        {
            return BigInteger.Divide(a, b);
        }
        public BigInteger Negate(BigInteger a)
        {
            return BigInteger.Negate(a);
        }
        public BigInteger Mod(BigInteger a, BigInteger b)
        {
            return BigInteger.Remainder(a, b);
        }
        public BigInteger Square(BigInteger a)
        {
            return BigInteger.Pow(a, 2);
        }
        public BigInteger Abs(BigInteger a)
        {
            return BigInteger.Abs(a);
        }
    }
}

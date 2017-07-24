using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class OpDouble : IOperator<double>
    {
        public double Parse(String a)
        {
            return Convert.ToDouble(a);
        }

        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Subtract(double a, double b)
        {
            return a - b;
        }
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        public double Divide(double a, double b)
        {
            return a / b;
        }
        public double Negate(double a)
        {
            return -a;
        }
        public double Mod(double a, double b)
        {
            return a % b;
        }
        public double Square(double a)
        {
            return Math.Pow(a, 2);
        }
        public double Abs(double a)
        {
            return Math.Abs(a);
        }
    }
}

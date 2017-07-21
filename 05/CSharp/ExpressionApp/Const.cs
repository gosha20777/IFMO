using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionApp
{
    class Const : IExpression
    {
        private double value;
        public Const(double value)
        {
            this.value = value;
        }
        public double Evaluate(double param)
        {
            return value;
        }
    }
}

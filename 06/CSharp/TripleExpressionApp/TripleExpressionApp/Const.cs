using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Const : ITripleExpression
    {
        private double value;
        public Const(double value)
        {
            this.value = value;
        }

        public double Evaluate(double x, double y, double z)
        {
            return value;
        }
    }
}

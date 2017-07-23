using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Square : ITripleExpression
    {
        private ITripleExpression value;
        public Square(ITripleExpression value)
        {
            this.value = value;
        }

        public double Evaluate(double x, double y, double z)
        {
            double a = value.Evaluate(x, y, z);
            return a * a;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Abs : ITripleExpression
    {
        private ITripleExpression value;
        public Abs(ITripleExpression value)
        {
            this.value = value;
        }

        public double Evaluate(double x, double y, double z)
        {
            return Math.Abs(value.Evaluate(x, y, z));
        }
    }
}

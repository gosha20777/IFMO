using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class Variable : ITripleExpression
    {
        private String name;
        public Variable(String name)
        {
            this.name = name;
        }

        public double Evaluate(double x, double y, double z)
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

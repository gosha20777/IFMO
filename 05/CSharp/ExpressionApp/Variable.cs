using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionApp
{
    class Variable : IExpression
    {
        private string name;
        public Variable(string name)
        {
            this.name = name;
        }
        public double Evaluate(double param)
        {
            return param;
        }
    }
}

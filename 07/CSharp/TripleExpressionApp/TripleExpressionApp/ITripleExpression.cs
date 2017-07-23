using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public interface ITripleExpression
    {
        double Evaluate(double x, double y, double z);
    }
}

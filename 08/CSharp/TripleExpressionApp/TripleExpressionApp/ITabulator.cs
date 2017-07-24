using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public interface ITabulator
    {
        Object[,,] Tabulate(String mode, String expression, int x1, int x2, int y1, int y2, int z1, int z2);
    }
}

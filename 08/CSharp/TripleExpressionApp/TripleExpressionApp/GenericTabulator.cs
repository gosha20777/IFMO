using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TripleExpressionApp
{
    public class GenericTabulator : ITabulator
    {
        public object[,,] Tabulate(string mode, string expression, int x1, int x2, int y1, int y2, int z1, int z2)
        {
            OpInteger opi = new OpInteger();
            OpDouble opd = new OpDouble();
            OpBigInteger opbi = new OpBigInteger();
            ExpressionParser<int> parseri = new ExpressionParser<int>(opi);
            ExpressionParser<Double> parserd = new ExpressionParser<Double>(opd);
            ExpressionParser<BigInteger> parserbi = new ExpressionParser<BigInteger>(opbi);

            Object[,,] ret = new Object[x2 - x1 + 1, y2 - y1 + 1, z2 - z1 + 1];

            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    for (int k = z1; k <= z2; k++)
                    {
                        try
                        {
                            if (mode.Equals("i"))
                            {
                                ret[i - x1, j - y1, k - z1] = parseri.Parse(expression).Evaluate(opi.Parse(Convert.ToString(i)), opi.Parse(Convert.ToString(j)), opi.Parse(Convert.ToString(k)));
                            }
                            else if (mode.Equals("d"))
                            {
                                ret[i - x1, j - y1, k - z1] = parserd.Parse(expression).Evaluate(opd.Parse(Convert.ToString(i)), opd.Parse(Convert.ToString(j)), opd.Parse(Convert.ToString(k)));
                            }
                            else
                            {
                                ret[i - x1, j - y1, k - z1] = parserbi.Parse(expression).Evaluate(opbi.Parse(Convert.ToString(i)), opbi.Parse(Convert.ToString(j)), opbi.Parse(Convert.ToString(k)));
                            }
                        }
                        catch (Exception e)
                        {
                            ret[i - x1, j - y1, k - z1] = null;
                        }
                    }
                }
            }

            return ret;
        }
    }
}

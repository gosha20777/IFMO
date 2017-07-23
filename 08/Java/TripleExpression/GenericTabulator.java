package TripleExpression;

import java.math.BigInteger;

public class GenericTabulator implements Tabulator {
    public Object[][][] tabulate(String mode, String expression, int x1, int x2, int y1, int y2, int z1, int z2) throws Exception {
        OpInteger opi = new OpInteger();    
        OpDouble opd = new OpDouble();
        OpBigInteger opbi = new OpBigInteger();
        ExpressionParser<Integer> parseri = new ExpressionParser<>(opi);
        ExpressionParser<Double> parserd = new ExpressionParser<>(opd);
        ExpressionParser<BigInteger> parserbi= new ExpressionParser<>(opbi);

        Object[][][] ret = new Object[x2 - x1 + 1][y2 - y1 + 1][z2 - z1 + 1];

        for(int i = x1; i <= x2; i++) {
            for (int j = y1; j <= y2; j++) {
                for (int k = z1; k <= z2; k++) {
                    try {
                        if(mode.equals("i")) {
                            ret[i-x1][j-y1][k-z1] = parseri.parse(expression).evaluate(opi.parse(Integer.toString(i)), opi.parse(Integer.toString(j)), opi.parse(Integer.toString(k)));
                        } else if (mode.equals("d")) {
                            ret[i-x1][j-y1][k-z1] = parserd.parse(expression).evaluate(opd.parse(Integer.toString(i)), opd.parse(Integer.toString(j)), opd.parse(Integer.toString(k)));
                        } else {
                            ret[i-x1][j-y1][k-z1] = parserbi.parse(expression).evaluate(opbi.parse(Integer.toString(i)), opbi.parse(Integer.toString(j)), opbi.parse(Integer.toString(k)));
                        }
                    } catch (Exception e) {
                        ret[i-x1][j-y1][k-z1] = null;
                    }
                }
            }
        }

        return ret; 
    }
}
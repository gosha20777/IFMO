package TripleExpression;

public class OpInteger implements Operator<Integer> {

    private void checkAdd(Integer a, Integer b) throws Exception {
        if (a > 0 && b > Integer.MAX_VALUE - a) {
            throw new OverflowException();    
        }
        if (a < 0 &&  b < Integer.MIN_VALUE - a) {
            throw new OverflowException();
        }
    }

    private void checkSubtract(Integer a, Integer b) throws Exception {
        if(b > 0 && a < Integer.MIN_VALUE + b) {
            throw new OverflowException();
        }
        if(b < 0 && a > Integer.MAX_VALUE + b) {
            throw new OverflowException();
        } 
    }

    private void checkDivide(Integer a, Integer b) throws Exception {
        if(a == Integer.MIN_VALUE && b == -1) {
            throw new OverflowException();
        }
        if (b == 0) {
            throw new ZeroDivisionException();
        }
    }

    /*private void checkMod(Integer a, Integer b) throws Exception {
        if(a == Integer.MIN_VALUE && b == Integer.MIN_VALUE) {
            throw new OverflowException();
        }
        if (b == 0) {
            throw new ZeroDivisionException();
        }
    }*/

    private void checkNegate(Integer a) throws Exception {
        if (a <= Integer.MIN_VALUE) {
            throw new OverflowException();
        }
    }

    private void checkMultiply(Integer a, Integer b) throws Exception {
        if (a > b) {
            checkMultiply(b, a);
        } else {
            if (a < 0) {
                if (b < 0) {
                    if (a < Integer.MAX_VALUE / b) {
                        throw new OverflowException();
                    }
                } else if (b > 0) {
                    if (Integer.MIN_VALUE / b > a) {
                              throw new OverflowException();
                    }
                }          
            } else if (a > 0) {
                if (a > Integer.MAX_VALUE / b) {
                    throw new OverflowException();
                }
            }
        }
    }

    public Integer parse(String a) throws Exception {
        return Integer.parseInt(a);
    }

    public Integer add(Integer a, Integer b) throws Exception {
        checkAdd(a, b);
        return a + b;
    }
    public Integer subtract(Integer a, Integer b) throws Exception {
        checkSubtract(a, b);
        return a - b;
    }
    public Integer multiply(Integer a, Integer b) throws Exception {
        checkMultiply(a, b);
        return a * b;
    }
    public Integer divide(Integer a, Integer b) throws Exception {
        checkDivide(a,b);
        return a / b;
    }
    public Integer mod(Integer a, Integer b) throws Exception {
        return a % b;
    }
    public Integer negate(Integer a) throws Exception {
        checkNegate(a);
        return -a;
    }
    public Integer abs(Integer a) throws Exception {
        if (a < 0) {
            return subtract(0, a);
        } else {
            return a;
        }
    }
    public Integer square(Integer a) throws Exception {
        return multiply(a, a);
    }
}
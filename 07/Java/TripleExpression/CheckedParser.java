package TripleExpression;

public class CheckedParser implements Parser {
    private int index;
    private String expression;
    private int constant;
    private char variable;
    private enum State {number, plus, minus, asterisk, mod, slash, lparen, rparen, variable, abs, sqrt}
    private State current;

    private char getNextChar() {
        if (index < expression.length()) {
            char ret =  expression.charAt(index);
            index++;
            return ret;
        } else {
            return '#';
        }
    }

    private void skipWhitespace() {
        while (Character.isWhitespace(getNextChar())) {

        } 
        index--;
    }

    private void getNext() throws Exception {
        skipWhitespace();
        char ch = getNextChar();
        if (Character.isDigit(ch)) {
            StringBuilder str = new StringBuilder();
            while (Character.isDigit(ch)) {
                str.append(ch);
                ch = getNextChar();
            }
            index--;
            try {
                constant = Integer.parseInt(str.toString());
            } catch (NumberFormatException e) {
                throw new OverflowException();
            }
            current = State.number;
        } else if (ch == '+') {
            current = State.plus;
        } else if (ch == '-') {
            if (expression.length() >= index + 10 && expression.substring(index, index + 10).equals("2147483648")) {
                constant = Integer.parseInt(expression.substring(index - 1, index + 10));
                index += 10;
                current = State.number;
            } else {
                current = State.minus;
            }
        } else if (ch == '*') {
            current = State.asterisk;
        } else if (ch == '/') {
            current = State.slash;
        } else if (ch == '(') {
            current = State.lparen;
        } else if (ch == ')') {
            current = State.rparen;
        } else if (ch == 'x' || ch == 'y' || ch == 'z') {
            current = State.variable;
            variable = ch;
        } else {
            if (expression.length() >= index + 2 && expression.substring(index - 1, index + 2).equals("abs")) {
                index += 2;
                current = State.abs;
            } else if (expression.length() >= index + 3 && expression.substring(index - 1, index + 3).equals("sqrt")) {
                index += 3;
                current = State.sqrt;
            } else if (!Character.isWhitespace(ch)) {
                throw new ParsingException("unexpected char: \"" + ch + "\" at index: " + (index - 1));
            }
        }
        skipWhitespace();
    }

    private TripleExpression atomic() throws Exception {
        getNext();
        TripleExpression ret;
        switch (current) {
            case number:
                ret = new Const(constant);
                getNext();
            break;

            case variable:
                ret = new Variable(Character.toString(variable));
                getNext();
            break;

            case minus:
                ret = new CheckedNegate(atomic());
            break;

            case abs:
                ret = new CheckedAbs(atomic());
            break;

            case sqrt:
                ret = new CheckedSqrt(atomic());
            break;

            case lparen:
                ret = addSubt();
                getNext();
            break;

            default:
                ret = null;
                throw new ParsingException("unrecognizable symbol at position: " + index);
        }
        return ret;
    }

    private TripleExpression mulDiv() throws Exception {
        TripleExpression left = atomic();
        while(true) {
            switch(current) {
                case asterisk:
                    left = new CheckedMultiply(left, atomic());
                break;

                case slash:
                    left = new CheckedDivide(left, atomic());
                break;

/*                case mod:
                    left = new Mod(left, atomic());
                break;*/

                default:
                    return left;
            }
        }
    }

    private TripleExpression addSubt() throws Exception {
        TripleExpression left = mulDiv();
        while (true) {
            switch(current) {
                case minus:
                    left = new CheckedSubtract(left, mulDiv());
                break;

                case plus:
                    left = new CheckedAdd(left, mulDiv());
                break;

                default:
                    return left;
            }
        }
    }

/*    private TripleExpression shifts() {
        TripleExpression left = addSubt();
        while (true) {
            switch(current) {
                case shiftLeft:
                    left = new ShiftLeft(left, addSubt());
                break;

                case shiftRight:
                    left = new ShiftRight(left, addSubt());
                break;

                default:
                    return left;
            }
        }
    }*/

    public TripleExpression parse(String expr) throws Exception {
        expression = expr;
        int bb = 0;
        for (int i = 0; i < expression.length() ; i++) {
            if (expression.charAt(i) == '(') {
                bb++;
            } else if(expression.charAt(i) == ')') {
                bb--;
            }
            if (bb < 0) {
                throw new ParsingException("unexpected ) at position: " + i);
            }
        }
        if (bb != 0) {
            throw new ParsingException("expected ) at end");
        }
        index = 0;
        return addSubt();
    }
}
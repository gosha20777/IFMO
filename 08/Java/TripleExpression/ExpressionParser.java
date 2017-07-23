package TripleExpression;

public class ExpressionParser<T> implements Parser<T> {
    private int index;
    private String expression;
    private T constant;
    private char variable;
    private Operator<T> op;
    private enum State {number, plus, minus, asterisk, mod, slash, lparen, rparen, variable, abs, square}
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
                constant = op.parse(str.toString());
            } catch (NumberFormatException e) {
                throw new OverflowException();
            }
            current = State.number;
        } else if (ch == '+') {
            current = State.plus;
        } else if (ch == '-') {
            if (expression.length() >= index + 10 && expression.substring(index, index + 10).equals("2147483648")) {
                constant = op.parse(expression.substring(index - 1, index + 10));
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
        }  else {
            if (expression.length() >= index + 2 && expression.substring(index - 1, index + 2).equals("abs")) {
                index += 2;
                current = State.abs;
            } else if (expression.length() >= index + 5 && expression.substring(index - 1, index + 5).equals("square")) {
                index += 5;
                current = State.square;
            } else if (expression.length() >= index + 2 && expression.substring(index - 1, index + 2).equals("mod")) {
                index += 2;
                current = State.mod;
            } else if (!Character.isWhitespace(ch)) {
                throw new ParsingException("unexpected char: \"" + ch + "\" at index: " + (index - 1));
            }
        }
        skipWhitespace();
    }

    private TripleExpression<T> atomic() throws Exception {
        getNext();
        TripleExpression<T> ret;
        switch (current) {
            case number:
                ret = new Const<T>(constant);
                getNext();
            break;

            case variable:
                ret = new Variable<T>(Character.toString(variable));
                getNext();
            break;

            case minus:
                ret = new Negate<T>(atomic(), op);
            break;

            case abs:
                ret = new Abs<T>(atomic(), op);
            break;

            case square:
                ret = new Square<T>(atomic(), op);
            break;
            
            case lparen:
                ret = addSubt();
                getNext();
            break;

            default:
                ret = null;
                throw new ParsingException("unrecognizable format");
        }
        return ret;
    }

    private TripleExpression<T> mulDiv() throws Exception {
        TripleExpression<T> left = atomic();
        while(true) {
            switch(current) {
                case asterisk:
                    left = new Multiply<T>(left, atomic(), op);
                break;

                case slash:
                    left = new Divide<T>(left, atomic(), op);
                break;

                case mod:
                    left = new Mod<T>(left, atomic(), op);
                break;

                default:
                    return left;
            }
        }
    }

    private TripleExpression<T> addSubt() throws Exception {
        TripleExpression<T> left = mulDiv();
        while (true) {
            switch(current) {
                case minus:
                    left = new Subtract<T>(left, mulDiv(), op);
                break;

                case plus:
                    left = new Add<T>(left, mulDiv(), op);
                break;

                default:
                    return left;
            }
        }
    }

    public ExpressionParser(Operator<T> op) {
        this.op = op;
    }

    public TripleExpression<T> parse(String expr) throws Exception {
        expression = expr;
        int bb = 0;
        for (int i = 0; i < expression.length() ; i++) {
            if (expression.charAt(i) == '(') {
                bb++;
            } else if(expression.charAt(i) == ')') {
                bb--;
            }
            if (bb < 0) {
                throw new ParsingException("brackets placed incorrectly");
            }
        }
        if (bb != 0) {
            throw new ParsingException("brackets placed incorrectly");
        }
        index = 0;
        return addSubt();
    }
}
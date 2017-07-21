package TripleExpression;

public class ExpressionParser implements Parser {
    private int index;
    private String expression;
    private int constant;
    private char variable;
    private enum State {number, plus, minus, asterisk, mod, slash, shiftLeft, shiftRight, square, abs, lparen, rparen, variable}
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

    private void getNext() {
        skipWhitespace();
        char ch = getNextChar();
        if (Character.isDigit(ch)) {
            StringBuilder str = new StringBuilder();
            while (Character.isDigit(ch)) {
                str.append(ch);
                ch = getNextChar();
            }
            index--;
            constant = Integer.parseUnsignedInt(str.toString());
            current = State.number;
        } else if (ch == '+') {
            current = State.plus;
        } else if (ch == '-') {
            current = State.minus;
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
        } else if(index < expression.length()) {
            if (expression.substring(index - 1, index + 2).equals("mod")) {
                current = State.mod;
                index += 2;
            } else if (expression.substring(index - 1, index + 1).equals("<<")) {
                current = State.shiftLeft;
                index += 1;
            } else if (expression.substring(index - 1, index + 1).equals(">>")) {
                current = State.shiftRight;
                index += 1;
            } else if (expression.substring(index - 1, index + 2).equals("abs")) {
                current = State.abs;
                index += 2;
            } else if (expression.substring(index - 1, index + 5).equals("square")) {
                current = State.square;
                index += 5;
            }
        }
        skipWhitespace();

    }

    private TripleExpression atomic() {
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
                ret = new Subtract(new Const(0), atomic());
            break;

            case abs:
                ret = new Abs(atomic());
            break;

            case square:
                ret = new Square(atomic());
            break;

            case lparen:
                ret = shifts();
                if (current != State.rparen) {
                    System.out.println(") missing");
                    System.exit(0);
                }
                getNext();
            break;

            default:
                ret = null;
                System.out.println("Unrecognizable format");
                System.exit(0);
            break;
        }
        return ret;
    }

    private TripleExpression mulDiv() {
        TripleExpression left = atomic();
        while(true) {
            switch(current) {
                case asterisk:
                    left = new Multiply(left, atomic());
                break;

                case slash:
                    left = new Divide(left, atomic());
                break;

                case mod:
                    left = new Mod(left, atomic());
                break;

                default:
                    return left;
            }
        }
    }

    private TripleExpression addSubt() {
        TripleExpression left = mulDiv();
        while (true) {
            switch(current) {
                case minus:
                    left = new Subtract(left, mulDiv());
                break;

                case plus:
                    left = new Add(left, mulDiv());
                break;

                default:
                    return left;
            }
        }
    }

    private TripleExpression shifts() {
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
    }

    public TripleExpression parse(String expression) {
        this.expression = expression;
        return shifts();
    }
}
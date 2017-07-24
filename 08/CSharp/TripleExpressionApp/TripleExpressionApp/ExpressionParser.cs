using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class ExpressionParser<T> : IParser<T>
    {
        private int index;
        private String expression;
        private T constant;
        private char variable;
        private IOperator<T> op;
        private enum State { number, plus, minus, asterisk, mod, slash, lparen, rparen, variable, abs, square }
        private State current;

        private char GetNextChar()
        {
            if (index < expression.Length)
            {
                char ret = expression[index];
                index++;
                return ret;
            }
            else
            {
                return '#';
            }
        }
        private void SkipWhitespace()
        {
            while (Char.IsWhiteSpace(GetNextChar()))
            {

            }
            index--;
        }
        private void GetNext()
        {
            SkipWhitespace();
            char ch = GetNextChar();
            if (Char.IsDigit(ch))
            {
                StringBuilder str = new StringBuilder();
                while (Char.IsDigit(ch))
                {
                    str.Append(ch);
                    ch = GetNextChar();
                }
                index--;
                try
                {
                    constant = op.Parse(str.ToString());
                }
                catch
                {
                    throw new OverflowException();
                }
                current = State.number;
            }
            else if (ch == '+')
            {
                current = State.plus;
            }
            else if (ch == '-')
            {
                if (expression.Length >= index + 10 && expression.Substring(index, index + 10).Equals("2147483648"))
                {
                    constant = op.Parse(expression.Substring(index - 1, index + 10));
                    index += 10;
                    current = State.number;
                }
                else
                {
                    current = State.minus;
                }
            }
            else if (ch == '*')
            {
                current = State.asterisk;
            }
            else if (ch == '/')
            {
                current = State.slash;
            }
            else if (ch == '(')
            {
                current = State.lparen;
            }
            else if (ch == ')')
            {
                current = State.rparen;
            }
            else if (ch == 'x' || ch == 'y' || ch == 'z')
            {
                current = State.variable;
                variable = ch;
            }
            else
            {
                if (expression.Length >= index + 2 && expression.Substring(index - 1, index + 2).Equals("abs"))
                {
                    index += 2;
                    current = State.abs;
                }
                else if (expression.Length >= index + 5 && expression.Substring(index - 1, index + 5).Equals("square"))
                {
                    index += 5;
                    current = State.square;
                }
                else if (expression.Length >= index + 2 && expression.Substring(index - 1, index + 2).Equals("mod"))
                {
                    index += 2;
                    current = State.mod;
                }
                else if (!Char.IsWhiteSpace(ch))
                {
                    throw new ParsingException("unexpected char: \"" + ch + "\" at index: " + (index - 1));
                }
            }
            SkipWhitespace();
        }

        private ITripleExpression<T> Atomic()
        {
            GetNext();
            ITripleExpression<T> ret;
            switch (current)
            {
                case State.number:
                    ret = new Const<T>(constant);
                    GetNext();
                    break;
                case State.variable:
                    ret = new Variable<T>(Char.ToString(variable));
                    GetNext();
                    break;
                case State.minus:
                    ret = new Negate<T>(Atomic(), op);
                    break;
                case State.abs:
                    ret = new Abs<T>(Atomic(), op);
                    break;
                case State.square:
                    ret = new Square<T>(Atomic(), op);
                    break;           
                case State.lparen:
                    ret = AddSubt();
                    GetNext();
                    break;
                default:
                    ret = null;
                    throw new ParsingException("unrecognizable format");
            }
            return ret;
        }
        private ITripleExpression<T> MulDiv()
        {
            ITripleExpression<T> left = Atomic();
            while(true)
            {
                switch (current)
                {
                    case State.asterisk:
                        left = new Multiply<T>(left, Atomic(), op);
                        break;
                    case State.slash:
                        left = new Divide<T>(left, Atomic(), op);
                        break;
                    case State.mod:
                        left = new Mod<T>(left, Atomic(), op);
                        break;
                    default:
                        return left;
        }
    }
}
        private ITripleExpression<T> AddSubt()
        {
            ITripleExpression<T> left = MulDiv();
            while (true)
            {
                switch (current)
                {
                    case State.minus:
                        left = new Subtract<T>(left, MulDiv(), op);
                        break;
                    case State.plus:
                        left = new Add<T>(left, MulDiv(), op);
                        break;
                    default:
                        return left;
                }
            }
        }
        public ExpressionParser(IOperator<T> op)
        {
            this.op = op;
        }
        public ITripleExpression<T> Parse(String expr)
        {
            expression = expr;
            int bb = 0;
            for (int i = 0; i < expression.Length ; i++)
            {
                if (expression[i] == '(')
                {
                    bb++;
                }
                else if (expression[i] == ')')
                {
                    bb--;
                }
                if (bb < 0)
                {
                    throw new ParsingException("brackets placed incorrectly");
                }
            }
            if (bb != 0)
            {
                throw new ParsingException("brackets placed incorrectly");
            }
            index = 0;
            return AddSubt();
        }
    }
}

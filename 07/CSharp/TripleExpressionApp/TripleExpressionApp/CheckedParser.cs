using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class CheckedParser : IParser
    {
        private int index;
        private string expression;
        private uint constant;
        private char variable;
        private enum State { number, plus, minus, asterisk, mod, slash, lparen, rparen, variable, abs, sqrt }
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
                    constant = Convert.ToUInt32(str.ToString());
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
                    constant = Convert.ToUInt32(expression.Substring(index - 1, index + 10));
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
                else if (expression.Length >= index + 3 && expression.Substring(index - 1, index + 3).Equals("sqrt"))
                {
                    index += 3;
                    current = State.sqrt;
                }
                else if (!Char.IsWhiteSpace(ch))
                {
                    throw new ParsingException("unexpected char: \"" + ch + "\" at index: " + (index - 1));
                }
            }
            SkipWhitespace();

        }

        private ITripleExpression Atomic()
        {
            GetNext();
            ITripleExpression ret;
            switch (current)
            {
                case State.number:
                    ret = new Const(constant);
                    GetNext();
                    break;

                case State.variable:
                    ret = new Variable(Char.ToString(variable));
                    GetNext();
                    break;

                case State.minus:
                    ret = new CheckedSubtract(new Const(0), Atomic());
                    break;

                case State.abs:
                    ret = new CheckedAbs(Atomic());
                    break;

                case State.sqrt:
                    ret = new Square(Atomic());
                    break;

                case State.lparen:
                    ret = AddSubt();
                    if (current != State.rparen)
                    {
                        Console.WriteLine(") missing");
                        throw new InvalidOperationException(") missing");
                    }
                    GetNext();
                    break;

                default:
                    ret = null;
                    Console.WriteLine("Unrecognizable format");
                    throw new InvalidOperationException("Unrecognizable format");
                    break;
            }
            return ret;
        }

        private ITripleExpression MulDiv()
        {
            ITripleExpression left = Atomic();
            while (true)
            {
                switch (current)
                {
                    case State.asterisk:
                        left = new CheckedMultiply(left, Atomic());
                        break;

                    case State.slash:
                        left = new CheckedDivide(left, Atomic());
                        break;

                    case State.mod:
                        left = new Mod(left, Atomic());
                        break;

                    default:
                        return left;
                }
            }
        }

        private ITripleExpression AddSubt()
        {
            ITripleExpression left = MulDiv();
            while (true)
            {
                switch (current)
                {
                    case State.minus:
                        left = new CheckedSubtract(left, MulDiv());
                        break;

                    case State.plus:
                        left = new CheckedAdd(left, MulDiv());
                        break;

                    default:
                        return left;
                }
            }
        }

        public ITripleExpression Parse(string expression)
        {
            this.expression = expression;
            int bb = 0;
            for (int i = 0; i < this.expression.Length; i++)
            {
                if (this.expression[i] == '(')
                {
                    bb++;
                }
                else if (this.expression[i] == ')')
                {
                    bb--;
                }
                if (bb < 0)
                {
                    throw new ParsingException("unexpected ) at position: " + i);
                }
            }
            if (bb != 0)
            {
                throw new ParsingException("expected ) at end");
            }
            index = 0;
            return AddSubt();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    public class ExpressionParser : Parser
    {
        private int index;
        private string expression;
        private uint constant;
        private char variable;
        private enum State { number, plus, minus, asterisk, mod, slash, shiftLeft, shiftRight, square, abs, lparen, rparen, variable }
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
                constant = Convert.ToUInt32(str.ToString());
                current = State.number;
            }
            else if (ch == '+')
            {
                current = State.plus;
            }
            else if (ch == '-')
            {
                current = State.minus;
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
            else if (index < expression.Length)
            {
                //Костыль
                string sub1 = "", sub2 = "", sub3 = "";
                if (index + 2 < expression.Length)
                    for (int i = index - 1; i < index + 2; i++)
                        sub1 = sub1 + expression[i];
                if (index + 1 < expression.Length)
                    for (int i = index - 1; i < index + 1; i++)
                        sub2 = sub2 + expression[i];
                if (index + 5 < expression.Length)
                    for (int i = index - 1; i < index + 5; i++)
                        sub3 = sub3 + expression[i];

                if (sub1.Equals("mod"))
                {
                    current = State.mod;
                    index += 2;
                }
                else if (sub2.Equals("<<"))
                {
                    current = State.shiftLeft;
                    index += 1;
                }
                else if (sub2.Equals(">>"))
                {
                    current = State.shiftRight;
                    index += 1;
                }
                else if (sub1.Equals("abs"))
                {
                    current = State.abs;
                    index += 2;
                }
                else if (sub3.Equals("square"))
                {
                    current = State.square;
                    index += 5;
                }

                /* Нормальный код который не работает ArgumentOutOfRangeException...
                 * TODO: попробовать переделать
                if (expression.Substring(index - 1, index + 2).Equals("mod"))
                {
                    current = State.mod;
                    index += 2;
                }
                else if (expression.Substring(index - 1, index + 1).Equals("<<"))
                {
                    current = State.shiftLeft;
                    index += 1;
                }
                else if (expression.Substring(index - 1, index + 1).Equals(">>"))
                {
                    current = State.shiftRight;
                    index += 1;
                }
                else if (expression.Substring(index - 1, index + 2).Equals("abs"))
                {
                    current = State.abs;
                    index += 2;
                }
                else if (expression.Substring(index - 1, index + 5).Equals("square"))
                {
                    current = State.square;
                    index += 5;
                }
                */
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
                    ret = new Subtract(new Const(0), Atomic());
                    break;

                case State.abs:
                    ret = new Abs(Atomic());
                    break;

                case State.square:
                    ret = new Square(Atomic());
                    break;

                case State.lparen:
                    ret = Shifts();
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
                        left = new Multiply(left, Atomic());
                        break;

                    case State.slash:
                        left = new Divide(left, Atomic());
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
                        left = new Subtract(left, MulDiv());
                        break;

                    case State.plus:
                        left = new Add(left, MulDiv());
                        break;

                    default:
                        return left;
                }
            }
        }

        private ITripleExpression Shifts()
        {
            ITripleExpression left = AddSubt();
            while (true)
            {
                switch (current)
                {
                    case State.shiftLeft:
                        left = new ShiftLeft(left, AddSubt());
                        break;

                    case State.shiftRight:
                        left = new ShiftRight(left, AddSubt());
                        break;

                    default:
                        return left;
                }
            }
        }

        public ITripleExpression Parse(string expression)
        {
            this.expression = expression;
            return Shifts();
        }
    }
}

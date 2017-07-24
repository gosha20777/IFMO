using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    class OpInteger : IOperator<int>
    {
        private void CheckAdd(int a, int b)
        {
            if (a > 0 && b > int.MaxValue - a)
            {
                throw new OverflowException();
            }
            if (a< 0 &&  b<int.MinValue - a)
            {
                throw new OverflowException();
            }
        }

        private void CheckSubtract(int a, int b)
        {
            if(b > 0 && a < int.MinValue + b)
            {
                throw new OverflowException();
            }
            if(b < 0 && a > int.MaxValue + b)
            {
                throw new OverflowException();
            }
        }

        private void CheckDivide(int a, int b)
        {
            if(a == int.MinValue && b == -1)
            {
                throw new OverflowException();
            }
            if (b == 0)
            {
                throw new ZeroDivisionException();
            }
        }

        /* mod
        private void CheckMod(int a, int b)
        {
            if(a == int.MinValue && b == int.MinValue)
            {
                throw new OverflowException();
            }
            if (b == 0) 
            {
                throw new ZeroDivisionException();
            }
        }
        */

        private void CheckNegate(int a)
        {
            if (a <= int.MinValue)
            {
                throw new OverflowException();
            }
        }

        private void CheckMultiply(int a, int b)
        {
            if (a > b)
            {
                CheckMultiply(b, a);
            }
            else
            {
                if (a < 0)
                {
                    if (b < 0)
                    {
                        if (a < int.MaxValue/ b)
                        {
                            throw new OverflowException();
                        }
                    }
                    else if (b > 0)
                    {
                        if (int.MinValue / b > a)
                        {
                            throw new OverflowException();
                        }
                    }
                }
                else if (a > 0)
                {
                    if (a > int.MaxValue / b)
                    {
                        throw new OverflowException();
                    }
                }
            }
        }

        public int Parse(String a)
        {
            return int.Parse(a);
        }

        public int Add(int a, int b)
        {
            CheckAdd(a, b);
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            CheckSubtract(a, b);
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            CheckMultiply(a, b);
            return a * b;
        }
        public int Divide(int a, int b)
        {
            CheckDivide(a,b);
            return a / b;
        }
        public int Mod(int a, int b)
        {
            return a % b;
        }
        public int Negate(int a)
        {
            CheckNegate(a);
            return -a;
        }
        public int Abs(int a)   
        {
            if (a < 0)
            {
                return Subtract(0, a);
            }
            else
            {
                return a;
            }
        }
        public int Square(int a)
        {
            return Multiply(a, a);
        }
    }
}

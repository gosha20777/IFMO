using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Ussage ExpressionApp <Number>");
                return;
            }    
            double arg = Convert.ToDouble(args[0]);

            Console.Write("x*x-2*x+1 = ");
            Console.WriteLine(
            new Add(
                new Subtract(
                    new Multiply(new Variable("x"), new Variable("x")),
                    new Multiply(new Const(2), new Variable("x"))),
                new Const(1)).Evaluate(arg));
            //x*x-2*x+1 : (x==arg)
        }
    }
}
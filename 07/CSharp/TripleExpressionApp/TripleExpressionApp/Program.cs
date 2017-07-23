using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleExpressionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TripleExpressionApp!");
            Console.Write("Enter Expression: ");
            string exp = Console.ReadLine();
            CheckedParser parser = new CheckedParser();
            Console.Write("{0} = {1} : x= 2,y= 1,z= 1;", exp, parser.Parse(exp).Evaluate(2, 1, 1));
            Console.ReadLine();
        }
    }
}

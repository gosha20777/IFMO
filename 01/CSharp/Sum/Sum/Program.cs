using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.Write("Ussage: Sum <number1> <number2> ...");
                return;
            }

            int sum = 0;
            for (int i = 0; i < args.Length; i++)
            {
                sum += Convert.ToInt16(args[i]);
            }
            Console.WriteLine(sum);
        }
    }
}

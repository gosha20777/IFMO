using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumLongHex
{
    class Program
    {
        private static Int64 ParseHexString(string hexNumber)
        {
            hexNumber = hexNumber.Replace("x", string.Empty);
            Int64 result = 0;
            Int64.TryParse(hexNumber, System.Globalization.NumberStyles.HexNumber, null, out result);
            return result;
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Write("Ussage: Sum <number1> <number2> ...");
                return;
            }

            Int64 sum = 0;
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = args[i].ToLower();
                if (args[i].StartsWith("0x"))
                    sum += ParseHexString(args[i]);
            }
            Console.WriteLine(sum);
        }
    }
}

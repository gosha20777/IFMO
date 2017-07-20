using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayQueueModule
{
    class Program
    {
        /// <summary>
        /// точка входа в программу
        /// </summary>
        static ArrQueue q = new ArrQueue();
        static void Add(string[] args)
        {
            if(args.Length < 2)
            {
                Ussage();
                return;
            }
            for(int i = 1; i < args.Length; i++)
            {
                q.Enqueue(Convert.ToInt32(args[i]));
                Console.WriteLine("Added element: {0}", Convert.ToInt32(args[i]));
            }
        }
        static void Dell(string[] args)
        {
            if (args.Length < 2)
            {
                Ussage();
                return;
            }
            for(int i = 0; i<Convert.ToInt32(args[1]); i++)
            {
                Console.WriteLine("Deleted element: {0}", q.Dequeue());
            }
        }
        static void El(string[] args)
        {
            Console.WriteLine("First element: {0}", q.Element());
        }
        static void Clr()
        {
            q.Clear();
            Console.WriteLine("Cleared");
        }
        static void Ussage()
        {
            Console.WriteLine("Ussage:");
            Console.WriteLine("-----------------------------:-------------------");
            Console.WriteLine("-A <element1> <element2> ... : Add elements      ");
            Console.WriteLine("-D <Number or elements>      : Delete elements   ");
            Console.WriteLine("-E                           : Show first element");
            Console.WriteLine("-C                           : Clear Queue       ");
            Console.WriteLine("q                            : Exit              ");
            Console.WriteLine("-----------------------------:-------------------");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Queue program.");
            string cmd = "";
            do
            {
                cmd = Console.ReadLine();
                args = cmd.Split(' ');
                switch (args[0])
                {
                    case "-A": Add(args);
                        break;
                    case "-D":
                        Dell(args);
                        break;
                    case "-E":
                        El(args);
                        break;
                    case "-C":
                        Clr();
                        break;
                    default: Ussage();
                        break;
                }
            } while (cmd != "q");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        /*
         * бинареый поиск с учетом повторяющихся, крайних эл-в, с учетом порядка
         */

        static int BinarySearch_Rec(int[] array, bool descendingOrder, int key, int left, int right)
        {
            int mid = left + (right - left) / 2;

            if (left >= right)
                return -(1 + left);

            if (array[left] == key)
                return left;

            if (array[mid] == key)
            {
                if (mid == left + 1)
                    return mid;
                else
                    return BinarySearch_Rec(array, descendingOrder, key, left, mid + 1);
            }

            else if ((array[mid] > key) ^ descendingOrder)
                return BinarySearch_Rec(array, descendingOrder, key, left, mid);
            else
                return BinarySearch_Rec(array, descendingOrder, key, mid + 1, right);
        }
        static int BinarySearch_Rec_Wrapper(int[] array, int key)
        {
            if (array.Length == 0)
                return -1;

            bool descendingOrder = array[0] > array[array.Length - 1];
            return BinarySearch_Rec(array, descendingOrder, key, 0, array.Length);
        }

        static int BinarySearch_Iter(int[] array, bool descendingOrder, int key)
        {
            int left = 0;
            int right = array.Length;
            int mid = 0;

            while (!(left >= right))
            {
                mid = left + (right - left) / 2;

                if (array[left] == key)
                    return left;

                if (array[mid] == key)
                {
                    if (mid == left + 1)
                        return mid;
                    else
                        right = mid + 1;
                }

                else if ((array[mid] > key) ^ descendingOrder)
                    right = mid;
                else
                    left = mid + 1;
            }

            return -(1 + left);
        }
        static int BinarySearch_Iter_Wrapper(int[] array, int key)
        {
            if (array.Length == 0)
                return -1;

            bool descendingOrder = array[0] > array[array.Length - 1];
            return BinarySearch_Iter(array, descendingOrder, key);
        }

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Write("Ussage: BinarySearch <key_number> <number1> <number2> ...");
                return;
            }
            int key = Convert.ToInt32(args[0]);
            int[] array = new int[args.Length - 1];
            for (int i = 0; i < array.Length; i++)
                array[i] = Convert.ToInt32(args[i + 1]);

            Console.WriteLine(BinarySearch_Rec_Wrapper(array, key));
        }
    }
}

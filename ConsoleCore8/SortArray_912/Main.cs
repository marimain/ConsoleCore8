using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCore8.SortArray_912
{
    internal class Main
    {
        static int[] nums = { 5,2,3,1,4,3,7 };
        public static int[] Process()
        {
            string[] words = {
                // index from start    index from end
    "The",      // 0                   ^9
    "quick",    // 1                   ^8
    "brown",    // 2                   ^7
    "fox",      // 3                   ^6
    "jumps",    // 4                   ^5
    "over",     // 5                   ^4
    "the",      // 6                   ^3
    "lazy",     // 7                   ^2
    "dog"       // 8                   ^1
            };          
            string[] lazyDog = words[^2..^0];
           // subprocess(nums, 0);

            return new int[]{ };
        }
        private static void subprocess(int[] ar, int pilot)
        {

            int md = ar.Length / 2;

            if (md > 2)
            {
                subprocess(ar[0..md], ar[md]);
            }
            
        }
        public static void PrintValues(Array myArr)
        {
            System.Collections.IEnumerator myEnumerator = myArr.GetEnumerator();
            int i = 0;
            int cols = myArr.GetLength(myArr.Rank - 1);
            while (myEnumerator.MoveNext())
            {
                if (i < cols)
                {
                    i++;
                }
                else
                {
                    Console.WriteLine();
                    i = 1;
                }
                Console.Write("\t{0}", myEnumerator.Current);
            }
            Console.WriteLine();
        }

    }

}
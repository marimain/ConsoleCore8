using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCore8.LargestElm
{
    internal class Main
    {
        static int[] nums = [3, 2, 9, 5, 6, 4, 1];
        public static void Process()
        {
            int a = FindMaxNumber(nums, 0, nums.Count() - 1, 0);
            
            System.Diagnostics.Debug.WriteLine("max number: {0}", a);
            //PrintValues(nums);
        }
        public static int FindMaxNumber(int[] ar, int L, int R, int level)
        {
            if (L >= R)
            {
                return ar[L];
            }
            int m = (L + R) / 2;
            level++;
            int RL = FindMaxNumber(ar, L, m, level);
            int RR = FindMaxNumber(ar, m + 1, R, level);
            return RL > RR ? RL : RR;
            
        }
    }
}

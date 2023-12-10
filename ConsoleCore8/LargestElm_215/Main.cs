using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCore8.LargestElm_215
{
    internal class Main
    {
        static int[] nums = [3, 2, 1, 5, 6, 4];

        public static void Process()
        {
            int k = 2;
            List<int> list = new List<int>();
            foreach (int num in nums)
            {
                list.Add(num);
            }

            int a0= QuickSelect(list, k);
            //find max item in array O(log(n))
            List<int> aRet = new List<int>();
            int a = Maxnumber(nums, aRet, 0);

            //mergeSort(nums, 0, nums.Length - 1);
            ////System.Diagnostics.Debug.WriteLine("max number: {0}", a);
            //PrintValues(nums);
        }
        private static int Maxnumber(int[] ar, List<int> aRet, int level)
        {
            int ret = 0;
            if (ar.Length < 3)
            {
                if (ar.Length == 1)
                {
                    int tmp = ar[0];
                    aRet.Add(tmp);
                    return tmp;
                }
                else
                {
                    int tmp = ar[0] > ar[1] ? ar[0] : ar[1];
                    if (ar[0] > ar[1])
                    {
                        aRet.Add(ar[1]);
                        aRet.Add(ar[0]);
                    }
                    else
                    {
                        aRet.Add(ar[1]);
                        aRet.Add(ar[0]);
                    }
                    return tmp;
                }
            }
            int m = ar.Length / 2;
            level = level + 1;
            int RL = Maxnumber(ar[0..m], aRet, level);
            int RR = Maxnumber(ar[m..], aRet, level);

            return ret = RL > RR ? RL : RR;
        }
        public static int QuickSelect(List<int> nums, int k)
        {
            Random rand = new Random();
            int pivotIndex = rand.Next(nums.Count);
            int pivot = nums[pivotIndex];

            List<int> left = new List<int>();
            List<int> mid = new List<int>();
            List<int> right = new List<int>();

            foreach (int num in nums)
            {
                if (num > pivot)
                {
                    left.Add(num);
                }
                else if (num < pivot)
                {
                    right.Add(num);
                }
                else
                {
                    mid.Add(num);
                }
            }

            if (k <= left.Count)
            {
                return QuickSelect(left, k);
            }

            if (left.Count + mid.Count < k)
            {
                return QuickSelect(right, k - left.Count - mid.Count);
            }

            return pivot;
        }
        
    }
}

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
        static int[] nums = { -2, 3, -5 };
        public static int[] Process()
        {
            int temp = 0;
            for (int i = 0; i < nums.Count(); i++) {
                for (int j = i + 1; j < nums.Count(); j++) {
                    if (nums[i] > nums[j]) {      //swap elements if not in order
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }

            }
            return nums;
        }
        public static int[] Process5()
        {
            {
                int ln = nums.Count();
                int[] ar = Enumerable.Repeat(0, ln).ToArray();
                int mi = 0;
                int pos = 0;
                int mxint = int.MaxValue;
                List<int> ns = nums.ToList();

                for (int i = 0; i < ln; i++)
                {
                    mi = ns.Min();
                    pos = ns.IndexOf(mi);
                    ns.Remove(ns[pos]);
                    //nums[pos] = mxint;
                    ar[i] = mi;
                }
                return ar;
            }
        }
        private int[] findmin(int[] nums)
        {
            int ln = nums.Count();
            int[] ar = Enumerable.Repeat(0, ln).ToArray();
            int mi = 0;
            int pos = 0;
            int mxint = int.MaxValue;
            for (int i = 0; i < ln; i++)
            {
                mi = nums.Min();
                pos = Array.IndexOf(nums, mi);
                nums[pos] = mxint;
                ar[i] = mi;
            }
            return ar; ;
        }
        public static int[] Process4()
        {

            int[] ret = Enumerable.Repeat(0, nums.Count()).ToArray<int>();
            int[] ar = Enumerable.Repeat(0, nums.Count()).ToArray<int>();

            int preval = nums[0];
            ret[0] = preval;
            int curPos = 0;
            bool isInsert = false;
            for (int i = 1; i < nums.Length; i++)
            {
                int tmp = nums[i];
                curPos++;
                isInsert = false;
                int k = 0;
                while (true)
                {
                    if (ret[k] >= tmp)
                    {
                        Array.Copy(ret, k, ar, 0, ret.Length - k);
                        ret[k] = tmp;
                        Array.Copy(ar, 0, ret, k + 1, ret.Length - k - 1);
                        isInsert = true;
                        break;
                    }
                    if (k < curPos)
                    {
                        k++;
                        Console.WriteLine(k);
                    }
                    else
                    {
                        Console.WriteLine("brak {0}", k);
                        break;
                    }
                }
                if (isInsert == false)
                {
                    ret[curPos] = tmp;
                }
            }
            return ret;
        }
        public static void Process2()
        {
            int minval = 0;
            int maxval = 0;
            Dictionary<int, KeyValuePair<int, int>> ar = new Dictionary<int, KeyValuePair<int, int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                minval = 0;
                int tmp = nums[i];
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] <= nums[i] && i != j)
                    {
                        minval++;
                        if (maxval < minval)
                        {
                            maxval = minval;
                        }

                        //var kv = ar[i];
                        //ar[i] = new KeyValuePair<int, int>(kv.Key, kv.Value + 1);
                    }

                }
                ar.Add(i, new KeyValuePair<int, int>(nums[i], minval));

            }
            List<int> ret = new List<int>();
            for (int i = 0; i < maxval + 1; i++)
            {
                for (int j = 0; j < ar.Count(); j++)
                {
                    if (ar[j].Value == i)
                    {
                        ret.Add(ar[j].Key);
                    }
                }
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
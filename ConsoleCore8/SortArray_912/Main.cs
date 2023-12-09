using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleCore8.SortArray_912
{
    internal class Main
    {
        static int[] nums = { 4, 5, 11, 2, 258, 3, 1, 8, 9, 101, 4, 88, 2, 32, 245 };
        
        public static void Process()
        {
            int m = nums.Count() / 2;
            int[] arl = nums[0..m];
            int[] arr = nums[m..];

            int l = 0;
            int r = m;
            int a = FindMax(arl, arr);
            //int a = mergeSort(nums, l, m);
            System.Diagnostics.Debug.WriteLine("max number: {0}", a);
        }
        private static int FindMax(int[] arl, int[] arr)
        {
            //{ 4, 5,11, 2, 258,3, 1,8,9,101,4,88,2,32,245}
            //4,5,11  2,3,1
            int retl = 0;
            int retr = 0;
            if (arl.Count() > 2)
            {
                int ml = arl.Count() / 2;
                retl = FindMax(arl[0..ml], arl[ml..]);
            }
            else
            {
                if (arl.Count() == 1)
                {
                    retl = arl[0];
                }
                else
                {
                    retl = arl[0] > arl[1] ? arl[0] : arl[1];
                }
                
            }
            if (arr.Count() > 2)
            {
                int mr = arr.Count() / 2;
                retr = FindMax(arr[0..mr], arr[mr..]);
            }
            else
            {
                if (arr.Count() == 1)
                {
                    retr = arr[0];
                }
                else
                {
                    retr = arr[0] > arr[1] ? arr[0] : arr[1];
                }
                
            }

            if (retl > retr)
            {
                return retl;
            }
            else
            {
               return retr;
            }
            
        }
        private static int mergeSort(int[] ar, int l, int r)
        {
            int ret = 0;
            int m= (l + r) / 2;
            int[] arl = ar[0..m];
            int[] arr = ar[m..];
            if (l >= r)
            {
                return ret;
            }

            mergeSort(nums, l, m);
            mergeSort(nums, m + 1, r);

            return ret;
        }
        private static void mergeSort2(int[] nums, int l, int r)
        {
            if (l>=r)
            {
                return;
            }
            var m= (l + r) / 2;
            mergeSort(nums, l, m);
            mergeSort(nums, m + 1, r);
            merge(nums, l, m, r);
        }

        private static void merge(int[] A, int l, int m, int r)
        {
            int[] sorted = new int[r - l + 1];
            int k = 0;     // sorted's index
            int i = l;     // left's index
            int j = m + 1; // right's index

            while (i <= m && j <= r)
                if (A[i] < A[j])
                    sorted[k++] = A[i++];
                else
                    sorted[k++] = A[j++];

            // Put the possible remaining left part into the sorted array.
            while (i <= m)
                sorted[k++] = A[i++];

            // Put the possible remaining right part into the sorted array.
            while (j <= r)
                sorted[k++] = A[j++];

            //System.arraycopy(sorted, 0, A, l, sorted.length);
            Array.Copy(sorted, 0, A, l, sorted.Count());
            //sorted.ToArray().CopyTo(0,A, l, sorted.Count());
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
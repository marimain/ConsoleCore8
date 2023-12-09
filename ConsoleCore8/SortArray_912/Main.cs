using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleCore8.SortArray_912
{
    internal class Main
    {
        static int[] nums =  { 5, 2, 3, 1 };
        
        public static void Process()
        {
          
            mergeSort(nums, 0, nums.Count() - 1);

        }

        private static void mergeSort(int[] nums, int l, int r)
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
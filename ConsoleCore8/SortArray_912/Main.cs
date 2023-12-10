using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleCore8.SortArray_912
{
    internal class Main
    {
        static int[] nums = [3, 2, 1, 5, 6, 4]; //{ 4, 5, 11, 2, 258, 3, 1, 8, 9, 345, 4, 88, 2, 32, 245,25,54,48,78 };
        static List<int> lst = [4, 5, 11, 2, 258, 3, 1, 8, 9, 345, 4, 88, 2, 32, 245, 25, 54, 48, 78];
        static List<int> lsth = [3, 2, 1, 5, 6, 4];
        static List<int> rets=new List<int>();
        public static void Process2()
        {

 
            //int a = Maxnumber(nums);
            int b = Maxnumber(lsth,0);


            System.Diagnostics.Debug.WriteLine("max number: {0}", b);
        }
        public static void PrintIndexAndValues(Array myArray)
        {
            for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
                Console.WriteLine("\t[{0}]:\t{1}", i, myArray.GetValue(i));
        }
        public static void Process()
        {
           // rets = Enumerable.Repeat(int.MinValue, nums.Length).ToList();
            int m = nums.Count() / 2;
            int[] arl = nums[0..m];
            int[] arr = nums[m..];
            nums =[ 2,5,1,3];
            nums =[ 5,2,6,1,9,3];
            //Direct sort 2 part array. [ 2,5,6,1,3,9];
            //merge(nums, 0, 2, 5);
            
            //find max item in array O(log(n))
            int a = Maxnumber(lst, 0);

            //mergeSort(nums, 0, nums.Length - 1);
            //System.Diagnostics.Debug.WriteLine("max number: {0}", a);
            PrintValues(rets.ToArray());
        }
        private static int Maxnumber(int[] ar)
        {
            int ret = 0;
            int retl = 0, retr = 0;

            if (ar.Count() < 3)
            {
                if (ar.Count() == 1)
                {
                    return ar[0];
                }
                else
                {
                    return ar[0] > ar[1] ? ar[0] : ar[1];
                }
                
            }
            int m = ar.Count() / 2;
            retl =Maxnumber(ar[0..m]);
            retr = Maxnumber(ar[m..]);
            ret = retl > retr ? retl : retr;
            return ret;
        }
        private static int Maxnumber(List<int> ar, int level)
        {
            int ret = 0;
            int retl = 0, retr = 0;
            if (ar.Count() < 3)
            {

                if (ar.Count() == 1)
                {
                    return ar[0];
                }
                else
                {
                    return ar[0] > ar[1] ? ar[0] : ar[1];
                }
            }
            int m = ar.Count() / 2;
            level++;
            retl = Maxnumber(ar[0..m], level);
            retr = Maxnumber(ar[m..], level);

            ret = retl > retr ? retl : retr;

            SortArray(ar[0..m], ar[m..], level);

            return ret;
        }
        private static void SortArray(List<int> arl, List<int> arr, int level)
        {
            List<int> art = new List<int>();
            int posL = 0;
            int posR = 0;
            if (arl.Count == 2)
            {
                if (arl[0] > arl[1])
                {
                    int tmp = arl[0];
                    arl[0] = arl[1];
                    arl[1] = tmp;
                }
            }
            if (arr.Count == 2)
            {
                if (arr[0] > arr[1])
                {
                    int tmp = arr[0];
                    arr[0] = arr[1];
                    arr[1] = tmp;
                }
            }
            while (true)
            {
                if (arl[posL] < arr[posR])
                {
                    art.Add(arl[posL]);
                    posL++;
                }
                else
                {
                    art.Add(arr[posR]);
                    posR++;
                }
                if (posL >= arl.Count() || posR >= arr.Count())
                {
                    break;
                }
            }
            if (posL < arl.Count())
            {
                for(int i=posL;i<arl.Count(); i++)
                {
                    art.Add(arl[i]);
                }
            }
            if (posR < arr.Count())
            {
                for(int i=posR;i<arr.Count(); i++)
                {
                    art.Add(arr[i]);
                }
            }
            if (level > 1)
            {
                SortArray2(art, level);
            }
            System.Diagnostics.Debug.WriteLine("aaa");
        }
 private static void SortArray2(List<int> ar, int level)
        {
            int posL = 0;
            int posR = 0;
            List<int> art = new List<int>();
            while (true)
            {
                if (rets.Count() > 0)
                {
                    if (ar[posL] < rets[posR])
                    {
                        art.Add(ar[posL]);
                        posL++;
                    }
                    else
                    {
                        art.Add(rets[posR]);
                        posR++;
                    }
                    if (posL >= ar.Count() || posR >= rets.Count())
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            if (posL < ar.Count())
            {
                for(int i=posL;i<ar.Count(); i++)
                {
                    art.Add(ar[i]);
                }
            }
            if (posR < rets.Count())
            {
                for(int i=posR;i<rets.Count(); i++)
                {
                    art.Add(rets[i]);
                }
            }
            rets.Clear();
            for(int i = 0; i < art.Count(); i++)
            {
                rets.Add(art[i]);
            }

            System.Diagnostics.Debug.WriteLine("leve {0}", level);
        }     

        private static void mergeSort(int[] nums, int L, int R)
        {
            if (L>=R)
            {
                return;
            }
            var M= (L + R) / 2;
            mergeSort(nums, L, M);
            mergeSort(nums, M + 1, R);
            merge(nums, L, M, R);
        }

        //sort a 2 parts array, in 2 part, sub array sorted already
        private static void merge(int[] A, int L, int M, int R)
        {
            //[5, 2, 3, 1]
            //[ 2,5,6,1,3,9];
            int[] sorted = new int[R - L + 1];
            int k = 0;     // sorted's index
            int i = L;     // left's index
            int j = M + 1; // right's index

            while (i <= M && j <= R)
                if (A[i] < A[j])
                {
                    sorted[k] = A[i];
                    k++;
                    i++;
                }
                else
                {
                    sorted[k] = A[j];
                    k++;
                    j++;
                }

            // Put the possible remaining left part into the sorted array.
            while (i <= M)
                sorted[k++] = A[i++];

            // Put the possible remaining right part into the sorted array.
            while (j <= R)
                sorted[k++] = A[j++];

            //System.arraycopy(sorted, 0, A, l, sorted.length);
            Array.Copy(sorted, 0, A, L, sorted.Count());
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCore8.CoinChange
{
    internal class Main
    {
        static int n = 10;
        static int[] c = { 2, 5, 3, 6 };
        static int totalcount = 0;
        public Main()
        {

        }
        public static void Process()
        {
            int ln = c.Length;
            List<int[,]> ar = new List<int[,]>();

            for(int i = 0; i < ln; i++)
            {
                int ln1 = n / c[i];
                int v = c[i];
                int[,] ar1 = new int[ln1 + 1, 2];
                ar1[0, 0] = 0;
                ar1[0, 1] = 0;
                int j = 1;

                while (true)
                {
                    if (v * j <=n)
                    {
                        if (v * j == n)
                        {
                            totalcount++;
                        }
                        else
                        {
                            ar1[j, 0] = v * j;
                            ar1[j, 1] = 0;
                        }
                        j++;
                    }
                    else
                    {
                        ar.Add(ar1);
                        break;
                    }
                }
            }

            var ret = subprocess(n, 0, new KeyValuePair<int, int>(0,0) , ar);
            
            Console.WriteLine("Main Process");
        }
        private static KeyValuePair<int,int> subprocess(int n,int j, KeyValuePair<int,int> val, List<int[,]> ar)
        {
            int[,] ar0= ar[j];
            
            for(int i = 0; i < ar0.GetLength(0); i++)
            {
                int tmp = ar0[i, 0];
                if (j == 0)
                {
                    val = new KeyValuePair<int, int>(tmp, 0);
                }
                //System.Diagnostics.Debug.WriteLine(tmp);
                if (tmp + val.Key >= n)
                {
                    if(tmp + val.Key == n)
                    {
                        System.Diagnostics.Debug.WriteLine("item {0} val {1} level {2}", tmp, val.Key, j);
                        totalcount++;
                    }
                    //break;
                }
                if (j < ar.Count() - 1 && val.Value==0)
                {
                    val = subprocess(n, j + 1, val, ar);
                }
                else
                {
                    val = new KeyValuePair<int, int>(val.Key, 1);
                }
               if(j==0 && i==ar0.GetLength(0)-1 && val.Value==1)
                {
                    val = new KeyValuePair<int, int>(totalcount, 0);
                }
            }
            
            return val;
        }
        private int mainprocess()
        {
            for(int i = 0; i < c.Count(); i++)
            {
                int v = v[i];
            }
            return 0;
        }
    }
}

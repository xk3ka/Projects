using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation01
{
    public class Solution
    {
        public static bool MethodFirst(double[,] array)
        {
            double last = 0;
            double curr = 0;

            int j = 1;

            while (true)
            {
                for (int i = array.GetUpperBound(0) - 1; i != 0; i--)
                {
                    if (j == 1 && i == array.GetUpperBound(0) - 1)
                    {
                        curr = array[i, j];
                        continue;
                    }
                    last = curr;
                    curr = array[i, j];
                    if (last > curr)
                    {
                        return false;
                    }
                }
                j++;
                if (j == array.GetUpperBound(1)) break;

                for (int i = 1; i != array.GetUpperBound(0); i++)
                {
                    last = curr;
                    curr = array[i, j];
                    if (last > curr)
                    {
                        return false;
                    }
                }
                j++;
                if (j == array.GetUpperBound(1)) break;
            }
            return true;
        }

        public static bool MethodSecond(double[,] array)
        {
            double last = 0;
            double curr = 0;

            int i = 1;
            int j = 0;
            int n = array.GetUpperBound(1)-1; //j
            int m = array.GetUpperBound(0)-2; //i

            bool cn = false;
            bool cm = false;

            while (true)
            {
                if (n == 0) break;
                cn = !cn;
                for (int c = 0; c <n;c++)
                {
                    if (cn)
                    {
                        j++;
                    }
                    else
                    {
                        j--;
                    }
                    if (i == 1 && j == 1)
                    {
                        curr = array[i, j];
                        continue;
                    }
                    last = curr;
                    curr = array[i, j];
                    if (last > curr)
                    {
                        return false;
                    }
                }
                n--;


                if (m == 0) break;
                cm = !cm;
                for (int c = 0; c <m; c++)
                {
                    if (cm)
                    {
                        i++;
                    }
                    else
                    {
                        i--;
                    }
                    last = curr;
                    curr = array[i, j];
                    if (last > curr)
                    {
                        return false;
                    }
                }
                m--;
            }
            return true;
        }
    }
}

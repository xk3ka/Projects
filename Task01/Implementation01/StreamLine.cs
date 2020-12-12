using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation01
{
    public class Streamline
    {
        public static double[,] StreamlineArray(double[,] arr)
        {
            return StreamlineColumns(StreamlineRows(arr));
        }

        private static double[,] StreamlineColumns(double[,] arr)
        {
            for (int i = arr.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        SwapColumns(arr, i, j);
                    }
                }
            }

            return arr;
        }

        private static double[,] StreamlineRows(double[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = arr.GetLength(1) - 1; j >= 0; j--)
                {
                    if (arr[i, j] == 0)
                    {
                        SwapRows(arr, i, j);
                    }
                }
            }

            return arr;
        }

        private static void SwapColumns(double[,] arr, int i, int j)
        {
            while (i + 1 < arr.GetLength(0) && arr[i + 1, j] != 0)
            {
                double tmp = arr[i + 1, j];
                arr[i + 1, j] = arr[i, j];
                arr[i, j] = tmp;
                i++;
            }
        }

        private static void SwapRows(double[,] arr, int i, int j)
        {
            while (j + 1 < arr.GetLength(1) && arr[i, j + 1] != 0)
            {
                double tmp = arr[i, j + 1];
                arr[i, j + 1] = arr[i, j];
                arr[i, j] = tmp;
                j++;
            }
        }
    }
}

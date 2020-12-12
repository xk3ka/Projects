using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation01
{
    public class ArrayUtils
    {
        public void PrintArray(double[,] array)
        {
            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static double[,] Load(String filename)
        {
            string[] s1 = File.ReadAllLines(filename);
            string[] s2 = s1[0].Trim().Split(' ');
            double[,] array = new double[s1.Length, s2.Length];
            for (int i = 0; i < s1.Length; i++)
            {
                string[] str = s1[i].Trim().Split(' ');
                for (int j = 0; j < str.Length; j++)
                {
                    array[i, j] = Convert.ToDouble(str[j].Trim());
                }
            }
            return array;
        }
    }
}

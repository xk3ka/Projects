using System;
using System.Windows.Forms;

namespace Implementation01
{
    public class TableUtils
    {
        public static void CustomizeTable(DataGridView dataGridView, int n, int m)
        {
            dataGridView.RowCount = n;
            dataGridView.ColumnCount = m;

            dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Height = 25;
            }

            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].Width = 25;
            }
        }

        public static void FillTable(double[,] arr, DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = arr[i, j].ToString();
                }
            }
        }

        public static double[,] ReadTable(DataGridView dataGridView)
        {
            double[,] arr = new double[dataGridView.RowCount, dataGridView.ColumnCount];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = Convert.ToDouble(dataGridView.Rows[i].Cells[j].Value);
                }
            }

            return arr;
        }

        public static void FillTable(object p, DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }
    }
}

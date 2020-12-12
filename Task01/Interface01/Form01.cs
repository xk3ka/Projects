using Implementation01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface01
{
    public partial class Form01 : Form
    {
        public Form01()
        {
            InitializeComponent();  
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;


            openFileDialog1.InitialDirectory = new FileInfo(Directory.GetCurrentDirectory()).Directory.Parent.
    Parent.Parent.FullName + "\\Task01\\Files";
            openFileDialog1.FileName = "arrays";
            openFileDialog1.Filter = "Текстовый файл|*.txt";
            openFileDialog1.RestoreDirectory = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.FileName;

            double[,] array = ArrayUtils.Load(filename);
            TableUtils.CustomizeTable(dataGridView1, array.GetUpperBound(0) + 1, array.GetUpperBound(1) + 1);
            TableUtils.FillTable(array, dataGridView1);
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;

            MessageBox.Show(
            "Матрица загружена.",
            "Сообщение",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] array = TableUtils.ReadTable(dataGridView1);

            if (array.GetUpperBound(0) + 1 > 2 && array.GetUpperBound(1) + 1 > 2){
                if (Solution.MethodFirst(array))
                {
                    MessageBox.Show(
                    "Матрица упорядочена (Варианат 1).",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button3);
                }
                else
                {
                    MessageBox.Show(
                    "Матрица не упорядочена (Варианат 1).",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button3);
                }
            }
            else MessageBox.Show(
                    "Матрица слишком маленькая.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[,] array = TableUtils.ReadTable(dataGridView1);

            if (array.GetUpperBound(0) + 1 > 2 && array.GetUpperBound(1) + 1 > 2)
            {
                if (Solution.MethodSecond(array))
                {
                    MessageBox.Show(
                    "Матрица упорядочена (Варианат 2).",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button2);
                }
                else
                {
                    MessageBox.Show(
                    "Матрица не упорядочена (Варианат 2).",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button2);
                }
            }
            else MessageBox.Show(
                    "Матрица слишком маленькая.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            MessageBox.Show(
            "Таблица была успешно очищена!",
            "Сообщение",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button3);
        }
    }
}

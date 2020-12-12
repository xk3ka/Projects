using Implementation02;
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

namespace Interface02
{
    public partial class Form02 : Form
    {
        public Form02()
        {
            InitializeComponent();

            openFileDialog1.InitialDirectory = new FileInfo(Directory.GetCurrentDirectory()).Directory.Parent.
Parent.Parent.FullName + "\\Projects\\Task02\\Files";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Текстовый файл|*.txt";
            openFileDialog1.RestoreDirectory = true;

            button2.Enabled = false;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            button2.Enabled = true;
            textBox1.Enabled = true;

            updateTextBox();

            MessageBox.Show(
                "Файл " + openFileDialog1.FileName + " загружен",
                "Уведомление",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> Lines = new List<string>();
            Lines.AddRange(File.ReadAllLines(openFileDialog1.FileName, Encoding.UTF8));

            Solution solution = new Solution(Lines);

            int N = int.Parse(textBox1.Text);

            if (N < Lines.Count && N > 0)
            {
                solution.Run(N);
                File.WriteAllLines(openFileDialog1.FileName, Lines);
                updateTextBox();
            }
            else
            {
                MessageBox.Show(
                    N + " абзаца нет в файле.",
                    "Уведомление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            textBox1.Text = "";
        }

        private void updateTextBox()
        {
            using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
            {
                textBox2.Text = reader.ReadToEnd().Replace("\n", Environment.NewLine);
            }
        }
    }
}

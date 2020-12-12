using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Implementation06;

namespace Interface06
{
    public partial class Form06 : Form
    {
        private readonly DataList List = new DataList();

        public Form06()
        {
            InitializeComponent();
            listBox1.DataSource = List.GetList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ParseName(textBox2.Text) && int.TryParse(textBox3.Text, out int a)
                && int.TryParse(textBox4.Text, out int b) && int.TryParse(textBox5.Text, out int c))
            {
                List.AddEmployee(new Leader(textBox2.Text, a, b, c));
                UpdateList();
                ClearTextBoxes();
            }
            else
            {
                ShowMessageBox("Неверные данные.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                List.RemoveEmployee(List.GetList()[listBox1.SelectedIndex]);
                textBox1.Text = " ";
                UpdateList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List.InBusinessTrip(listBox1.SelectedIndex);
            UpdateText(listBox1.SelectedIndex);
            UpdateButtons(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List.ReturnFromBusinessTrip(listBox1.SelectedIndex);
            UpdateText(listBox1.SelectedIndex);
            UpdateButtons(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List.LoadExample();
            UpdateList();
            ClearTextBoxes();
            UpdateButtons(1);
            textBox1.Text = "";
            button5.Enabled = false;
            ShowMessageBox("Пример загружен.");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index != -1)
            {
                UpdateText(index);
                int status = List.GetList()[index].BusinessTripStatus;
                if (status == 0)
                {
                    UpdateButtons(1);
                }
                else if (status == 1)
                {
                    UpdateButtons(2);
                }
                else
                {
                    UpdateButtons(3);
                }
            }
            else
            {
                UpdateButtons(3);
                textBox1.Text = " ";
            }
        }

        private bool ParseName(string Name)
        {
            string[] line = Name.Trim().Split();
            if (line.Length != 3)
            {
                return false;
            }
            foreach(string s in line)
            {
                if(!Regex.IsMatch(s, "^[^x]+$"))
                {
                    return false;
                }
            }
            return true;
        }

        private void UpdateList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = List.GetList();
        }

        private void UpdateText(int index)
        {
            string text = List.GetInfo(index);
            textBox1.Text = text.Replace("\n", Environment.NewLine);
        }

        private void UpdateButtons(int x)
        {
            switch (x)
            {
                case 1:
                    button3.Enabled = true;
                    button4.Enabled = false;
                    break;
                case 2:
                    button3.Enabled = false;
                    button4.Enabled = true;
                    break;
                case 3:
                    button3.Enabled = false;
                    button4.Enabled = false;
                    break;
            }
        }

        private void ClearTextBoxes()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void ShowMessageBox(String st)
        {
            MessageBox.Show(
               st,
               "Уведомление",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }
    }
}

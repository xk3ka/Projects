using Implementation04;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface04
{
    public partial class Form04 : Form
    {

        private List<object> Products { get; set; } = new List<object> { };

        private List<string> ProductsNames { get; set; } = new List<string> { };


        public Form04()
        {
            InitializeComponent();
            textBox4.Enabled = false;
            numericUpDown1.Value = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text.Trim();
            if (name != "" && !ProductsNames.Contains(name))
            {
                if (checkBox1.Checked)
                {
                    int price;
                    int date;
                    if(int.TryParse(textBox3.Text,out price)&& int.TryParse(textBox4.Text, out date)&&numericUpDown1.Value>0)
                    {
                        Products.Add(new ProductDate(name, price,
                        Convert.ToInt32(numericUpDown1.Value), date));
                        ProductsNames.Insert(ProductsNames.Count, name);
                        listBox1.Items.Insert(ProductsNames.IndexOf(name), name);
                        MessageBox.Show("Добавлен новый товар с датой.!");
                        checkBox1.Checked = false;

                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        numericUpDown1.Value = 1;
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели неверные данные.");
                    }
                }
                else
                {
                    int price;
                    if (int.TryParse(textBox3.Text, out price) && numericUpDown1.Value > 0)
                    {
                        Products.Add(new Product(name, price,
                        Convert.ToInt32(numericUpDown1.Value)));
                        ProductsNames.Insert(ProductsNames.Count, name);
                        listBox1.Items.Insert(ProductsNames.IndexOf(name), name);
                        MessageBox.Show("Добавлен новый товар!");

                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        numericUpDown1.Value = 1;
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели неверные данные.");
                    }
                }
            }
            else
            {
                MessageBox.Show(
                "Неверное название товара!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Products.RemoveAt(listBox1.SelectedIndex);
            ProductsNames.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.Remove(listBox1.SelectedItem);
            textBox1.Text = "";

            MessageBox.Show("Товар был удален.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.Enabled = true;
            }
            else
            {
                textBox4.Enabled = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button2.Enabled = true;
                UpdateText();
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void UpdateText()
        {
            textBox1.Text = "";
            string text;
            if (Products.ElementAt(listBox1.SelectedIndex) is ProductDate)
            {
                ProductDate product = (ProductDate)Products.ElementAt(listBox1.SelectedIndex);
                text = "Товар с датой." + product.GetProductDateInfo();
            }
            else
            {
                Product product = (Product)Products.ElementAt(listBox1.SelectedIndex);
                text = "Товар без даты." + product.GetProductInfo();
            }
            textBox1.Text = text.Replace("\n", Environment.NewLine);
        }
    }
}

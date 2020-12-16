using Implementation03;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface03
{
    public partial class Form03 : Form
    {
        private Plane plane;
        public Form03()
        {
            InitializeComponent();
            setButtons();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plane = new Plane(new Engine("F-200", 390), 
                new List<Chassis> { new Chassis("S-199", 8), new Chassis("S-199B", 18), new Chassis("S-199B", 18) }, 
                new List<Wing> { new Wing(175, "PEG-17"),new Wing(175, "PEG-17")});
            setButtons();
            button5.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox2.Enabled = true;
            button2.Enabled = true;
            textBox3.Text = "Создан новый самолет.";
            UpdateText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                button3.Enabled = true;
                button4.Enabled = true;
                plane.SetRoute(textBox2.Text);
                textBox3.Text = "Задан маршрут.";
            }
            else
            {
                MessageBox.Show(
                   "Вы не ввели маршрут.",
                   "Уведомление",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = plane.GetRoute();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = plane.Fly();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int size = 0;
            if (textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && int.TryParse(textBox6.Text,out size))
            {
                plane.SetNewChassis(new List<Chassis> { new Chassis(textBox5.Text, size), new Chassis(textBox5.Text, size) });
                UpdateText();
                textBox5.Text = "";
                textBox6.Text = "";
            }
            else
            {
                MessageBox.Show(
                   "Вы ввели неверные данные о новой модели/Вы не ввели данные о модели",
                   "Уведомление",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }

        }
        private void UpdateText()
        {
            string text = plane.GetInfoAboutPlane();
            textBox1.Text = text.Replace("\n", Environment.NewLine);
        }

        private void setButtons()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            textBox2.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
        }
    }
}

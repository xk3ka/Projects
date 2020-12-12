using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainWindow
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Interface01.Form01 form = new Interface01.Form01();
            form.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Interface02.Form02 form = new Interface02.Form02();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Interface03.Form03 form = new Interface03.Form03();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Interface04.Form04 form = new Interface04.Form04();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Interface06.Form06 form = new Interface06.Form06();
            form.Show();
        }
    }
}

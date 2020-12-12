using System;
using Employees;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface07
{
    public partial class Form07 : Form
    {

        public List<Type> Classes { get; set; }

        public Form07()
        {
            InitializeComponent();
        }

        public void SetTypes()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Type type in Assembly.LoadFrom(textBox1.Text).GetTypes())
            {
                if (type.GetInterface(typeof(IEmployee).Name) != null && !type.IsAbstract)
                {
                    Classes.Add(new ClassInfo(type, type.GetConstructors(), type.GetMethods()));
                }
            }
        }
    }
}

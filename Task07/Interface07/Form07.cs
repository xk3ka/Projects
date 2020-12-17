using System;
using Employees;
using Implementation07;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Interface07
{
    public partial class Form07 : Form
    {

        private readonly List<ClassInfo> Classes = new List<ClassInfo>();

        private readonly DataList List = new DataList();

        public Form07()
        {
            InitializeComponent();

            openFileDialog1.InitialDirectory = new FileInfo(Directory.GetCurrentDirectory()).Directory.Parent.
Parent.Parent.FullName + "\\Projects\\Task07\\Employees";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "|*.dll";
            openFileDialog1.RestoreDirectory = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                UploadClasses();
                UpdateComboBox();
            }
            catch
            {
                ErrorBox("Задан некорректный путь к библиотеке классов.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Classes[comboBox1.SelectedIndex].IsConstructor(listBox1.SelectedIndex))
                {
                    InvokeConstructor(comboBox1.SelectedIndex, listBox1.SelectedIndex);
                }
                else
                {
                    InvokeMethod(comboBox1.SelectedIndex, listBox1.SelectedIndex - Classes[comboBox1.SelectedIndex].
                        Constructors.Length);
                }
            }
            catch
            {
                ErrorBox("Некорректные параметры.");
            }
        }

        private void UploadClasses()
        {
            foreach (Type type in Assembly.LoadFrom(textBox1.Text).GetTypes())
            {
                if (!type.IsAbstract && type.GetInterface(typeof(IEmployee).Name) != null)
                {
                    Classes.Add(new ClassInfo(type, type.GetConstructors(), type.GetMethods()));
                }
            }
        }

        private string[] GetClassNames()
        {
            string[] names = new string[Classes.Count];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = Classes[i].GetClassName();
            }
            return names;
        }

        private void InvokeConstructor(int classIndex, int constructorIndex)
        {
            Engineer eng = (Engineer)Classes[classIndex].Constructors[constructorIndex].Invoke(ParseParameters());
            
            if (List.Contains(eng.Name))
            {
                return;
            }

            switch (Classes[classIndex].GetClassName())
            {
                case "Leader":
                    List.AddLeader((Leader)eng);
                    break;
                case "JuniorEngineer":
                    List.AddJuniorEngineer((JuniorEngineer)eng);
                    break;
                case "SeniorEngineer":
                    List.AddSeniorEngineer((SeniorEngineer)eng);
                    break;
            }
            UpdateListBox2();
        }

        private void InvokeMethod(int classIndex, int methodIndex)
        {
            int instanceIndex = listBox2.SelectedIndex;
            if (instanceIndex == -1)
            {
                ErrorBox("Не выбран экземпляр класса.");
                return;
            }
            if (List.Engineers[instanceIndex].GetType() != Classes[classIndex].Type)
            {
                ErrorBox("Вы выбрали не тот экземпляр класса.");
                return;
            }
            string result = Classes[classIndex].Methods[methodIndex].Invoke(List.Engineers
                [instanceIndex], ParseParameters()).ToString();
            UpdateListBox2();
            MethodBox(result);
        }

        private object[] ParseParameters()
        {
            string[] line = textBox3.Text.Trim().Split(';');
            if (line.Length == 1 && line[0].Trim() == "")
            {
                return new object[0];
            }
            object[] parameters = new object[line.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                if (int.TryParse(line[i], out int value))
                {
                    parameters[i] = value;
                }
                else
                {
                    parameters[i] = line[i].Trim();
                }
            }
            return parameters;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                textBox2.Text = "";
                button3.Enabled = false;
                return;
            }
            textBox2.Text = Classes[comboBox1.SelectedIndex].GetMethodParameters(listBox1.SelectedIndex);
            button3.Enabled = true;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListBox2();
            if (listBox2.SelectedIndex == -1)
            {
                return;
            }
            textBox4.Text = List.Engineers[listBox2.SelectedIndex].GetInfo().Replace("\n", Environment.NewLine);
        }

        private void UpdateListBox2()
        {
            listBox2.DataSource = null;
            listBox2.DataSource = List.Engineers;
        }


        private void UpdateComboBox()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = GetClassNames();
            comboBox1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = Classes[comboBox1.SelectedIndex].GetMethodNames();
        }

        private void MethodBox(string text)
        {
            MessageBox.Show(
                text,
                "Вывод метода",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        private void ErrorBox(string text)
        {
            MessageBox.Show(
                text,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
        }
    }
}

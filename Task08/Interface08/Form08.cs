using Implementation08;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface08
{
    public partial class Form08 : Form
    {
        private ClassInfo _classinfo;
        private Emulator _emulator;
        private Thread _repaintThread = null;
        private List<Type> _types = new List<Type>();

        public Image OperatorOff = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\operatorOff.png");
        public Image OperatorOn = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\operatorOn.png");
        public Image QuadOff = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\quadOff.png");
        public Image QuadOn = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\quadOn.png");
        public Image MechanicStay = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\mechanicStay.png");
        public Image MechanicMove = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\mechanicMove.png");

        public Form08()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;

            _classinfo = new ClassInfo(@"A:\source\ISIT\Task08\Interface08\bin\Debug\Implementation08.dll");
            SetMechanic();
        }

        private void SetMechanic()
        {
            foreach (var mechanic in _classinfo.ChildrensAndImpls(typeof(IMechanic)))
            {
                _types.Add(mechanic);
            }
            UpdateComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_repaintThread == null)
            {
                List<Operator> allOperators = new List<Operator>();
                int Step = 4;
                for (int i = 0; i < (int)numericUpDown2.Value; i++)
                {
                    Quadrocopter q = new Quadrocopter(new Route(
                        new List<Coord>(){
                            new Coord(110, 4 + 100 * i, Step),
                            new Coord(panel1.Width - 110, 4 + 100 * i, Step),
                        }), new Coord(110, 4 + 100 * i, Step), (int)numericUpDown1.Value);
                    Operator op1 = new Operator(q, new Coord(4, 4 + 100 * i, Step));
                    allOperators.Add(op1);
                }

                Step *= 5;
                IMechanic mechanic = (IMechanic)Activator.CreateInstance(_types[comboBox1.SelectedIndex]);
                mechanic.BaseCoord = new Coord(panel1.Width / 2, panel1.Height - 75, Step);
                mechanic.NextCoord = new Coord(panel1.Width / 2, panel1.Height - 75, Step);
                _emulator = new Emulator(allOperators, mechanic);
                _emulator.Start();
                _repaintThread = new Thread(PanelRepaint)
                {
                    IsBackground = true
                };
                _repaintThread.Start();
                button1.Text = @"Стоп";
            }
            else
            {
                _emulator.Stop();
                _repaintThread.Abort();
                _repaintThread = null;
                button1.Text = @"Запуск";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            Graphics g = e.Graphics;
            
            g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Black)), p.DisplayRectangle);

            if (_emulator == null)
            {
                return;
            }

            if (_emulator.Mechanic.OnBase())
            {
                g.DrawImage(MechanicStay, _emulator.Mechanic.NextCoord.X, _emulator.Mechanic.NextCoord.Y, 75, 75);
            }
            else
            {
                g.DrawImage(MechanicMove, _emulator.Mechanic.NextCoord.X, _emulator.Mechanic.NextCoord.Y, 75, 75);
            }

            foreach(var emOp in _emulator.Operators)
            {
                if(!emOp.Quadrocopter.NeedHelp)
                {
                    g.DrawImage(OperatorOn, emOp.MyCoord.X, emOp.MyCoord.Y, 75, 75);
                    g.DrawImage(QuadOn, emOp.Quadrocopter.MyCoord.X, emOp.Quadrocopter.MyCoord.Y, 75, 75);
                }
                else
                {
                    g.DrawImage(OperatorOff, emOp.MyCoord.X, emOp.MyCoord.Y, 75, 75);
                    g.DrawImage(QuadOff, emOp.Quadrocopter.MyCoord.X, emOp.Quadrocopter.MyCoord.Y, 75, 75);
                }
            }
        }
        private void PanelRepaint()
        {
            while (true)
            {
                Thread.Sleep(100);
                panel1.Invalidate();
            }
        }

        private void Form08_Load(object sender, EventArgs e)
        {
            _emulator?.Stop();
            _repaintThread?.Abort();
        }

        public void UpdateComboBox()
        {
            List<String> list = new List<string>();
            foreach(var mechanic in _types)
            {
                list.Add(mechanic.Name);
            }
            comboBox1.DataSource = null;
            comboBox1.DataSource = list;
        }
    }
}
